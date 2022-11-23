using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}