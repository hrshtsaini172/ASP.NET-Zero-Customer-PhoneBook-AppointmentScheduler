using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Acme.PhoneBookDemo.PhoneBook;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.PhoneBook.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.PhoneBook
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]
    public class PersonAppService : MyTraining1121AngularDemoAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Phone, long> _phoneRepository;

        public PersonAppService(IRepository<Person> personRepository, IRepository<Phone, long> phoneRepository)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var people = _personRepository
                .GetAll()
                .Include(p => p.Phones)
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                         p.Surname.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(people));
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);
            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PhoneInPersonListDto>(phone);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetPersonForEditOutput>(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task EditPerson(EditPersonInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            person.Name = input.Name;
            person.Surname = input.Surname;
            person.EmailAddress = input.EmailAddress;
            await _personRepository.UpdateAsync(person);
        }
    }
}
