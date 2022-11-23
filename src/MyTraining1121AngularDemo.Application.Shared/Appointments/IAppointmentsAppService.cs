using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Appointments.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Appointments
{
    public interface IAppointmentsAppService : IApplicationService
    {
        Task<PagedResultDto<AppointmentsListDto>> GetAppointments(GetAppointmentsInput input);
        Task CreateAppointment(CreateAppointmentInput input);
        Task DeleteAppointment(EntityDto input);
        Task<GetAppointmentForEditOutput> GetAppointmentForEdit(GetAppointmentForEditInput input);
        Task EditAppointment(EditAppointmentInput input);
        Task<PagedResultDto<UpcomingAppointmentsListDto>> GetUpcomingAppointments(GetUpcomingAppointmentsInput input);
        Task<PagedResultDto<CancelledAppointmentsListDto>> GetCancelledAppointments(GetCancelledAppointmentsInput input);
        Task<PagedResultDto<AppointmentsListDto>> DeleteInvalid(GetAppointmentsInput input);
        Task<PagedResultDto<AppointmentsListDto>> SendSMSLatest();

    }
}
