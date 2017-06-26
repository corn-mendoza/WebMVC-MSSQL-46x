namespace WebMVC461.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreasureMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Location = c.String(),
                        PhotoLink = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AcquiredDate = c.DateTime(nullable: false),
                        PurchaseFrom = c.String(),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Treasures");
        }
    }
}
