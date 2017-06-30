namespace Mas_Logistics_Company.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Pesel", c => c.String(nullable: false));
            AlterColumn("dbo.CarPersons", "Area", c => c.Int());
            AlterColumn("dbo.CarPersons", "Specialization", c => c.Int());
            AlterColumn("dbo.DriverTrucks", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DriverTrucks", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "PlateNumber", c => c.String(nullable: false));
            AlterColumn("dbo.OrderTrailers", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderTrailers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "StartLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Freights", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Docks", "DockSymbol", c => c.String(nullable: false));
            AlterColumn("dbo.Sectors", "SectorSymbol", c => c.String(nullable: false));
            AlterColumn("dbo.OrderTrucks", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderTrucks", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RepairTrailers", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RepairTrailers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Repairs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.RepairTrucks", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RepairTrucks", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Warehousemen", "MedicalCertificate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warehousemen", "MedicalCertificate", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.String());
            AlterColumn("dbo.RepairTrucks", "EndDate", c => c.DateTime());
            AlterColumn("dbo.RepairTrucks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Repairs", "Description", c => c.String());
            AlterColumn("dbo.RepairTrailers", "EndDate", c => c.DateTime());
            AlterColumn("dbo.RepairTrailers", "StartDate", c => c.DateTime());
            AlterColumn("dbo.OrderTrucks", "EndDate", c => c.DateTime());
            AlterColumn("dbo.OrderTrucks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Sectors", "SectorSymbol", c => c.String());
            AlterColumn("dbo.Docks", "DockSymbol", c => c.String());
            AlterColumn("dbo.Freights", "Description", c => c.String());
            AlterColumn("dbo.Orders", "StartLocation", c => c.String());
            AlterColumn("dbo.Orders", "Type", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "CustomerName", c => c.String());
            AlterColumn("dbo.OrderTrailers", "EndDate", c => c.DateTime());
            AlterColumn("dbo.OrderTrailers", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Vehicles", "PlateNumber", c => c.String());
            AlterColumn("dbo.DriverTrucks", "EndDate", c => c.DateTime());
            AlterColumn("dbo.DriverTrucks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.CarPersons", "Specialization", c => c.Int(nullable: false));
            AlterColumn("dbo.CarPersons", "Area", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "Pesel", c => c.String());
            AlterColumn("dbo.People", "PhoneNumber", c => c.String());
            AlterColumn("dbo.People", "Sex", c => c.String());
            AlterColumn("dbo.People", "Surname", c => c.String());
            AlterColumn("dbo.People", "Name", c => c.String());
            DropColumn("dbo.People", "Address");
        }
    }
}
