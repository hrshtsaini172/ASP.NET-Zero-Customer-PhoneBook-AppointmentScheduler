using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityProperties;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using Acme.PhoneBookDemo.PhoneBook;
using AutoMapper;
using IdentityServer4.Extensions;
using MyTraining1121AngularDemo.Appointments;
using MyTraining1121AngularDemo.Appointments.Dto;
using MyTraining1121AngularDemo.Auditing.Dto;
using MyTraining1121AngularDemo.Authorization.Accounts.Dto;
using MyTraining1121AngularDemo.Authorization.Delegation;
using MyTraining1121AngularDemo.Authorization.Permissions.Dto;
using MyTraining1121AngularDemo.Authorization.Roles;
using MyTraining1121AngularDemo.Authorization.Roles.Dto;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Authorization.Users.Delegation.Dto;
using MyTraining1121AngularDemo.Authorization.Users.Dto;
using MyTraining1121AngularDemo.Authorization.Users.Importing.Dto;
using MyTraining1121AngularDemo.Authorization.Users.Profile.Dto;
using MyTraining1121AngularDemo.Chat;
using MyTraining1121AngularDemo.Chat.Dto;
using MyTraining1121AngularDemo.Customers;
using MyTraining1121AngularDemo.Customers.Dto;
using MyTraining1121AngularDemo.DynamicEntityProperties.Dto;
using MyTraining1121AngularDemo.Editions;
using MyTraining1121AngularDemo.Editions.Dto;
using MyTraining1121AngularDemo.Friendships;
using MyTraining1121AngularDemo.Friendships.Cache;
using MyTraining1121AngularDemo.Friendships.Dto;
using MyTraining1121AngularDemo.Localization.Dto;
using MyTraining1121AngularDemo.MultiTenancy;
using MyTraining1121AngularDemo.MultiTenancy.Dto;
using MyTraining1121AngularDemo.MultiTenancy.HostDashboard.Dto;
using MyTraining1121AngularDemo.MultiTenancy.Payments;
using MyTraining1121AngularDemo.MultiTenancy.Payments.Dto;
using MyTraining1121AngularDemo.Notifications.Dto;
using MyTraining1121AngularDemo.Organizations.Dto;
using MyTraining1121AngularDemo.PhoneBook;
using MyTraining1121AngularDemo.PhoneBook.Dto;
using MyTraining1121AngularDemo.Sessions.Dto;
using MyTraining1121AngularDemo.WebHooks.Dto;

namespace MyTraining1121AngularDemo
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();


            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicProperty, DynamicPropertyDto>().ReverseMap();
            configuration.CreateMap<DynamicPropertyValue, DynamicPropertyValueDto>().ReverseMap();
            configuration.CreateMap<DynamicEntityProperty, DynamicEntityPropertyDto>()
                .ForMember(dto => dto.DynamicPropertyName,
                    options => options.MapFrom(entity => entity.DynamicProperty.DisplayName.IsNullOrEmpty() ? entity.DynamicProperty.PropertyName : entity.DynamicProperty.DisplayName));
            configuration.CreateMap<DynamicEntityPropertyDto, DynamicEntityProperty>();

            configuration.CreateMap<DynamicEntityPropertyValue, DynamicEntityPropertyValueDto>().ReverseMap();
            
            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */

            //PhoneBook
            configuration.CreateMap<Person, PersonListDto>();
            configuration.CreateMap<CreatePersonInput, Person>();
            configuration.CreateMap<Phone, PhoneInPersonListDto>();
            configuration.CreateMap<AddPhoneInput, Phone>();
            configuration.CreateMap<Person, GetPersonForEditOutput>();

            //Customers
            configuration.CreateMap<Customer, CustomersListDto>();
            configuration.CreateMap<CreateCustomerInput, Customer>();
            configuration.CreateMap<Customer, GetCustomerForEditOutput>();
            configuration.CreateMap<AssignUserToCustomerInput, CustomerUsers>();
            configuration.CreateMap<User, CustomerUsersListDto>();
            configuration.CreateMap<CustomerUsers, CustomerUsersListDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(x => x.User.Name))
                .ForMember(dto => dto.Surname, options => options.MapFrom(x => x.User.Surname))
                .ForMember(dto => dto.EmailAddress, options => options.MapFrom(x => x.User.EmailAddress));

            //Appointments
            configuration.CreateMap<Appointment, AppointmentsListDto>();
            configuration.CreateMap<Appointment, UpcomingAppointmentsListDto>();
            configuration.CreateMap<Appointment, CancelledAppointmentsListDto>();
            configuration.CreateMap<CreateAppointmentInput, Appointment>();
            configuration.CreateMap<Appointment, GetAppointmentForEditOutput>();
        }
    }
}
