using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(Guid Id);
        Task<Result<T>> FindByIdAsync(Guid Id);
        Task<Result<List<T>>> GetAllAsync();
    }
}
