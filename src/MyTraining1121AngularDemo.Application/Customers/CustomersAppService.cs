using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Customers.Dto;
using MyTraining1121AngularDemo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Customers)]
    public class CustomersAppService : MyTraining1121AngularDemoAppServiceBase, ICustomersAppService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerUsers, long> _customerUsersRepository;
        private readonly IRepository<User, long> _userRepository;

        public CustomersAppService(IRepository<Customer> customerRepository,
            IRepository<CustomerUsers, long> customerUsersRepository,
            IRepository<User, long> userRepository)
        {
            _customerRepository = customerRepository;
            _customerUsersRepository = customerUsersRepository;
            _userRepository = userRepository;
        }

        public async Task<PagedResultDto<CustomersListDto>> GetCustomers(GetCustomersInput input)
        {
            try
            {
                var query = _customerRepository.GetAll()
                                    .WhereIf(!input.Filter.IsNullOrEmpty(),
                                            p => p.Name.Contains(input.Filter) ||
                                                    p.Address.Contains(input.Filter) ||
                                                    p.Email.Contains(input.Filter))
                                        .OrderByDescending(p => p.RegistrationDate)
                                        .ThenBy(p => p.Name);

                var customerCount = await query.CountAsync();
                var customers = await query.PageBy(input).ToListAsync();
                return new PagedResultDto<CustomersListDto>(customerCount, ObjectMapper.Map<List<CustomersListDto>>(customers));
            }
            catch (Exception e)
            {
                return new PagedResultDto<CustomersListDto>();
            }
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_CreateCustomer)]
        public async Task CreateCustomer(CreateCustomerInput input)
        {
            var customer = ObjectMapper.Map<Customer>(input);
            await _customerRepository.InsertAsync(customer);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_DeleteCustomer)]
        public async Task DeleteCustomer(EntityDto input)
        {
            await _customerUsersRepository.DeleteAsync(x => x.CustomerId == input.Id);
            await _customerRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_EditCustomer)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            var customer = await _customerRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetCustomerForEditOutput>(customer);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_EditCustomer)]
        [UnitOfWork(isTransactional: false)]
        public async Task EditCustomer(EditCustomerInput input)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(input.Id);
                customer.Name = input.Name;
                customer.Address = input.Address;
                customer.Email = input.Email;
                Thread.Sleep(1000);
                customer.RegistrationDate = input.RegistrationDate;
                await _customerRepository.UpdateAsync(customer);
            }
            catch (Exception e)
            {

            }
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_AddCustomerUsers)]
        public async Task<List<UserListDropdownDto>> GetUsersForAssignToCustomer()
        {
            var customerUsers = _customerUsersRepository.GetAll().Select(x => x.UserId);
            var users = await _userRepository.GetAll().Where(x => !customerUsers.Contains(x.Id)).Select(x => new UserListDropdownDto { Id = x.Id, FullName = x.FullName }).ToListAsync();
            return users;
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_AddCustomerUsers)]
        public async Task AssignUserToCustomer(AssignUserToCustomerInput input)
        {
            var customer = _customerRepository.Get(input.CustomerId);
            await _customerRepository.EnsureCollectionLoadedAsync(customer, p => p.CustomerUsers);

            var customerUser = ObjectMapper.Map<CustomerUsers>(input);
            customer.CustomerUsers.Add(customerUser);
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_DeleteCustomerUsers)]
        public async Task DeleteCustomerUser(EntityDto input)
        {
            await _customerUsersRepository.DeleteAsync(input.Id);
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Customers_ViewCustomerUsers)]
        public async Task<PagedResultDto<CustomerUsersListDto>> GetCustomerUsers(GetCustomerUsersInput input)
        {
            try
            {
                var query = _customerUsersRepository.GetAll().Where(x => x.CustomerId == input.CustomerId)
                                    .Include(x => x.User)
                                    .WhereIf(!input.Filter.IsNullOrEmpty(),
                                            p => p.User.Name.Contains(input.Filter) ||
                                                    p.User.Surname.Contains(input.Filter) ||
                                                    p.User.EmailAddress.Contains(input.Filter))
                                        .OrderBy(p => p.User.Name)
                                        .ThenBy(p => p.User.Surname);

                var customerUsersCount = await query.CountAsync();
                var customerUsers = await query.PageBy(input).ToListAsync();
                return new PagedResultDto<CustomerUsersListDto>(customerUsersCount, ObjectMapper.Map<List<CustomerUsersListDto>>(customerUsers));
            }
            catch (Exception e)
            {
                return new PagedResultDto<CustomerUsersListDto>();
            }
        }

    }
}
