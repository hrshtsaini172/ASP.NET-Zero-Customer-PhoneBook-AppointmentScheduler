using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1121AngularDemo.Appointments.Dto
{
    public class EditAppointmentInput : FullAuditedEntityDto
    {
        [Required]
        [MaxLength(AppointmentConsts.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(AppointmentConsts.MaxAddressLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(AppointmentConsts.MaxNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public DateTime FromTime { get; set; }

        [Required]
        public DateTime ToTime { get; set; }

    }
}
