using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}