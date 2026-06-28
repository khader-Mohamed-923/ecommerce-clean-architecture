using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.Dtos;

public record ProductDto
(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string ImageUrl,
    string Brand,
    string Type
);  
