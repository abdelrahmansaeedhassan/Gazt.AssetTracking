using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Repositories
{
    public class ZoneRepository : RepositoryBase<Zone>, IZoneRepository
    {
        public ZoneRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IZoneRepository : Infrastructure.IRepository<Zone>
    {
    }
}
