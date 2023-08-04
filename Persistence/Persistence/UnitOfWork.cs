using System.Data;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.DatabaseConfig;
using Persistence.Persistence.Repositories;

namespace Persistence.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _transaction;
    private IUserRepository? _users;
    private IDepartmentRepository? _departments;
    private IEmployeeRepository? _employees;
    private IManagerRepository? _managers;
    private ITaskRepository? _tasks;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IUserRepository Users
    {
        get => _users ??= new UserRepository(_dbContext);
        set => _users = value;
    }

    public IDepartmentRepository Departments
    {
        get => _departments ??= new DepartmentRepository(_dbContext);
        set => _departments = value;
    }
    
    public ITaskRepository Tasks
    {
        get => _tasks ??= new TaskRepository(_dbContext);
        set => _tasks = value;
    }
    
    public IEmployeeRepository Employees
    {
        get => _employees ??= new EmployeeRepository(_dbContext);
        set => _employees = value;
    }
    
    public IManagerRepository Managers
    {
        get => _managers ??= new ManagerRepository(_dbContext);
        set => _managers = value;
    }

    public async Task Save() => await _dbContext.SaveChangesAsync();

    public async Task BeginTransaction() => _transaction = await _dbContext.Database.BeginTransactionAsync();

    public async Task BeginTransaction(IsolationLevel isolationLevel) => _transaction = await _dbContext.Database.BeginTransactionAsync(isolationLevel);

    public async Task Commit()
    {
        if (_transaction != null)
            await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        _transaction?.Dispose();
    }
}
