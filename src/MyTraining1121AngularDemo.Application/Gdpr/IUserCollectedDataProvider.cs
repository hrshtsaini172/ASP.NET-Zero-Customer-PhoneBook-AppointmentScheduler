using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
