using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Domain.Entities;
using RestoLux.Domain.Interfaces;

namespace RestoLux.Application.Services;

public interface IRestaurantService : ICrudService<RestaurantDto, CreateRestaurantDto, UpdateRestaurantDto>
{
}

public class RestaurantService : IRestaurantService
{
    private readonly IRepository<Restaurant> _repo;
    private readonly IUnitOfWork _uow;

    public RestaurantService(IRepository<Restaurant> repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<IReadOnlyList<RestaurantDto>> GetAllAsync(CancellationToken cancellationToken = default)
        => (await _repo.GetAllAsync(cancellationToken)).Select(e => e.ToDto()).ToList();

    public async Task<RestaurantDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var e = await _repo.GetByIdAsync(id, cancellationToken);
        return e?.ToDto();
    }

    public async Task<Result<RestaurantDto>> CreateAsync(CreateRestaurantDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.ToEntity();
        await _repo.AddAsync(entity, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return Result<RestaurantDto>.Success(entity.ToDto());
    }

    public async Task<Result<RestaurantDto>> UpdateAsync(int id, UpdateRestaurantDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        if (entity is null) return Result<RestaurantDto>.Failure("Restaurant not found.");
        dto.Apply(entity);
        await _repo.UpdateAsync(entity, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return Result<RestaurantDto>.Success(entity.ToDto());
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        if (entity is null) return Result.Failure("Restaurant not found.");
        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        await _repo.UpdateAsync(entity, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
