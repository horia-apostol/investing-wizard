using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories.Base
{
    /// <summary>
    /// Repository base class that provIdes basic CRUD operations for a given entity type.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class Repository<T>(MainContext context) : IAsyncRepository<T> where T : class
    {
        private readonly MainContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly DbSet<T> _dbSet = context.Set<T>();

        /// <summary>
        /// Asynchronously adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A <see cref="Result{T}"/> indicating the success or failure of the operation.</returns>
        public virtual async Task<Result<T>> AddAsync(T entity)
        {
            if (entity == null) { return CommonErrors.UnexpectedNullValue; }

            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException) { return CommonErrors.DatabaseUpdateError; }
            catch (Exception) { return CommonErrors.UnexpectedError; }
        }

        /// <summary>
        /// Asynchronously updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A <see cref="Result{T}"/> indicating the success or failure of the operation.</returns>
        public virtual async Task<Result<T>> UpdateAsync(T entity)
        {
            if (entity == null) { return CommonErrors.UnexpectedNullValue; }

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException) { return CommonErrors.ConcurrencyConflict; }
            catch (DbUpdateException) { return CommonErrors.DatabaseUpdateError; }
            catch (Exception) { return CommonErrors.UnexpectedError; }
        }

        /// <summary>
        /// Asynchronously finds an entity by its Identifier.
        /// </summary>
        /// <param name="Id">The Identifier of the entity.</param>
        /// <returns>A <see cref="Result{T}"/> indicating the success or failure of the operation.</returns>
        public virtual async Task<Result<T>> FindByIdAsync(Guid Id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(Id);
                if (entity == null) { return CommonErrors.EntityNotFound; }

                return entity;
            }
            catch (Exception) { return CommonErrors.UnexpectedError; }
        }

        /// <summary>
        /// Asynchronously deletes an entity by its Identifier.
        /// </summary>
        /// <param name="Id">The Identifier of the entity to delete.</param>
        /// <returns>A <see cref="Result{T}"/> indicating the success or failure of the operation.</returns>
        public virtual async Task<Result<T>> DeleteAsync(Guid Id)
        {
            var result = await FindByIdAsync(Id);

            if (result.IsFailure) { return result.Error; }
            if (result.Value == null) { return CommonErrors.UnexpectedNullValue; }

            try
            {
                _dbSet.Remove(result.Value);
                await _context.SaveChangesAsync();
                return result.Value;
            }
            catch (DbUpdateException) { return CommonErrors.DatabaseUpdateError; }
            catch (Exception) { return CommonErrors.UnexpectedError; }
        }

        /// <summary>
        /// Asynchronously retrieves all entities.
        /// </summary>
        /// <returns>A <see cref="Result{T}"/> indicating the success or failure of the operation.</returns>
        public virtual async Task<Result<List<T>>> GetAllAsync()
        {
            try
            {
                var entities = await _dbSet.ToListAsync();
                if (IsNullOrEmpty(entities)) { return CommonErrors.NoEntitiesFound; }
                return entities;
            }
            catch (Exception) { return CommonErrors.UnexpectedError; }
        }

        private static bool IsNullOrEmpty(List<T> entities)
        {
            return entities == null || entities.Count == 0;
        }
    }
}
