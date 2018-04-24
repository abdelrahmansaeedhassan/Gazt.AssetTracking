using AutoMapper;
using Gazt.AssetTracking.Services.Assets;
using Gazt.AssetTracking.Services.Users;
using Gazt.AssetTracking.ViewModels;
using Glimpse.Core.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Gazt.AssetTracking.Portal.Infrastructure
{
    public static class SelectLists
    {
        private static readonly IMapper Mapper;

        static SelectLists()
        {
            Mapper = DependencyResolver.Current.GetService<IMapper>();
        }

 
  
       

       

        public static SelectList GetCostCenters()
        {
            var service = DependencyResolver.Current.GetService<IAssetService>();
            var data = service.FindAll();
            return Mapper.Map<IEnumerable<AssetViewModel>>(data).CreateSelectList(e => e.Id, e => e.SerialNumber);
        }
        public static SelectList GetAssetStatus()
        {
            SelectList list = new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Normal ", Value = "1"},
                        new SelectListItem { Text = "Disposed ", Value = "2"},
                         new SelectListItem { Text = "Split", Value = "3"},
                     }, "Value", "Text");
            return list;
        }
        

    

   
        public static SelectList GetAssetStatues()
        {
            return GetEnumSelectList<Core.Enums.AssetStatus>();
        }



        #region Helpers

        public static SelectList CreateSelectList<T>(this IEnumerable<T> entities, Func<T, object> value, Func<T, object> text)
        {
            var items = entities.Select(x => new SelectListItem
            {
                Value = value(x).ToString(),
                Text = text(x).ToString()
            });

            return new SelectList(items, "Value", "Text");
        }

        private static SelectList GetEnumSelectList<T>() where T : struct, IConvertible
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var items = Enum.GetValues(enumType).Cast<T>()
               .Select(i => new SelectListItem
               {
                   Text = ((Enum)(object)i).ToDescription(),
                   Value = ((int)((object)i)).ToString()
               });


            return new SelectList(items, "Value", "Text");
        }

        #endregion
    }
}