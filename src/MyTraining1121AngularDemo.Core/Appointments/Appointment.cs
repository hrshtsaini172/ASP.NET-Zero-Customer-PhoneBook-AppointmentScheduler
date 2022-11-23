using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTraining1121AngularDemo.Appointments
{
    [Table("Appointments")]
    public class Appointment : FullAuditedEntity , IMustHaveTenant
    {      
        [Required]
        [MaxLength(AppointmentConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [MaxLength(AppointmentConsts.MaxAddressLength)]
        public virtual string Address { get; set; }

        [Required]
        [MaxLength(AppointmentConsts.MaxNumberLength)]
        public virtual string PhoneNumber { get; set; }

        [Required]
        public virtual DateTime AppointmentDate { get; set; }

        [Required]
        public virtual DateTime FromTime { get; set; }

        [Required]
        public virtual DateTime ToTime { get; set; }

        public virtual bool SMSStatus { get; set; }

        public virtual int TenantId { get; set; }

    }
}
