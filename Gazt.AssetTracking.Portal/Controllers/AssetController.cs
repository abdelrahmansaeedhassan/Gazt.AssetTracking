using AutoMapper;
using Gazt.AssetTracking.Services;
using Gazt.AssetTracking.Services.Assets;
using Gazt.AssetTracking.Services.Locations;
using Gazt.AssetTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazt.AssetTracking.Portal.Controllers
{
    
    [Authorize]
    public class AssetController : Controller
    {
        private readonly IAssetService assetService;
        private readonly IZoneService zoneService;
        private ILocationService locationService;
        private readonly IAssetModelService assetModelService;
       
        public AssetController(IAssetService assetService,IZoneService zoneService,ILocationService locationService,IAssetModelService assetModelService)
        {
            this.assetService = assetService;
            this.zoneService = zoneService;
            this.locationService = locationService;
            this.assetModelService = assetModelService;
            
        }
        public ActionResult Index()
        {
            ViewBag.Locations = locationService.FindAll();
            ViewBag.AssetModels = assetModelService.FindAll();
            //var _assets = assetService.FindAll().Select(e=> Mapper.Map<AssetViewModel>(e)).ToList();
       
            return View();
        }
        public JsonResult FindZones(int locationId)
        {
            var zones = locationService.FindAll();
            return Json(zones, JsonRequestBehavior.AllowGet);
        }

       public JsonResult Find(int id)
        {
            var asset = assetService.Find(id);
            return Json(asset, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FindAll()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            var assets = assetService.FindAll(sortColumn, sortColumnDir, skip, pageSize, ref totalRecords, search);


            return Json(new
            {
                draw = draw,
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,
                data = assets

            }, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult Save(AssetViewModel assetViewModel)
        {
            if (assetViewModel.Id<=0)
            {
                assetViewModel.AssetStatus = Core.Enums.AssetStatus.New;
            }
            assetService.CreateAsset(assetViewModel);
            return Json(new { Type = "success", Message = "Asset Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            assetService.DeleteAsset(id);
            return Json(new { Type = "success", Message = "Asset Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
    }
}