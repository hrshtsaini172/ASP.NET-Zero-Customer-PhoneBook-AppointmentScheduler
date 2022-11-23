using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MyTraining1121AngularDemo.Common;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Organizations.Dto
{
    public class GetOrganizationUnitUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "user.Name, user.Surname";
            }

            Sorting = DtoSortingHelper.ReplaceSorting(Sorting, s =>
            {
                if (s.Contains("userName"))
                {
                    s = s.Replace("userName", "user.userName");
                }

                if (s.Contains("addedTime"))
                {
                    s = s.Replace("addedTime", "ouUser.creationTime");
                }

                return s;
            });
        }
    }
}
