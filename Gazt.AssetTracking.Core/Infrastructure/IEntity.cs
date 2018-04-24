namespace Gazt.AssetTracking.Core.Infrastructure
{  
    public interface IEntity<T> 
   {
       T Id { get; set; }
   }
}
