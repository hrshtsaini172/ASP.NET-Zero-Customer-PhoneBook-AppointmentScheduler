using System.Collections.Generic;
using MyTraining1121AngularDemo.Authorization.Users.Importing.Dto;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
