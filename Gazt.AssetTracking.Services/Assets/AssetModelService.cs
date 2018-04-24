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

namespace Gazt.AssetTracking.Services.Assets
{
    public interface IAssetModelService
    {
        List<AssetModelViewModel> FindAll();
        List<AssetModelViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search);

        AssetModelViewModel Find(int id);
      
        void CreateAssetModel(AssetModelViewModel assetModel);
        void SaveAssetModel();
    }

    public class AssetModelService : IAssetModelService
    {
        private readonly IAssetModelRepository assetModelRepository;

        private readonly IUnitOfWork unitOfWork;

        public AssetModelService(IAssetModelRepository assetModelRepository, IUnitOfWork unitOfWork)
        {
            this.assetModelRepository = assetModelRepository;

            this.unitOfWork = unitOfWork;
        }

        public List<AssetModelViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search)
        {
            var assetModels = (from assetModel in assetModelRepository.Querable()
                         where (
                 assetModel.NameAr.Contains(search)
                 )
                         select assetModel);

            totalRecords = assetModels.Count();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                if (sortColumnDir == "asc")
                {
                    assetModels = assetModels.OrderBy(sortColumn);
                }
                else
                {
                    assetModels = assetModels.OrderByDescending(sortColumn);
                }

            }
            return assetModels.Skip(skip).Take(pageSize).ToList().Select(assetModel => Mapper.Map<AssetModel, AssetModelViewModel>(assetModel)).ToList();
        }



        public AssetModelViewModel Find(int id)
        {
            var assetModel = assetModelRepository.GetById(id);
            return Mapper.Map<AssetModel, AssetModelViewModel>(assetModel);
        }

        public void CreateAssetModel(AssetModelViewModel assetModelViewModel)
        {
            assetModelRepository.Add(Mapper.Map<AssetModelViewModel, AssetModel>(assetModelViewModel));
        }

        public void SaveAssetModel()
        {
            unitOfWork.Commit();
        }

        public List<AssetModelViewModel> FindAll()
        {
            var assetModels = assetModelRepository.GetAll().Select(assetModel => Mapper.Map<AssetModel, AssetModelViewModel>(assetModel)).ToList();
            return assetModels;
        }

      
    }
}
