namespace HeatingSystemModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.MeterReadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kWh = c.Double(nullable: false),
                        CubeMeters = c.Double(nullable: false),
                        UsageHours = c.Double(nullable: false),
                        Year = c.DateTime(nullable: false),
                        isEnabled = c.Boolean(nullable: false),
                        Meter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meters", t => t.Meter_Id)
                .Index(t => t.Meter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeterReadings", "Meter_Id", "dbo.Meters");
            DropForeignKey("dbo.Meters", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.MeterReadings", new[] { "Meter_Id" });
            DropIndex("dbo.Meters", new[] { "Customer_Id" });
            DropTable("dbo.MeterReadings");
            DropTable("dbo.Meters");
            DropTable("dbo.Customers");
        }
    }
}
