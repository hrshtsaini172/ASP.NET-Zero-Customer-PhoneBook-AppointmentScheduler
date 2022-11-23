using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}