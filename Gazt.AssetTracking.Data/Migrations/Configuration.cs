namespace Gazt.AssetTracking.Data.Migrations
{
    using Gazt.AssetTracking.Core.Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gazt.AssetTracking.Data.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
   
        protected override void Seed(Gazt.AssetTracking.Data.ApplicationContext context)
        {
            context.Departments.AddOrUpdate(
                r => r.NameEn,
               new Department
               {
                   Id = 1,
                   NameEn = "Public Relation Section",
                   NameAr="قسم العلاقات العامه",
                   CreatedOn = new DateTime(2018,4,21,9,50,00),
                   CreatedBy = "Administrator"
               }
                );
            context.Locations.AddOrUpdate(
              r => r.NameEn,
             new Location
             {
                 Id = 1,
                 NameAr="المبنى الرئيسى",
                 NameEn = "Main Building",
                 CreatedOn = new DateTime(2018,4,21,9,50,00),
                 CreatedBy = "Administrator"
             }
              );
            context.Zones.AddOrUpdate(
          r => r.NameEn,
         new Zone
         {
             Id = 1,
             NameAr="المنطقه الرئيسيه",
             NameEn = "Main Zone",
             LocationId=1,
             CreatedOn = new DateTime(2018,4,21,9,50,00),
             CreatedBy = "Administrator"
         }
          );

            context.AssetModels.AddOrUpdate(
                r => r.NameEn,
               new AssetModel
               {
                   Id=1,
                   NameAr = "الأجهزه",
                   NameEn ="Machnine Series",
                  
                   CreatedOn = new DateTime(2018,4,21,9,50,00),
                   CreatedBy = "Administrator"
               }
                );

            context.Assets.AddOrUpdate(
                r => r.SerialNumber,
               new Asset
               {
                    ManufactureDate= new DateTime(2018,4,21,9,50,00),
                     IsAssigned=false,
                     IsPrinted=false,
                      Epc=Guid.NewGuid().ToString(),
                         AssetStatus=Core.Enums.AssetStatus.New,
                          ModelId=1,
                           DescriptionAr="TV LCD 17 INCH.",
                   DescriptionEn = "تلفاز ماركة (LG) 17 بوصة",
                   PurchaseDate =new DateTime(2018,4,21,9,50,00),
                             SerialNumber=Guid.NewGuid().ToString(),
                              ZoneId=1,
                               CreatedOn= new DateTime(2018,4,21,9,50,00),
                              CreatedBy="Administrator"

               },
                  new Asset
                  {
                      ManufactureDate = new DateTime(2018,4,21,9,50,00),
                      IsAssigned = false,
                      IsPrinted = false,
                      Epc = Guid.NewGuid().ToString(),
                      AssetStatus = Core.Enums.AssetStatus.New,
                      ModelId = 1,
                      DescriptionAr = "رافعة أوزان",
                      DescriptionEn = "Forklift weights",
                      PurchaseDate = new DateTime(2018,4,21,9,50,00),
                      SerialNumber = Guid.NewGuid().ToString(),
                      ZoneId = 1,
                      CreatedOn = new DateTime(2018,4,21,9,50,00),
                      CreatedBy = "Administrator"
                  }
                  
                );

            context.Roles.AddOrUpdate(
                   r => r.Name,
                   new Role { Name = "Super" },
                   new Role { Name = "Zones" },
                   new Role { Name = "Readers" },
                   new Role { Name = "Tags" },
                   new Role { Name = "Reports" },
                   new Role { Name = "Paths" },
                   new Role { Name = "Assets" },
                   new Role { Name = "Persons" },
                   new Role { Name = "Sessions" }
                   );

            var email = "abdelrahmansaeed1989@gmail.com";
            if (!context.Users.Any(u => u.Email == email))
            {
                var store = new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(context);
                var manager = new UserManager<User, int>(store);
                var admin = new User
                {

                    UserName = "AbdelrahmanSaeed",
                    Email = email,
                    IsActive = true,
                };

                manager.Create(admin, "abc123");
                manager.AddToRole(admin.Id, "Super");
            }
       
        }
    }
}
