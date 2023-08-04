namespace Application.Contracts.Persistence;

/// <summary>
/// Represents an interface for a generic asynchronous repository that provides basic CRUD operations for entities of type T.
/// </summary>
/// <typeparam name="T">The type of entity that the repository handles. It must be a reference type (class).</typeparam>
public interface IAsyncRepository<T> where T : class
{
    /// <summary>
    /// Asynchronously retrieves all entities of type T from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a list of all entities.</returns>
    Task<List<T>> ListAllAsync();

    /// <summary>
    /// Asynchronously adds an entity of type T to the repository.
    /// </summary>
    /// <param name="entity">The entity to be added to the repository.</param>
    /// <returns>A task representing the asynchronous operation that returns the added entity.</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity of type T in the repository.
    /// </summary>
    /// <param name="entity">The entity to be updated in the repository.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity of type T from the repository.
    /// </summary>
    /// <param name="entity">The entity to be deleted from the repository.</param>
    void Delete(T entity);

    /// <summary>
    /// Asynchronously retrieves an entity of type T from the repository based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns the retrieved entity, or null if no entity is found
    /// with the specified identifier.
    /// </returns>
    Task<T?> GetAsync(int id);
}

