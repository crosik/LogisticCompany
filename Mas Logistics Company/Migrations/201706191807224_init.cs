using System.Data.Entity.Migrations;

namespace Mas_Logistics_Company.Migrations
{
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.People", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Sex = c.String(),
                        DateOfBirth = c.DateTime(),
                        PhoneNumber = c.String(),
                        Pesel = c.String()
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        BrokerId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.BrokerId)
                .ForeignKey("dbo.People", t => t.BrokerId, cascadeDelete: true)
                .Index(t => t.BrokerId);
            
            CreateTable(
                "dbo.CarPersons",
                c => new
                    {
                        CarPersonId = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                        Specialization = c.Int(nullable: false),
                        LevelOfExp = c.Int(nullable: false),
                        Group_GroupId = c.Int(),
                        Group_GroupId1 = c.Int(),
                        LeaderOfGroup_GroupId = c.Int()
                    })
                .PrimaryKey(t => t.CarPersonId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId1)
                .ForeignKey("dbo.Groups", t => t.LeaderOfGroup_GroupId)
                .ForeignKey("dbo.People", t => t.CarPersonId, cascadeDelete: true)
                .Index(t => t.CarPersonId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Group_GroupId1)
                .Index(t => t.LeaderOfGroup_GroupId);
            
            CreateTable(
                "dbo.DriverTrucks",
                c => new
                    {
                        DriverTruckId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CarPerson_CarPersonId = c.Int(),
                        Truck_VehicleId = c.Int()
                    })
                .PrimaryKey(t => t.DriverTruckId)
                .ForeignKey("dbo.CarPersons", t => t.CarPerson_CarPersonId)
                .ForeignKey("dbo.Vehicles", t => t.Truck_VehicleId)
                .Index(t => t.CarPerson_CarPersonId)
                .Index(t => t.Truck_VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        SideNumber = c.Int(nullable: false),
                        PlateNumber = c.String(),
                        VehicleStatus = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        MaxCapacity = c.Int(),
                        State = c.String(),
                        TruckType = c.Int(),
                        Capacity = c.Int(),
                        Length = c.Int(),
                        TrailerType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128)
                    })
                .PrimaryKey(t => t.VehicleId);
            
            CreateTable(
                "dbo.OrderTrailers",
                c => new
                    {
                        OrderTrailerId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Trailer_VehicleId = c.Int(),
                        Truck_VehicleId = c.Int()
                    })
                .PrimaryKey(t => t.OrderTrailerId)
                .ForeignKey("dbo.Orders", t => t.OrderTrailerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Trailer_VehicleId)
                .ForeignKey("dbo.Vehicles", t => t.Truck_VehicleId)
                .Index(t => t.OrderTrailerId)
                .Index(t => t.Trailer_VehicleId)
                .Index(t => t.Truck_VehicleId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        Price = c.Int(nullable: false),
                        Address = c.String(),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        StartLocation = c.String(),
                        Broker_BrokerId = c.Int()
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Brokers", t => t.Broker_BrokerId)
                .ForeignKey("dbo.Freights", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.Broker_BrokerId);
            
            CreateTable(
                "dbo.Freights",
                c => new
                    {
                        FreightId = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Depth = c.Int(nullable: false),
                        Description = c.String()
                    })
                .PrimaryKey(t => t.FreightId)
                .ForeignKey("dbo.Docks", t => t.FreightId)
                .Index(t => t.FreightId);
            
            CreateTable(
                "dbo.Docks",
                c => new
                    {
                        DockId = c.Int(nullable: false, identity: true),
                        DockSymbol = c.String(),
                        Sector_SectorId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.DockId)
                .ForeignKey("dbo.Sectors", t => t.Sector_SectorId, cascadeDelete: true)
                .Index(t => t.Sector_SectorId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        SectorSymbol = c.String(),
                        Warehouse_WarehouseId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.SectorId)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_WarehouseId, cascadeDelete: true)
                .Index(t => t.Warehouse_WarehouseId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        NumberOfSectors = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.WarehouseId);
            
            CreateTable(
                "dbo.OrderTrucks",
                c => new
                    {
                        OrderTruckId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Truck_VehicleId = c.Int()
                    })
                .PrimaryKey(t => t.OrderTruckId)
                .ForeignKey("dbo.Vehicles", t => t.Truck_VehicleId)
                .ForeignKey("dbo.Orders", t => t.OrderTruckId, cascadeDelete: true)
                .Index(t => t.OrderTruckId)
                .Index(t => t.Truck_VehicleId);
            
            CreateTable(
                "dbo.RepairTrailers",
                c => new
                    {
                        RepairTrailerId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Trailer_VehicleId = c.Int()
                    })
                .PrimaryKey(t => t.RepairTrailerId)
                .ForeignKey("dbo.Repairs", t => t.RepairTrailerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Trailer_VehicleId)
                .Index(t => t.RepairTrailerId)
                .Index(t => t.Trailer_VehicleId);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CarPerson_CarPersonId = c.Int()
                    })
                .PrimaryKey(t => t.RepairId)
                .ForeignKey("dbo.CarPersons", t => t.CarPerson_CarPersonId)
                .Index(t => t.CarPerson_CarPersonId);
            
            CreateTable(
                "dbo.RepairTrucks",
                c => new
                    {
                        RepairTruckId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Truck_VehicleId = c.Int()
                    })
                .PrimaryKey(t => t.RepairTruckId)
                .ForeignKey("dbo.Vehicles", t => t.Truck_VehicleId)
                .ForeignKey("dbo.Repairs", t => t.RepairTruckId, cascadeDelete: true)
                .Index(t => t.RepairTruckId)
                .Index(t => t.Truck_VehicleId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Leader_CarPersonId = c.Int()
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.CarPersons", t => t.Leader_CarPersonId)
                .Index(t => t.Leader_CarPersonId);
            
            CreateTable(
                "dbo.SafetyWorkers",
                c => new
                    {
                        SafetyWorkerId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.SafetyWorkerId)
                .ForeignKey("dbo.People", t => t.SafetyWorkerId, cascadeDelete: true)
                .Index(t => t.SafetyWorkerId);
            
            CreateTable(
                "dbo.Warehousemen",
                c => new
                    {
                        WarehousemanId = c.Int(nullable: false),
                        MedicalCertificate = c.String()
                    })
                .PrimaryKey(t => t.WarehousemanId)
                .ForeignKey("dbo.People", t => t.WarehousemanId, cascadeDelete: true)
                .Index(t => t.WarehousemanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warehousemen", "WarehousemanId", "dbo.People");
            DropForeignKey("dbo.SafetyWorkers", "SafetyWorkerId", "dbo.People");
            DropForeignKey("dbo.CarPersons", "CarPersonId", "dbo.People");
            DropForeignKey("dbo.CarPersons", "LeaderOfGroup_GroupId", "dbo.Groups");
            DropForeignKey("dbo.CarPersons", "Group_GroupId1", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Leader_CarPersonId", "dbo.CarPersons");
            DropForeignKey("dbo.CarPersons", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.OrderTrailers", "Truck_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.RepairTrailers", "Trailer_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.RepairTrucks", "RepairTruckId", "dbo.Repairs");
            DropForeignKey("dbo.RepairTrucks", "Truck_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.RepairTrailers", "RepairTrailerId", "dbo.Repairs");
            DropForeignKey("dbo.Repairs", "CarPerson_CarPersonId", "dbo.CarPersons");
            DropForeignKey("dbo.OrderTrailers", "Trailer_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.OrderTrucks", "OrderTruckId", "dbo.Orders");
            DropForeignKey("dbo.OrderTrucks", "Truck_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.OrderTrailers", "OrderTrailerId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderId", "dbo.Freights");
            DropForeignKey("dbo.Docks", "Sector_SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Sectors", "Warehouse_WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Freights", "FreightId", "dbo.Docks");
            DropForeignKey("dbo.Orders", "Broker_BrokerId", "dbo.Brokers");
            DropForeignKey("dbo.DriverTrucks", "Truck_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DriverTrucks", "CarPerson_CarPersonId", "dbo.CarPersons");
            DropForeignKey("dbo.Brokers", "BrokerId", "dbo.People");
            DropForeignKey("dbo.Admins", "AdminId", "dbo.People");
            DropIndex("dbo.Warehousemen", new[] { "WarehousemanId" });
            DropIndex("dbo.SafetyWorkers", new[] { "SafetyWorkerId" });
            DropIndex("dbo.Groups", new[] { "Leader_CarPersonId" });
            DropIndex("dbo.RepairTrucks", new[] { "Truck_VehicleId" });
            DropIndex("dbo.RepairTrucks", new[] { "RepairTruckId" });
            DropIndex("dbo.Repairs", new[] { "CarPerson_CarPersonId" });
            DropIndex("dbo.RepairTrailers", new[] { "Trailer_VehicleId" });
            DropIndex("dbo.RepairTrailers", new[] { "RepairTrailerId" });
            DropIndex("dbo.OrderTrucks", new[] { "Truck_VehicleId" });
            DropIndex("dbo.OrderTrucks", new[] { "OrderTruckId" });
            DropIndex("dbo.Sectors", new[] { "Warehouse_WarehouseId" });
            DropIndex("dbo.Docks", new[] { "Sector_SectorId" });
            DropIndex("dbo.Freights", new[] { "FreightId" });
            DropIndex("dbo.Orders", new[] { "Broker_BrokerId" });
            DropIndex("dbo.Orders", new[] { "OrderId" });
            DropIndex("dbo.OrderTrailers", new[] { "Truck_VehicleId" });
            DropIndex("dbo.OrderTrailers", new[] { "Trailer_VehicleId" });
            DropIndex("dbo.OrderTrailers", new[] { "OrderTrailerId" });
            DropIndex("dbo.DriverTrucks", new[] { "Truck_VehicleId" });
            DropIndex("dbo.DriverTrucks", new[] { "CarPerson_CarPersonId" });
            DropIndex("dbo.CarPersons", new[] { "LeaderOfGroup_GroupId" });
            DropIndex("dbo.CarPersons", new[] { "Group_GroupId1" });
            DropIndex("dbo.CarPersons", new[] { "Group_GroupId" });
            DropIndex("dbo.CarPersons", new[] { "CarPersonId" });
            DropIndex("dbo.Brokers", new[] { "BrokerId" });
            DropIndex("dbo.Admins", new[] { "AdminId" });
            DropTable("dbo.Warehousemen");
            DropTable("dbo.SafetyWorkers");
            DropTable("dbo.Groups");
            DropTable("dbo.RepairTrucks");
            DropTable("dbo.Repairs");
            DropTable("dbo.RepairTrailers");
            DropTable("dbo.OrderTrucks");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Sectors");
            DropTable("dbo.Docks");
            DropTable("dbo.Freights");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderTrailers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.DriverTrucks");
            DropTable("dbo.CarPersons");
            DropTable("dbo.Brokers");
            DropTable("dbo.People");
            DropTable("dbo.Admins");
        }
    }
}
