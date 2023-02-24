using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MyTraining1121AngularDemo.Appointments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using MyTraining1121AngularDemo.Authorization;
using Abp.Domain.Uow;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MyTraining1121AngularDemo.Appointments
{
    public class AppointmentsAppService : MyTraining1121AngularDemoAppServiceBase, IAppointmentsAppService
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentsAppService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        //Create Appointment
        [AbpAuthorize(AppPermissions.Pages_Tenant_Appointments_CreateAppointment)]
        public async Task CreateAppointment(CreateAppointmentInput input)
        {
            input.FromTime = new DateTime(input.AppointmentDate.Year, input.AppointmentDate.Month, input.AppointmentDate.Day,
                    input.FromTime.Hour, input.FromTime.Minute, input.FromTime.Second);
            input.ToTime = new DateTime(input.AppointmentDate.Year, input.AppointmentDate.Month, input.AppointmentDate.Day,
                input.ToTime.Hour, input.ToTime.Minute, input.ToTime.Second);

            if (!_appointmentRepository.GetAll().Any(x => ((input.FromTime >= x.FromTime && input.FromTime <= x.ToTime) || (input.ToTime >= x.FromTime && input.ToTime <= x.ToTime))))
            {
                input.AppointmentDate = input.AppointmentDate.AddHours(6);
                var appointment = ObjectMapper.Map<Appointment>(input);
                appointment.SMSStatus = false;
                await _appointmentRepository.InsertAsync(appointment);
                SendSMS("Appointment successfully registered", input.PhoneNumber);
            }
        }

        //Delete Appointment
        [AbpAuthorize(AppPermissions.Pages_Tenant_Appointments_DeleteAppointment)]
        public async Task DeleteAppointment(EntityDto input)
        {
            await _appointmentRepository.DeleteAsync(input.Id);
        }

        //Get Appointment For Edit
        [AbpAuthorize(AppPermissions.Pages_Tenant_Appointments_EditAppointment)]
        public async Task<GetAppointmentForEditOutput> GetAppointmentForEdit(GetAppointmentForEditInput input)
        {
            var appointment = await _appointmentRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetAppointmentForEditOutput>(appointment);
        }


        //Edit Appointment
        [AbpAuthorize(AppPermissions.Pages_Tenant_Appointments_EditAppointment)]
        [UnitOfWork(isTransactional: false)]
        public async Task EditAppointment(EditAppointmentInput input)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(input.Id);
                appointment.Name = input.Name;
                appointment.Address = input.Address;
                appointment.PhoneNumber = input.PhoneNumber;

                appointment.AppointmentDate = input.AppointmentDate;
                appointment.FromTime = input.FromTime;
                appointment.ToTime = input.ToTime;

                await _appointmentRepository.UpdateAsync(appointment);
                SendSMS("Appointment successfully updated", input.PhoneNumber);

            }
            catch (Exception)
            {
                                
            }
        }    

        //Get All Appointments
        public async Task<PagedResultDto<AppointmentsListDto>> GetAppointments(GetAppointmentsInput input)
        {
            try
            {
                var query = _appointmentRepository.GetAll()
                                        .WhereIf(!input.Filter.IsNullOrEmpty(),
                                                 p => p.Name.Contains(input.Filter) ||
                                                        p.Address.Contains(input.Filter) ||
                                                        p.PhoneNumber.Contains(input.Filter))
                                        .OrderBy(p => p.AppointmentDate)
                                        .ThenBy(p => p.Name);

                var appointmentCount = await query.CountAsync();
                var appointments = await query.PageBy(input).ToListAsync();
                return new PagedResultDto<AppointmentsListDto>(appointmentCount, ObjectMapper.Map<List<AppointmentsListDto>>(appointments));
            }
            catch (Exception)
            {
                return new PagedResultDto<AppointmentsListDto>();
            }
        }

        //Get Upcoming Appointments
        public async Task<PagedResultDto<UpcomingAppointmentsListDto>> GetUpcomingAppointments(GetUpcomingAppointmentsInput input)
        {
            try
            {
                var query = _appointmentRepository.GetAll()
                                        .Where(p => p.AppointmentDate > DateTime.Now)
                                        .WhereIf(!input.Filter.IsNullOrEmpty(),
                                                p => p.Name.Contains(input.Filter) ||
                                                        p.Address.Contains(input.Filter) ||
                                                        p.PhoneNumber.Contains(input.Filter))
                                        .OrderBy(p => p.AppointmentDate)
                                        .ThenBy(p => p.Name);

                var appointmentCount = await query.CountAsync();
                var appointments = await query.PageBy(input).ToListAsync();
                return new PagedResultDto<UpcomingAppointmentsListDto>(appointmentCount, ObjectMapper.Map<List<UpcomingAppointmentsListDto>>(appointments));

            }
            catch (Exception)
            {
                return new PagedResultDto<UpcomingAppointmentsListDto>();
            }
        }

        //Get Cancelled Appointments
        public async Task<PagedResultDto<CancelledAppointmentsListDto>> GetCancelledAppointments(GetCancelledAppointmentsInput input)
        {
            try
            {
                var query = _appointmentRepository.GetAll().IgnoreQueryFilters()
                                        .Where(x => x.IsDeleted == true)
                                        .OrderBy(p => p.AppointmentDate)
                                        .ThenBy(p => p.Name);

                var appointmentCount = await query.CountAsync();
                var appointments = await query.PageBy(input).ToListAsync();
                return new PagedResultDto<CancelledAppointmentsListDto>(appointmentCount, ObjectMapper.Map<List<CancelledAppointmentsListDto>>(appointments));

            }
            catch (Exception)
            {
                return new PagedResultDto<CancelledAppointmentsListDto>();
            }
        }

        //Delete Invalid
        public async Task<PagedResultDto<AppointmentsListDto>> DeleteInvalid(GetAppointmentsInput input)
        {
            var appointments = await _appointmentRepository.GetAll().ToListAsync();

            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentDate < DateTime.Now)
                {
                    await _appointmentRepository.DeleteAsync(appointment.Id);
                }
            }
                        
            var allAppointments = await _appointmentRepository.GetAll().ToListAsync();

            List<Appointment> newappointments = new List<Appointment>();

                foreach (var appointment in allAppointments)
                {
                    if (appointment.IsDeleted)
                    {
                        newappointments.Add(appointment);
                    }
                }
                var count = newappointments.Count();
                return new PagedResultDto<AppointmentsListDto>
               (count, ObjectMapper.Map<List<AppointmentsListDto>>(newappointments));
        }


        //Send SMS
        public async Task<PagedResultDto<AppointmentsListDto>> SendSMSLatest()
        {
            var appointments = await _appointmentRepository.GetAllListAsync();
            List<Appointment> latestAppointment = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                System.TimeSpan diff1 = appointment.AppointmentDate.Subtract(DateTime.Now);
                System.TimeSpan diff2 = appointment.FromTime.Subtract(DateTime.Now);
                if (diff2.Hours <= 24 && diff2.Hours >= 0 && diff1.Days < 1 && diff1.Days >= 0)
                {
                    latestAppointment.Add(appointment);
                    if (appointment.SMSStatus == false)
                    {
                        string phone = appointment.PhoneNumber.ToString();
                        string msg = "Reminder: Hello " + appointment.Name + ", you have scheduled an appointment on " +
                             appointment.AppointmentDate + " at " + appointment.FromTime + ". Please reach on time. Thank you.";
                        SendSMS(msg, phone);
                        appointment.SMSStatus = true;
                    }
                }
            }
            var count = latestAppointment.Count();
            return new PagedResultDto<AppointmentsListDto>(count, ObjectMapper.Map<List<AppointmentsListDto>>(latestAppointment));

        }

        //SMS Twilio Function
        public void SendSMS(string msg, string phone)
        {
            string accountSID = Environment.GetEnvironmentVariable("<Enter your Twilio accountSID here>");
            string authToken = Environment.GetEnvironmentVariable("<Enter your Twilio authToken here>");
            TwilioClient.Init(username: "<Twilio accountSID>", password: "<Twilio authToken>");
            var mediaUrl = new[]
             { new Uri("https://demo.twilio.com/owl.png") }.ToList();
            var message = MessageResource.Create(body: msg,
                from: new Twilio.Types.PhoneNumber("<Twilio Phone number>"), mediaUrl: mediaUrl, to: new Twilio.Types.PhoneNumber($"{phone}"));
        }
    }
}
