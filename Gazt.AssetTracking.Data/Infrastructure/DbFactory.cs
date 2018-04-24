using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ApplicationContext dbContext;

        public ApplicationContext Init()
        {
            return dbContext ?? (dbContext = new ApplicationContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
