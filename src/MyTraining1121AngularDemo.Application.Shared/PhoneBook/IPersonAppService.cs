using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.PhoneBook.Dto;
using System.Threading.Tasks;

namespace Acme.PhoneBookDemo.PhoneBook
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(EntityDto input);

        Task DeletePhone(EntityDto<long> input);

        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);

        Task EditPerson(EditPersonInput input);
    }
}
