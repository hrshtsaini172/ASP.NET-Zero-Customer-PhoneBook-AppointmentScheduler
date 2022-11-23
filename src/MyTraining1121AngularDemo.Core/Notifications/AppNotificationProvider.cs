using Abp.Authorization;
using Abp.Localization;
using Abp.Notifications;
using MyTraining1121AngularDemo.Authorization;

namespace MyTraining1121AngularDemo.Notifications
{
    public class AppNotificationProvider : NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.NewUserRegistered,
                    displayName: L("NewUserRegisteredNotificationDefinition"),
                    permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Administration_Users)
                    )
                );

            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.NewTenantRegistered,
                    displayName: L("NewTenantRegisteredNotificationDefinition"),
                    permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Tenants)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyTraining1121AngularDemoConsts.LocalizationSourceName);
        }
    }
}
