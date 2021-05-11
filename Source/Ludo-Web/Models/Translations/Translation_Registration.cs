using System.ComponentModel.DataAnnotations;

namespace Ludo_Web.Models.Translations
{
    public record Translation_Registration
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName
        {
            get;
            set;
        }
    }
}