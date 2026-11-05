using Moq;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;
using RestoLux.Domain.Entities;
using RestoLux.Domain.Interfaces;

namespace RestoLux.Tests.Services;

public class RestaurantServiceTests
{
    private readonly Mock<IRepository<Restaurant>> _repo = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly RestaurantService _sut;

    public RestaurantServiceTests()
    {
        _sut = new RestaurantService(_repo.Object, _uow.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsMappedList()
    {
        _repo.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Restaurant> { new() { Id = 1, Name = "R1" }, new() { Id = 2, Name = "R2" } });

        var result = await _sut.GetAllAsync();

        Assert.Equal(2, result.Count);
        Assert.Equal("R1", result[0].Name);
    }

    [Fact]
    public async Task GetByIdAsync_NotFound_ReturnsNull()
    {
        _repo.Setup(r => r.GetByIdAsync(42, It.IsAny<CancellationToken>())).ReturnsAsync((Restaurant?)null);

        var result = await _sut.GetByIdAsync(42);

        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_AddsAndSaves()
    {
        _repo.Setup(r => r.AddAsync(It.IsAny<Restaurant>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant e, CancellationToken _) => e);

        var result = await _sut.CreateAsync(new CreateRestaurantDto("New Rest"));

        Assert.True(result.IsSuccess);
        Assert.Equal("New Rest", result.Value!.Name);
        _repo.Verify(r => r.AddAsync(It.IsAny<Restaurant>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_NotFound_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(7, It.IsAny<CancellationToken>())).ReturnsAsync((Restaurant?)null);

        var result = await _sut.UpdateAsync(7, new UpdateRestaurantDto("X", null, null, null, null, null, null, null, null, "TRY", "tr", true));

        Assert.False(result.IsSuccess);
        Assert.Equal("Restaurant not found.", result.Error);
    }

    [Fact]
    public async Task DeleteAsync_NotFound_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(7, It.IsAny<CancellationToken>())).ReturnsAsync((Restaurant?)null);

        var result = await _sut.DeleteAsync(7);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task DeleteAsync_Existing_SoftDeletesAndSaves()
    {
        var entity = new Restaurant { Id = 3, Name = "R" };
        _repo.Setup(r => r.GetByIdAsync(3, It.IsAny<CancellationToken>())).ReturnsAsync(entity);

        var result = await _sut.DeleteAsync(3);

        Assert.True(result.IsSuccess);
        Assert.True(entity.IsDeleted);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}