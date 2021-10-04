namespace VBooX.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VBooX.Application.Interfaces;

    /// <summary>
    /// Defines the <see cref="GenericServiceAsync{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class GenericServiceAsync<T> : IGenericServiceAsync<T> where T : class
    {
        /// <summary>
        /// Defines the _repository.
        /// </summary>
        private readonly IGenericRepositoryAsync<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericServiceAsync{T}"/> class.
        /// </summary>
        /// <param name="repository">The repository<see cref="IGenericRepositoryAsync{T}"/>.</param>
        public GenericServiceAsync(IGenericRepositoryAsync<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// The AddAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        /// <summary>
        /// The GetAllAsync.
        /// </summary>
        /// <returns>The <see cref="Task{IReadOnlyList{T}}"/>.</returns>
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// The GetPagedReponseAsync.
        /// </summary>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IReadOnlyList{T}}"/>.</returns>
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
