using Application.Contracts.Authentication;
using Application.Contracts.Services;
using Application.Features.Users.Dto;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Users.Commands;

public record TokenRefresher(string RefreshToken) : IRequest<BaseResponse>;


public class TokenRefresherHandler : IRequestHandler<TokenRefresher, BaseResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IDistributedCache _distributedCache;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public TokenRefresherHandler(IJwtProvider jwtProvider, IDistributedCache distributedCache, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    {
        _jwtProvider = jwtProvider;
        _distributedCache = distributedCache;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse> Handle(TokenRefresher request, CancellationToken cancellationToken)
    {
        var storedRefreshToken = await _distributedCache.GetStringAsync(_currentUserService.UserId.ToString(), token: cancellationToken);

        if (storedRefreshToken != request.RefreshToken)
            return Responses.Unauthorized();
        
        var user = await _unitOfWork.Users.GetUserWithRole(_currentUserService.UserId);
        
        var response = new LoginResponse(
            AccessToken: _jwtProvider.Generate(user!),
            RefreshToken: request.RefreshToken
        );

        return Responses.Success(response);
    }
}