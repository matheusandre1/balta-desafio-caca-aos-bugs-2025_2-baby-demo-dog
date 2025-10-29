using AutoMapper;
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Utils;
using BugStore.Domain.Base;
using BugStore.Domain.Models;

namespace BugStore.Application.Services.Customers.Services;
public class CustomerService(IRepository<Customer> _customerRepository, IMapper _mapper) : ICustomerService
{
    public async Task CreateAsync(CustomerDtoRequest customerRequest)
    {
        var entity = _mapper.Map<Customer>(customerRequest);

        entity = CustomerMethods.CreateCustomer(customerRequest);

        await _customerRepository.AddAsync(entity);
    }
    public async Task<CustomerDto> GetByIdAsync(Guid id)
    {
        var entity = await _customerRepository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new Exception("Customer not found");
        }
        return _mapper.Map<CustomerDto>(entity);
    }   

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var entities = await _customerRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<CustomerDto>>(entities);
    }

    public async Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerDtoRequest customerDtoRequest)
    {
        var customer = _customerRepository.GetByIdAsync(id);
        if (customer is null) throw new Exception("Customer not found");

        await _mapper.Map(customerDtoRequest, customer);

        await _customerRepository.UpdateAsync(customer.Result);

        return _mapper.Map<CustomerDto>(customer);

    }
    public async Task<CustomerDto> DeleteCustomerAsync(Guid id)
    {
        var customer = _customerRepository.GetByIdAsync(id);

        if (customer is null) throw new Exception("Customer not found");

        await _customerRepository.DeleteAsync(id);

        return _mapper.Map<CustomerDto>(customer);
    }
}
