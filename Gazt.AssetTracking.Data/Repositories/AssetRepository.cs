
using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data;
using Gazt.AssetTracking.Data.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Repositories
{
    public class AssetRepository : RepositoryBase<Asset>, IAssetRepository
    {
        public AssetRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IAssetRepository : Infrastructure.IRepository<Asset>
    {
    }
}
