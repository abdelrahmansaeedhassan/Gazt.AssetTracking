using System.ComponentModel.DataAnnotations;
using Gazt.AssetTracking.Core.Domain;


namespace Gazt.AssetTracking.ViewModels
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "[|[Email]|]")]
        public string Email { get; set; }

        [Required]
        
        [Display(Name = "[|[Username]|]")]
        public string Username { get; set; }

        [Display(Name = "[|[Password]|]")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "[|[Active]|]")]
        public bool IsActive { get; set; }

        [Display(Name = "[|[Person]|]", Order = 0)]
        [UIHint("PersonForeignKey")]
        public int? PersonId { get; set; }

       
    }
}