using Abp.Domain.Entities.Auditing;
using MyTraining1121AngularDemo.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("CustomerUsers")]
    public class CustomerUsers : CreationAuditedEntity<long>
    {
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual int CustomerId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual long UserId { get; set; }

    }
}
