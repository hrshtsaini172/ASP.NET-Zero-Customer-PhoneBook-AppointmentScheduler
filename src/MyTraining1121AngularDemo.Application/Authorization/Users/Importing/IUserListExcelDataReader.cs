using System.Collections.Generic;
using MyTraining1121AngularDemo.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace MyTraining1121AngularDemo.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
