using AutoMapper;
using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;
using Gazt.AssetTracking.Data.Repositories;
using Gazt.AssetTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Services.Locations
{
    public interface IZoneService
    {
        IEnumerable<ZoneViewModel> FindAll();
        List<ZoneViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search);

        ZoneViewModel Find(int id);
        List<ZoneViewModel> FindByLocation(int locationId);
        void CreateZone(ZoneViewModel ZoneViewModel);
        void SaveZone();
    }

    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository zoneRepository;

        private readonly IUnitOfWork unitOfWork;

        public ZoneService(IZoneRepository zoneRepository, IUnitOfWork unitOfWork)
        {
            this.zoneRepository = zoneRepository;

            this.unitOfWork = unitOfWork;
        }

        public List<ZoneViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search)
        {
            var zones = (from zone in zoneRepository.Querable()
                             where (
                     zone.NameAr.Contains(search)
                     )
                             select zone);

            totalRecords = zones.Count();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                if (sortColumnDir == "asc")
                {
                    zones = zones.OrderBy(sortColumn);
                }
                else
                {
                    zones = zones.OrderByDescending(sortColumn);
                }

            }
            return zones.Skip(skip).Take(pageSize).ToList().Select(zone => Mapper.Map<Zone, ZoneViewModel>(zone)).ToList();
        }



        public ZoneViewModel Find(int id)
        {
            var zone = zoneRepository.GetById(id);
            return Mapper.Map<Zone, ZoneViewModel>(zone);
        }

        public void CreateZone(ZoneViewModel ZoneViewModel)
        {
            zoneRepository.Add(Mapper.Map<ZoneViewModel, Zone>(ZoneViewModel));
        }

        public void SaveZone()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ZoneViewModel> FindAll()
        {
            var zones = zoneRepository.GetAll().Select(zone => Mapper.Map<Zone, ZoneViewModel>(zone));
            return zones;
        }

        public List<ZoneViewModel> FindByLocation(int locationId)
        {
            var zones = zoneRepository.Querable().Where(zone => zone.LocationId == locationId).ToList()
                 .Select(zone => Mapper.Map<Zone, ZoneViewModel>(zone)).ToList();
            return zones;
        }
    }
}
