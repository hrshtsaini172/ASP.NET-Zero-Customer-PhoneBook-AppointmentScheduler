using System.Threading.Tasks;
using MyTraining1121AngularDemo.Security.Recaptcha;

namespace MyTraining1121AngularDemo.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
