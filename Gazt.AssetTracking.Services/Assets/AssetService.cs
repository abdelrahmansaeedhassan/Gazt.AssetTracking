using AutoMapper;
using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;
using Gazt.AssetTracking.Data.Repositories;
using Gazt.AssetTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Services.Assets
{
    // operations you want to expose
    public interface IAssetService
    {
        IEnumerable<AssetViewModel> FindAll();
        List<AssetViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search);

        AssetViewModel Find(int id);
        void DeleteAsset(int id);
        void CreateAsset(AssetViewModel assetViewModel);
        void SaveAsset();
    }

    public class AssetService : IAssetService
    {
        private readonly IAssetRepository assetsRepository;
       
        private readonly IUnitOfWork unitOfWork;

        public AssetService(IAssetRepository assetsRepository, IUnitOfWork unitOfWork)
        {
            this.assetsRepository = assetsRepository;
            
            this.unitOfWork = unitOfWork;
        }

        public List<AssetViewModel> FindAll(string sortColumn, string sortColumnDir, int skip, int pageSize, ref int totalRecords, string search)
        {
            var assets = (from asset in assetsRepository.Querable().Include(f=>f.Zone).Include(m=>m.AssetModel)
                            where (
                    asset.SerialNumber.Contains(search)
                    )
                            select asset);

            totalRecords = assets.Count();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                if (sortColumnDir == "asc")
                {
                    assets = assets.OrderBy(sortColumn);
                }
                else
                {
                    assets = assets.OrderByDescending(sortColumn);
                }

            }
            return assets.Skip(skip).Take(pageSize).ToList().Select(asset => Mapper.Map<Asset,AssetViewModel>(asset)).ToList();
        }

        public IEnumerable<AssetViewModel> FindAll ()
        {
            var assets = assetsRepository.GetAll().Select(asset=>Mapper.Map<Asset,AssetViewModel>(asset));
            return assets;
        }

    
        public AssetViewModel Find(int id)
        {
            var asset = assetsRepository.Querable().Include(f => f.Zone).Include(y => y.Zone.Location).Include(m => m.AssetModel)
                .FirstOrDefault(item => item.Id == id);
            return Mapper.Map<Asset, AssetViewModel>(asset);
        }

        public void CreateAsset(AssetViewModel assetViewModel)
        {
            if (assetViewModel.Id>0)
            {
                assetsRepository.Update(Mapper.Map<AssetViewModel, Asset>(assetViewModel));
            }
            else
            {
                assetsRepository.Add(Mapper.Map<AssetViewModel, Asset>(assetViewModel));

            }
            SaveAsset();
        }

        public void SaveAsset()
        {
            unitOfWork.Commit();
        }

        public void DeleteAsset(int id)
        {
            var asset = assetsRepository.GetById(id);
            assetsRepository.Delete(asset);
            SaveAsset();
        }
    }
}
