namespace BugStore.Application.Services.Interfaces;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(Guid id);
    Task CreateAsync (Customer)
}
