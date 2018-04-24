using System.ComponentModel.DataAnnotations;
using Gazt.AssetTracking.Core.Domain;



namespace Gazt.AssetTracking.ViewModels
{
    public class UserRoleViewModel 
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "[|[Role]|]")]
        [UIHint("RemoteGridForeignKey")]
        public int RoleId { get; set; }
    }
}