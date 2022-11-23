using System.ComponentModel.DataAnnotations;
using Abp.Localization;

namespace MyTraining1121AngularDemo.Localization.Dto
{
    public class SetDefaultLanguageInput
    {
        [Required]
        [StringLength(ApplicationLanguage.MaxNameLength)]
        public virtual string Name { get; set; }
    }
}