using System;
using Abp.Notifications;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}