using MyTraining1121AngularDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Appointments.Dto
{
    public class GetUpcomingAppointmentsInput : PagedInputDto
    {
        public string Filter { get; set; }
    }
}
