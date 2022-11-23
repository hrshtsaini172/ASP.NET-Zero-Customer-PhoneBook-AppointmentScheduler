using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
