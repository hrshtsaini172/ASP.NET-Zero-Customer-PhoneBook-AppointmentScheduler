using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MyTraining1121AngularDemo.Common;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Organizations.Dto
{
    public class GetOrganizationUnitRolesInput : PagedAndSortedInputDto, IShouldNormalize
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "role.DisplayName, role.Name";
            }

            Sorting = DtoSortingHelper.ReplaceSorting(Sorting, s =>
            {
                if (s.Contains("displayName"))
                {
                    s = s.Replace("displayName", "role.displayName");
                }

                if (s.Contains("addedTime"))
                {
                    s = s.Replace("addedTime", "ouRole.creationTime");
                }

                return s;
            });
        }
    }
}
