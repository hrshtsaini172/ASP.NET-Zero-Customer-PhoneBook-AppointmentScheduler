using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class GetCustomerForEditOutput : FullAuditedEntityDto
    {
        public string Name { get; set;}
        public string Email { get; set;}
        public string Address { get; set;}
        public DateTime? RegistrationDate { get; set;}
    }
}
