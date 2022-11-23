using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Customers.Dto;
using MyTraining1121AngularDemo.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    public interface ICustomersAppService : IApplicationService
    {
        Task<PagedResultDto<CustomersListDto>> GetCustomers(GetCustomersInput input);
        Task CreateCustomer(CreateCustomerInput input);
        Task DeleteCustomer(EntityDto input);
        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);
        Task EditCustomer(EditCustomerInput input);
        Task<List<UserListDropdownDto>> GetUsersForAssignToCustomer();
        Task AssignUserToCustomer(AssignUserToCustomerInput input);
        Task DeleteCustomerUser(EntityDto input);
        Task<PagedResultDto<CustomerUsersListDto>> GetCustomerUsers(GetCustomerUsersInput input);
    }
}
