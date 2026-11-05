using RestoLux.Application.Common;

namespace RestoLux.Application.Common;

public interface ICrudService<TDto, TCreate, TUpdate>
{
    Task<IReadOnlyList<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<TDto>> CreateAsync(TCreate dto, CancellationToken cancellationToken = default);
    Task<Result<TDto>> UpdateAsync(int id, TUpdate dto, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}