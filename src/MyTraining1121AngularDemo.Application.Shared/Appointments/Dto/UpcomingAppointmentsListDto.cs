using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Appointments.Dto
{
    public class UpcomingAppointmentsListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
