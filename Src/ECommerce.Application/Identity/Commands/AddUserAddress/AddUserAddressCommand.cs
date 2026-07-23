using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.AddUserAddress;

public sealed record AddUserAddressCommand(
    string Label,
    string RecipientFirstName,
    string RecipientLastName,
    string PhoneNumber,
    string Country,
    string City,
    string Street,
    string PostalCode,
    bool IsDefaultShipping = false,
    bool IsDefaultBilling = false) : ICommand<Result<UserAddressResponse>>;
