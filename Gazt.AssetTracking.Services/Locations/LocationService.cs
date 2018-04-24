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
    public interface ILocationService
    {
        List<LocationViewModel> FindAll();
        List<LocationViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search);

        LocationViewModel Find(int id);
        void CreateLocation(LocationViewModel locationViewModel);
        void SaveLocation();
    }

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        private readonly IUnitOfWork unitOfWork;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            this.locationRepository = locationRepository;

            this.unitOfWork = unitOfWork;
        }

        public List<LocationViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search)
        {
            var locations = (from location in locationRepository.Querable()
                          where (
                  location.NameAr.Contains(search)
                  )
                          select location);

            totalRecords = locations.Count();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                if (sortColumnDir == "asc")
                {
                    locations = locations.OrderBy(sortColumn);
                }
                else
                {
                    locations = locations.OrderByDescending(sortColumn);
                }

            }
            return locations.Skip(skip).Take(pageSize).ToList().Select(location => Mapper.Map<Location, LocationViewModel>(location)).ToList();
        }

   

        public LocationViewModel Find(int id)
        {
            var location = locationRepository.GetById(id);
            return Mapper.Map<Location, LocationViewModel>(location);
        }

        public void CreateLocation(LocationViewModel locationViewModel)
        {
            locationRepository.Add(Mapper.Map<LocationViewModel, Location>(locationViewModel));
        }

        public void SaveLocation()
        {
            unitOfWork.Commit();
        }

        public List<LocationViewModel> FindAll()
        {
            var locations = locationRepository.GetAll().Select(location=> Mapper.Map<Location, LocationViewModel>(location)).ToList();
            return locations;
        }
    }
}
