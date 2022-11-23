using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class EditCustomerInput : FullAuditedEntity
    {
        [Required]
        [MaxLength(CustomerConsts.MaxNameLength)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(CustomerConsts.MaxEmailLength)]
        public string Email { get; set; }

        [MaxLength(CustomerConsts.MaxAddressLength)]
        public string Address { get; set; }

        public DateTime? RegistrationDate { get; set; }


    }
}
