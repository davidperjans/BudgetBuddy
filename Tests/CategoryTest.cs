using Microsoft.EntityFrameworkCore;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Application.DTOs;
using AutoMapper;
using FluentValidation;
using Domain.Entities;

namespace Tests;

public class CategoryServiceTests
{
    [Test]
    public async Task CreateAsync_ShouldReturnSuccess_WhenValid()
    {
        // Setup in-memory EF Core
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("CategoryTestDb")
            .Options;
        var context = new AppDbContext(options);

        // AutoMapper config
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateCategoryDto, Category>();
            cfg.CreateMap<Category, CategoryDto>();
        }).CreateMapper();

        // FluentValidation setup (inline)
        var validator = new InlineValidator<CreateCategoryDto>();
        validator.RuleFor(x => x.Name).NotEmpty();

        var repository = new CategoryRepository(context);


        // Arrange
        var category = new Category
        {
            CategoryId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Name = "Mat"
        };

        // Act
        await repository.AddAsync(category);

        // Assert
        var saved = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Mat");
        Assert.That(saved, Is.Not.Null);
        Assert.That(saved!.Name, Is.EqualTo("Mat"));

    }
}
