using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}