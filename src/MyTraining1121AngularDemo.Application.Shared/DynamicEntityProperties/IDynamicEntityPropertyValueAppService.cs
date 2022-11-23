using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.DynamicEntityProperties.Dto;
using MyTraining1121AngularDemo.DynamicEntityPropertyValues.Dto;

namespace MyTraining1121AngularDemo.DynamicEntityProperties
{
    public interface IDynamicEntityPropertyValueAppService
    {
        Task<DynamicEntityPropertyValueDto> Get(int id);

        Task<ListResultDto<DynamicEntityPropertyValueDto>> GetAll(GetAllInput input);

        Task Add(DynamicEntityPropertyValueDto input);

        Task Update(DynamicEntityPropertyValueDto input);

        Task Delete(int id);

        Task<GetAllDynamicEntityPropertyValuesOutput> GetAllDynamicEntityPropertyValues(GetAllDynamicEntityPropertyValuesInput input);
    }
}
