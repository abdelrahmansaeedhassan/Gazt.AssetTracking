using System.ComponentModel.DataAnnotations;
using Gazt.AssetTracking.Core.Domain;



namespace Gazt.AssetTracking.ViewModels
{
    public class RoleViewModel 
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "[|[Name]|]")]
        public string Name { get; set; }
    }
}