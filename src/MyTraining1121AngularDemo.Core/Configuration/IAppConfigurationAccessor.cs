using Microsoft.Extensions.Configuration;

namespace MyTraining1121AngularDemo.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
