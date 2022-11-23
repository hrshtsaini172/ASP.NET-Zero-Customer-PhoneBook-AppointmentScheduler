using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace MyTraining1121AngularDemo.Net.Emailing
{
    public class MyTraining1121AngularDemoSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public MyTraining1121AngularDemoSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}