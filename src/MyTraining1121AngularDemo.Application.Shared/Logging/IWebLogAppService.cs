using Abp.Application.Services;
using MyTraining1121AngularDemo.Dto;
using MyTraining1121AngularDemo.Logging.Dto;

namespace MyTraining1121AngularDemo.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
