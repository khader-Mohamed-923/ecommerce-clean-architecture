using ECommerce.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Common.Interfaces;

public interface IAttachmentService
{
    Task<Result<string>> UploadAttachmentAsync(IFormFile file);
}
