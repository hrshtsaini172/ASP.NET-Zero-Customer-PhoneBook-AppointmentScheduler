using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("Customers")]
    public class Customer : FullAuditedEntity, IMustHaveTenant
    {
        [Required]
        [MaxLength(CustomerConsts.MaxNameLength)]
        public virtual string Name { get; set; }
        [Required]
        [MaxLength(CustomerConsts.MaxEmailLength)]
        public virtual string Email { get; set; }
        public virtual DateTime? RegistrationDate { get; set; }
        [MaxLength(CustomerConsts.MaxAddressLength)]
        public virtual string Address { get; set; }
        public virtual ICollection<CustomerUsers> CustomerUsers { get; set; }
        public virtual int TenantId { get; set; }
    }
}
