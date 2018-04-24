using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface ILocationRepository : Infrastructure.IRepository<Location>
    {
    }
}
