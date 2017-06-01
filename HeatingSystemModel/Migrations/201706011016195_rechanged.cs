namespace HeatingSystemModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rechanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeterReadings", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.MeterReadings", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeterReadings", "Year", c => c.DateTime(nullable: false));
            DropColumn("dbo.MeterReadings", "Date");
        }
    }
}
