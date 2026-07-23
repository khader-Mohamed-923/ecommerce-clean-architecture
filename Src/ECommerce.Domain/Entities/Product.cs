using ECommerce.Domain.Errors;
using ECommerce.Domain.Shared;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public const int MaxNameLength = 100;
    public const int MaxDescriptionLength = 1000;
    public const int MaxPictureUrlLength = 500;

    private Product() { } // EF Core

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string PictureUrl { get; private set; } = string.Empty;

    public Guid ProductTypeId { get; private set; }
    public ProductType ProductType { get; private set; } = null!;

    public Guid ProductBrandId { get; private set; }
    public ProductBrand ProductBrand { get; private set; } = null!;


    public static Result<Product> Create(
        Guid id,
        string name,
        string description,
        string pictureUrl,
        decimal price,
        Guid productBrandId,
        Guid productTypeId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result<Product>.Failure(ProductErrors.InvalidName);

        if (name.Length > MaxNameLength)
            return Result<Product>.Failure(ProductErrors.NameTooLong);

        if (string.IsNullOrWhiteSpace(description))
            return Result<Product>.Failure(ProductErrors.InvalidDescription);

        if (description.Length > MaxDescriptionLength)
            return Result<Product>.Failure(ProductErrors.DescriptionTooLong);

        if (string.IsNullOrWhiteSpace(pictureUrl))
            return Result<Product>.Failure(ProductErrors.InvalidPictureUrl);

        if (pictureUrl.Length > MaxPictureUrlLength)
            return Result<Product>.Failure(ProductErrors.PictureUrlTooLong);

        if (price <= 0)
            return Result<Product>.Failure(ProductErrors.InvalidPrice);

        if (productBrandId == Guid.Empty)
            return Result<Product>.Failure(ProductErrors.InvalidBrand);

        if (productTypeId == Guid.Empty)
            return Result<Product>.Failure(ProductErrors.InvalidType);

        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price,
            PictureUrl = pictureUrl,
            ProductTypeId = productTypeId,
            ProductBrandId = productBrandId
        };

        return Result<Product>.Success(product);
    }


    public Result Update(
        string name,
        string description,
        decimal price,
        string pictureUrl,
        Guid productTypeId,
        Guid productBrandId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure(ProductErrors.InvalidName);

        if (name.Length > MaxNameLength)
            return Result.Failure(ProductErrors.NameTooLong);

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure(ProductErrors.InvalidDescription);

        if (description.Length > MaxDescriptionLength)
            return Result.Failure(ProductErrors.DescriptionTooLong);

        if (string.IsNullOrWhiteSpace(pictureUrl))
            return Result.Failure(ProductErrors.InvalidPictureUrl);

        if (pictureUrl.Length > MaxPictureUrlLength)
            return Result.Failure(ProductErrors.PictureUrlTooLong);

        if (price <= 0)
            return Result.Failure(ProductErrors.InvalidPrice);

        if (productTypeId == Guid.Empty)
            return Result.Failure(ProductErrors.InvalidType);

        if (productBrandId == Guid.Empty)
            return Result.Failure(ProductErrors.InvalidBrand);

        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductTypeId = productTypeId;
        ProductBrandId = productBrandId;

        return Result.Success();
    }
}