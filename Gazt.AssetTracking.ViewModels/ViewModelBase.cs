using System.ComponentModel.DataAnnotations;

namespace Gazt.AssetTracking.ViewModels.Infrastructure
{
    public abstract class ViewModelBase
    {
        public ViewModelBase()
        {
            this.Error = new ErrorModel();
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public ErrorModel Error { get; set; }
    }

    public class ErrorModel
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}