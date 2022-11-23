using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class CustomersListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public Collection<UsersInCustomerListDto> CustomerUsers { get; set; }

    }
    public class UsersInCustomerListDto : CreationAuditedEntityDto<long>
    {
        public long UserId { get; set; }
    }
}
