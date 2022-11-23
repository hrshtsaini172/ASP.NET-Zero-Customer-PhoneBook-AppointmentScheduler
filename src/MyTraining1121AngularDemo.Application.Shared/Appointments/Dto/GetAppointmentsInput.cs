using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Appointments.Dto
{
    public class GetAppointmentsInput : PagedInputDto
    {
        public string Filter { get; set; }
    }
}
