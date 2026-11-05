using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Domain.Entities;
using RestoLux.Domain.Interfaces;

namespace RestoLux.Application.Services;

// Branch
public interface IBranchService : ICrudService<BranchDto, CreateBranchDto, UpdateBranchDto>
{
}
public class BranchService : IBranchService
{
    private readonly IRepository<Branch> _repo; private readonly IUnitOfWork _uow;
    public BranchService(IRepository<Branch> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<BranchDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<BranchDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<BranchDto>> CreateAsync(CreateBranchDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<BranchDto>.Success(e.ToDto()); }
    public async Task<Result<BranchDto>> UpdateAsync(int id, UpdateBranchDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<BranchDto>.Failure("Branch not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<BranchDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Branch not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Menu
public interface IMenuService : ICrudService<MenuDto, CreateMenuDto, UpdateMenuDto>
{
}
public class MenuService : IMenuService
{
    private readonly IRepository<Menu> _repo; private readonly IUnitOfWork _uow;
    public MenuService(IRepository<Menu> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<MenuDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<MenuDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<MenuDto>> CreateAsync(CreateMenuDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<MenuDto>.Success(e.ToDto()); }
    public async Task<Result<MenuDto>> UpdateAsync(int id, UpdateMenuDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<MenuDto>.Failure("Menu not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<MenuDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Menu not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// MenuCategory
public interface IMenuCategoryService : ICrudService<MenuCategoryDto, CreateMenuCategoryDto, UpdateMenuCategoryDto>
{
}
public class MenuCategoryService : IMenuCategoryService
{
    private readonly IRepository<MenuCategory> _repo; private readonly IUnitOfWork _uow;
    public MenuCategoryService(IRepository<MenuCategory> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<MenuCategoryDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<MenuCategoryDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<MenuCategoryDto>> CreateAsync(CreateMenuCategoryDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<MenuCategoryDto>.Success(e.ToDto()); }
    public async Task<Result<MenuCategoryDto>> UpdateAsync(int id, UpdateMenuCategoryDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<MenuCategoryDto>.Failure("MenuCategory not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<MenuCategoryDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("MenuCategory not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Product
public interface IProductService : ICrudService<ProductDto, CreateProductDto, UpdateProductDto>
{
}
public class ProductService : IProductService
{
    private readonly IRepository<Product> _repo; private readonly IUnitOfWork _uow;
    public ProductService(IRepository<Product> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ProductDto>> CreateAsync(CreateProductDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductDto>.Success(e.ToDto()); }
    public async Task<Result<ProductDto>> UpdateAsync(int id, UpdateProductDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ProductDto>.Failure("Product not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Product not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Customer
public interface ICustomerService : ICrudService<CustomerDto, CreateCustomerDto, UpdateCustomerDto>
{
}
public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repo; private readonly IUnitOfWork _uow;
    public CustomerService(IRepository<Customer> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<CustomerDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<CustomerDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<CustomerDto>> CreateAsync(CreateCustomerDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<CustomerDto>.Success(e.ToDto()); }
    public async Task<Result<CustomerDto>> UpdateAsync(int id, UpdateCustomerDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<CustomerDto>.Failure("Customer not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<CustomerDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Customer not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Reservation
public interface IReservationService : ICrudService<ReservationDto, CreateReservationDto, UpdateReservationDto>
{
}
public class ReservationService : IReservationService
{
    private readonly IRepository<Reservation> _repo; private readonly IUnitOfWork _uow;
    public ReservationService(IRepository<Reservation> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ReservationDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ReservationDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ReservationDto>> CreateAsync(CreateReservationDto dto, CancellationToken ct = default)
    {
        await _uow.BeginTransactionAsync(ct);
        try
        {
            var existing = await _repo.FindAsync(r => r.BranchId == dto.BranchId && r.Date == dto.Date && !r.IsDeleted, ct);
            if (existing.Any(r => r.StartTime < dto.EndTime && dto.StartTime < r.EndTime))
            {
                await _uow.RollbackTransactionAsync(ct);
                return Result<ReservationDto>.Failure("Seçilen zaman aralığında çakışan rezervasyon var.");
            }
            var e = dto.ToEntity();
            await _repo.AddAsync(e, ct);
            await _uow.SaveChangesAsync(ct);
            await _uow.CommitTransactionAsync(ct);
            return Result<ReservationDto>.Success(e.ToDto());
        }
        catch
        {
            await _uow.RollbackTransactionAsync(ct);
            throw;
        }
    }
    public async Task<Result<ReservationDto>> UpdateAsync(int id, UpdateReservationDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ReservationDto>.Failure("Reservation not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ReservationDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Reservation not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Review
public interface IReviewService : ICrudService<ReviewDto, CreateReviewDto, UpdateReviewDto>
{
}
public class ReviewService : IReviewService
{
    private readonly IRepository<Review> _repo; private readonly IUnitOfWork _uow;
    public ReviewService(IRepository<Review> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ReviewDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ReviewDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ReviewDto>> CreateAsync(CreateReviewDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ReviewDto>.Success(e.ToDto()); }
    public async Task<Result<ReviewDto>> UpdateAsync(int id, UpdateReviewDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ReviewDto>.Failure("Review not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ReviewDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Review not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// Allergen
public interface IAllergenService : ICrudService<AllergenDto, CreateAllergenDto, UpdateAllergenDto>
{
}
public class AllergenService : IAllergenService
{
    private readonly IRepository<Allergen> _repo; private readonly IUnitOfWork _uow;
    public AllergenService(IRepository<Allergen> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<AllergenDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<AllergenDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<AllergenDto>> CreateAsync(CreateAllergenDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<AllergenDto>.Success(e.ToDto()); }
    public async Task<Result<AllergenDto>> UpdateAsync(int id, UpdateAllergenDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<AllergenDto>.Failure("Allergen not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<AllergenDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("Allergen not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// DietaryTag
public interface IDietaryTagService : ICrudService<DietaryTagDto, CreateDietaryTagDto, UpdateDietaryTagDto>
{
}
public class DietaryTagService : IDietaryTagService
{
    private readonly IRepository<DietaryTag> _repo; private readonly IUnitOfWork _uow;
    public DietaryTagService(IRepository<DietaryTag> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<DietaryTagDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<DietaryTagDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<DietaryTagDto>> CreateAsync(CreateDietaryTagDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DietaryTagDto>.Success(e.ToDto()); }
    public async Task<Result<DietaryTagDto>> UpdateAsync(int id, UpdateDietaryTagDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<DietaryTagDto>.Failure("DietaryTag not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DietaryTagDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("DietaryTag not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// TaxRule
public interface ITaxRuleService : ICrudService<TaxRuleDto, CreateTaxRuleDto, UpdateTaxRuleDto>
{
}
public class TaxRuleService : ITaxRuleService
{
    private readonly IRepository<TaxRule> _repo; private readonly IUnitOfWork _uow;
    public TaxRuleService(IRepository<TaxRule> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<TaxRuleDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<TaxRuleDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<TaxRuleDto>> CreateAsync(CreateTaxRuleDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<TaxRuleDto>.Success(e.ToDto()); }
    public async Task<Result<TaxRuleDto>> UpdateAsync(int id, UpdateTaxRuleDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<TaxRuleDto>.Failure("TaxRule not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<TaxRuleDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("TaxRule not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// DiningArea
public interface IDiningAreaService : ICrudService<DiningAreaDto, CreateDiningAreaDto, UpdateDiningAreaDto>
{
}
public class DiningAreaService : IDiningAreaService
{
    private readonly IRepository<DiningArea> _repo; private readonly IUnitOfWork _uow;
    public DiningAreaService(IRepository<DiningArea> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<DiningAreaDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<DiningAreaDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<DiningAreaDto>> CreateAsync(CreateDiningAreaDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DiningAreaDto>.Success(e.ToDto()); }
    public async Task<Result<DiningAreaDto>> UpdateAsync(int id, UpdateDiningAreaDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<DiningAreaDto>.Failure("DiningArea not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DiningAreaDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("DiningArea not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// DiningTable
public interface IDiningTableService : ICrudService<DiningTableDto, CreateDiningTableDto, UpdateDiningTableDto>
{
}
public class DiningTableService : IDiningTableService
{
    private readonly IRepository<DiningTable> _repo; private readonly IUnitOfWork _uow;
    public DiningTableService(IRepository<DiningTable> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<DiningTableDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<DiningTableDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<DiningTableDto>> CreateAsync(CreateDiningTableDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DiningTableDto>.Success(e.ToDto()); }
    public async Task<Result<DiningTableDto>> UpdateAsync(int id, UpdateDiningTableDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<DiningTableDto>.Failure("DiningTable not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<DiningTableDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("DiningTable not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// OpeningHour
public interface IOpeningHourService : ICrudService<OpeningHourDto, CreateOpeningHourDto, UpdateOpeningHourDto>
{
}
public class OpeningHourService : IOpeningHourService
{
    private readonly IRepository<OpeningHour> _repo; private readonly IUnitOfWork _uow;
    public OpeningHourService(IRepository<OpeningHour> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<OpeningHourDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<OpeningHourDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<OpeningHourDto>> CreateAsync(CreateOpeningHourDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<OpeningHourDto>.Success(e.ToDto()); }
    public async Task<Result<OpeningHourDto>> UpdateAsync(int id, UpdateOpeningHourDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<OpeningHourDto>.Failure("OpeningHour not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<OpeningHourDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("OpeningHour not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// SpecialClosure
public interface ISpecialClosureService : ICrudService<SpecialClosureDto, CreateSpecialClosureDto, UpdateSpecialClosureDto>
{
}
public class SpecialClosureService : ISpecialClosureService
{
    private readonly IRepository<SpecialClosure> _repo; private readonly IUnitOfWork _uow;
    public SpecialClosureService(IRepository<SpecialClosure> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<SpecialClosureDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<SpecialClosureDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<SpecialClosureDto>> CreateAsync(CreateSpecialClosureDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<SpecialClosureDto>.Success(e.ToDto()); }
    public async Task<Result<SpecialClosureDto>> UpdateAsync(int id, UpdateSpecialClosureDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<SpecialClosureDto>.Failure("SpecialClosure not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<SpecialClosureDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("SpecialClosure not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// ContentPage
public interface IContentPageService : ICrudService<ContentPageDto, CreateContentPageDto, UpdateContentPageDto>
{
}
public class ContentPageService : IContentPageService
{
    private readonly IRepository<ContentPage> _repo; private readonly IUnitOfWork _uow;
    public ContentPageService(IRepository<ContentPage> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ContentPageDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ContentPageDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ContentPageDto>> CreateAsync(CreateContentPageDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ContentPageDto>.Success(e.ToDto()); }
    public async Task<Result<ContentPageDto>> UpdateAsync(int id, UpdateContentPageDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ContentPageDto>.Failure("ContentPage not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ContentPageDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("ContentPage not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// SiteSetting
public interface ISiteSettingService : ICrudService<SiteSettingDto, CreateSiteSettingDto, UpdateSiteSettingDto>
{
}
public class SiteSettingService : ISiteSettingService
{
    private readonly IRepository<SiteSetting> _repo; private readonly IUnitOfWork _uow;
    public SiteSettingService(IRepository<SiteSetting> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<SiteSettingDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<SiteSettingDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<SiteSettingDto>> CreateAsync(CreateSiteSettingDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<SiteSettingDto>.Success(e.ToDto()); }
    public async Task<Result<SiteSettingDto>> UpdateAsync(int id, UpdateSiteSettingDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<SiteSettingDto>.Failure("SiteSetting not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<SiteSettingDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("SiteSetting not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// ModifierGroup
public interface IModifierGroupService : ICrudService<ModifierGroupDto, CreateModifierGroupDto, UpdateModifierGroupDto>
{
}
public class ModifierGroupService : IModifierGroupService
{
    private readonly IRepository<ModifierGroup> _repo; private readonly IUnitOfWork _uow;
    public ModifierGroupService(IRepository<ModifierGroup> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ModifierGroupDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ModifierGroupDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ModifierGroupDto>> CreateAsync(CreateModifierGroupDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ModifierGroupDto>.Success(e.ToDto()); }
    public async Task<Result<ModifierGroupDto>> UpdateAsync(int id, UpdateModifierGroupDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ModifierGroupDto>.Failure("ModifierGroup not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ModifierGroupDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("ModifierGroup not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// ModifierOption
public interface IModifierOptionService : ICrudService<ModifierOptionDto, CreateModifierOptionDto, UpdateModifierOptionDto>
{
}
public class ModifierOptionService : IModifierOptionService
{
    private readonly IRepository<ModifierOption> _repo; private readonly IUnitOfWork _uow;
    public ModifierOptionService(IRepository<ModifierOption> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ModifierOptionDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ModifierOptionDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ModifierOptionDto>> CreateAsync(CreateModifierOptionDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ModifierOptionDto>.Success(e.ToDto()); }
    public async Task<Result<ModifierOptionDto>> UpdateAsync(int id, UpdateModifierOptionDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ModifierOptionDto>.Failure("ModifierOption not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ModifierOptionDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("ModifierOption not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// ProductVariant
public interface IProductVariantService : ICrudService<ProductVariantDto, CreateProductVariantDto, UpdateProductVariantDto>
{
}
public class ProductVariantService : IProductVariantService
{
    private readonly IRepository<ProductVariant> _repo; private readonly IUnitOfWork _uow;
    public ProductVariantService(IRepository<ProductVariant> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ProductVariantDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ProductVariantDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ProductVariantDto>> CreateAsync(CreateProductVariantDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductVariantDto>.Success(e.ToDto()); }
    public async Task<Result<ProductVariantDto>> UpdateAsync(int id, UpdateProductVariantDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ProductVariantDto>.Failure("ProductVariant not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductVariantDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("ProductVariant not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// ProductImage
public interface IProductImageService : ICrudService<ProductImageDto, CreateProductImageDto, UpdateProductImageDto>
{
}
public class ProductImageService : IProductImageService
{
    private readonly IRepository<ProductImage> _repo; private readonly IUnitOfWork _uow;
    public ProductImageService(IRepository<ProductImage> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<ProductImageDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<ProductImageDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<ProductImageDto>> CreateAsync(CreateProductImageDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductImageDto>.Success(e.ToDto()); }
    public async Task<Result<ProductImageDto>> UpdateAsync(int id, UpdateProductImageDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<ProductImageDto>.Failure("ProductImage not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<ProductImageDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("ProductImage not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// BranchProductAvailability
public interface IBranchProductAvailabilityService : ICrudService<BranchProductAvailabilityDto, CreateBranchProductAvailabilityDto, UpdateBranchProductAvailabilityDto>
{
}
public class BranchProductAvailabilityService : IBranchProductAvailabilityService
{
    private readonly IRepository<BranchProductAvailability> _repo; private readonly IUnitOfWork _uow;
    public BranchProductAvailabilityService(IRepository<BranchProductAvailability> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<BranchProductAvailabilityDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<BranchProductAvailabilityDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<BranchProductAvailabilityDto>> CreateAsync(CreateBranchProductAvailabilityDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<BranchProductAvailabilityDto>.Success(e.ToDto()); }
    public async Task<Result<BranchProductAvailabilityDto>> UpdateAsync(int id, UpdateBranchProductAvailabilityDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<BranchProductAvailabilityDto>.Failure("BranchProductAvailability not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<BranchProductAvailabilityDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("BranchProductAvailability not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}

// NotificationTemplate
public interface INotificationTemplateService : ICrudService<NotificationTemplateDto, CreateNotificationTemplateDto, UpdateNotificationTemplateDto>
{
}
public class NotificationTemplateService : INotificationTemplateService
{
    private readonly IRepository<NotificationTemplate> _repo; private readonly IUnitOfWork _uow;
    public NotificationTemplateService(IRepository<NotificationTemplate> repo, IUnitOfWork uow) { _repo = repo; _uow = uow; }
    public async Task<IReadOnlyList<NotificationTemplateDto>> GetAllAsync(CancellationToken ct = default) => (await _repo.GetAllAsync(ct)).Select(e => e.ToDto()).ToList();
    public async Task<NotificationTemplateDto?> GetByIdAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); return e?.ToDto(); }
    public async Task<Result<NotificationTemplateDto>> CreateAsync(CreateNotificationTemplateDto dto, CancellationToken ct = default) { var e = dto.ToEntity(); await _repo.AddAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<NotificationTemplateDto>.Success(e.ToDto()); }
    public async Task<Result<NotificationTemplateDto>> UpdateAsync(int id, UpdateNotificationTemplateDto dto, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result<NotificationTemplateDto>.Failure("NotificationTemplate not found."); dto.Apply(e); await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result<NotificationTemplateDto>.Success(e.ToDto()); }
    public async Task<Result> DeleteAsync(int id, CancellationToken ct = default) { var e = await _repo.GetByIdAsync(id, ct); if (e is null) return Result.Failure("NotificationTemplate not found."); e.IsDeleted = true; e.UpdatedAt = DateTime.UtcNow; await _repo.UpdateAsync(e, ct); await _uow.SaveChangesAsync(ct); return Result.Success(); }
}
