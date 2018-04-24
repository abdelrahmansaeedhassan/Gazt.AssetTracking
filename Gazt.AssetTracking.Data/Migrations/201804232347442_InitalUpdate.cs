namespace Gazt.AssetTracking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetModel", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Asset", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employee", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Department", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Nationality", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Location", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.AssetTrackingHistory", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.EmployeeAsset", "CreatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeAsset", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AssetTrackingHistory", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Location", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Nationality", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Department", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Asset", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AssetModel", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
