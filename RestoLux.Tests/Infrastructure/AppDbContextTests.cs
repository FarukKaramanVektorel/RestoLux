using Microsoft.EntityFrameworkCore;
using RestoLux.Domain.Entities;
using RestoLux.Infrastructure.Data;

namespace RestoLux.Tests.Infrastructure;

public class AppDbContextTests
{
    [Fact]
    public async Task CanAddAndQueryRestaurant()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var ctx = new AppDbContext(options);
        ctx.Restaurants.Add(new Restaurant { Name = "InMemory Rest" });
        await ctx.SaveChangesAsync();

        var count = await ctx.Restaurants.CountAsync();
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task SoftDeleteFilter_ExcludesDeleted()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var ctx = new AppDbContext(options);
        ctx.Restaurants.Add(new Restaurant { Name = "A", IsDeleted = true });
        ctx.Restaurants.Add(new Restaurant { Name = "B" });
        await ctx.SaveChangesAsync();

        var count = await ctx.Restaurants.CountAsync();
        Assert.Equal(1, count);
    }
}