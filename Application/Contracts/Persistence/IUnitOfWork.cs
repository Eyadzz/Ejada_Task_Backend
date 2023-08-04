using System.Data;
using Application.Contracts.Persistence.Repositories;

namespace Application.Contracts.Persistence;

/// <summary>
/// Represents a Unit of Work interface, providing methods to work with database transactions.
/// </summary>
/// <remarks>
/// The Unit of Work pattern is used to maintain a consistent transactional boundary across multiple
/// operations in a single logical unit. It helps manage database transactions and provides a way to
/// commit or rollback changes.
/// </remarks>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Asynchronously saves the changes made within the Unit of Work to the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Save();

    /// <summary>
    /// Asynchronously begins a database transaction.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task BeginTransaction();

    /// <summary>
    /// Asynchronously begins a database transaction with the specified isolation level.
    /// </summary>
    /// <param name="isolationLevel">The isolation level for the transaction.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task BeginTransaction(IsolationLevel isolationLevel);

    /// <summary>
    /// Asynchronously commits the active database transaction.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Commit();

    /// <summary>
    /// Asynchronously rolls back the active database transaction.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Rollback();

    public IUserRepository Users { get; set; }
    public IDepartmentRepository Departments { get; set; }
    public ITaskRepository Tasks { get; set; }
    public IEmployeeRepository Employees { get; set; }
    public IManagerRepository Managers { get; set; }
}
