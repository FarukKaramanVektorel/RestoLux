using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestoLux.Domain.Entities;

namespace RestoLux.Infrastructure.Data;

/// <summary>
/// EF Core database context for RestoLux.
/// </summary>
public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Allergen> Allergens => Set<Allergen>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<BranchProductAvailability> BranchProductAvailabilities => Set<BranchProductAvailability>();
    public DbSet<ContentPage> ContentPages => Set<ContentPage>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerConsent> CustomerConsents => Set<CustomerConsent>();
    public DbSet<CustomerNote> CustomerNotes => Set<CustomerNote>();
    public DbSet<DietaryTag> DietaryTags => Set<DietaryTag>();
    public DbSet<DiningArea> DiningAreas => Set<DiningArea>();
    public DbSet<DiningTable> DiningTables => Set<DiningTable>();
    public DbSet<LocalizedText> LocalizedTexts => Set<LocalizedText>();
    public DbSet<MediaAsset> MediaAssets => Set<MediaAsset>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
    public DbSet<ModifierGroup> ModifierGroups => Set<ModifierGroup>();
    public DbSet<ModifierOption> ModifierOptions => Set<ModifierOption>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationOutbox> NotificationOutboxes => Set<NotificationOutbox>();
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();
    public DbSet<OpeningHour> OpeningHours => Set<OpeningHour>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductAllergen> ProductAllergens => Set<ProductAllergen>();
    public DbSet<ProductDietaryTag> ProductDietaryTags => Set<ProductDietaryTag>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<ReservationPolicy> ReservationPolicies => Set<ReservationPolicy>();
    public DbSet<ReservationStatusHistory> ReservationStatusHistories => Set<ReservationStatusHistory>();
    public DbSet<ReservationTable> ReservationTables => Set<ReservationTable>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<SiteSetting> SiteSettings => Set<SiteSetting>();
    public DbSet<SpecialClosure> SpecialClosures => Set<SpecialClosure>();
    public DbSet<TableCombination> TableCombinations => Set<TableCombination>();
    public DbSet<TaxRule> TaxRules => Set<TaxRule>();
    public DbSet<UserBranch> UserBranches => Set<UserBranch>();
    public DbSet<WaitlistEntry> WaitlistEntries => Set<WaitlistEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global soft-delete filter for BaseEntity-derived entities.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(AppDbContext).GetMethod(nameof(ApplySoftDeleteFilter), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)!
                    .MakeGenericMethod(entityType.ClrType);
                method.Invoke(null, new object[] { modelBuilder });
            }
        }
    }

    private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : BaseEntity
    {
        builder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
    }
}