using BugStore.Application.Services.Customer.Dto;
using BugStore.Application.Services.Product.Dto.Request;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;

namespace BugStore.Application.Services.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid id);
    Task CreateAsync(ProductDtoRequest customerRequest);
    Task<ProductDto> UpdateAgendaAsync(Guid id, ProductDtoRequest dto);
    Task<ProductDto> DeleteAgendaAsync(Guid id);
}
