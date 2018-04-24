using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Core.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data
{
    public class ApplicationContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>,
        IDbContext
    {
        public ApplicationContext()
               : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false; 
        }

        public virtual void Commit()
        {
            var modifiedEntries = ChangeTracker.Entries()
      .Where(x => x.Entity is IAuditableEntity
          && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;

                if (entity == null) continue;

                string identityName = Thread.CurrentPrincipal.Identity.Name;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName;
                    entity.CreatedOn = now;
                }
                else
                {
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                }

                entity.UpdatedBy = identityName;
                entity.UpdatedOn = now;
            }

         
            base.SaveChanges();
        }
        public override DbSet Set(Type entityType)
        {
            return base.Set(entityType);
        }
        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

        //Adding model configurations
        var configurationTypes = typeof(UserConfiguration).Assembly.GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                       && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in configurationTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            //Removing pluralized naming convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //Rename Identity tables
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");

         
        }

        public IDbSet<Asset> Assets { get; set; }
        public IDbSet<AssetModel> AssetModels { get; set; }
        public IDbSet<AssetTrackingHistory> AssetsTrackingHistory { get; set; }
        public IDbSet<EmployeeAsset> EmployeeAssets { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Zone> Zones { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Department> Departments { get; set; }
      
     
    }
}
