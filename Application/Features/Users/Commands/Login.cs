using Application.Contracts.Authentication;
using Application.Features.Users.Dto;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Users.Commands;

public record Login(string Email, string Password) : IRequest<BaseResponse>;

public class LoginHandler : IRequestHandler<Login,BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordManager _passwordManager;
    private readonly IDistributedCache _distributedCache;


    public LoginHandler(IUnitOfWork unitOfWork,IJwtProvider jwtProvider, IPasswordManager passwordManager, IDistributedCache distributedCache)
    {
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
        _passwordManager = passwordManager;
        _distributedCache = distributedCache;
    }
    
    public async Task<BaseResponse> Handle(Login request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByEmail(request.Email);
        if (user is null)
            return Responses.NotFound("User");
        
        var passwordVerificationResult = _passwordManager.Verify(request.Password, user.PasswordHash);
        
        if(!passwordVerificationResult)
            return Responses.NotFound("User");
        
        await TryRemoveOldRefreshToken(user.Id);
        
        var response = new LoginResponse(
            AccessToken: _jwtProvider.Generate(user),
            RefreshToken: await GetRefreshToken(user.Id)
        );
        
        return Responses.Success(response);
    }

    private async Task TryRemoveOldRefreshToken(int userId)
    {
        var refreshToken = await _distributedCache.GetStringAsync(userId.ToString());
        
        if (refreshToken is not null)
            await _distributedCache.RemoveAsync(userId.ToString());
    }
    private async Task<string> GetRefreshToken(int userId)
    {
        
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        
        await _distributedCache.SetStringAsync(userId.ToString(), refreshToken, new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddDays(30)
        });

        return refreshToken;
    }
}


