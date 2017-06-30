namespace Mas_Logistics_Company.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class littleupd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CarPersons", name: "CarPersonId", newName: "Id");
            RenameColumn(table: "dbo.DriverTrucks", name: "CarPerson_CarPersonId", newName: "CarPerson_Id");
            RenameColumn(table: "dbo.Repairs", name: "CarPerson_CarPersonId", newName: "CarPerson_Id");
            RenameColumn(table: "dbo.Groups", name: "Leader_CarPersonId", newName: "Leader_Id");
            RenameIndex(table: "dbo.CarPersons", name: "IX_CarPersonId", newName: "IX_Id");
            RenameIndex(table: "dbo.DriverTrucks", name: "IX_CarPerson_CarPersonId", newName: "IX_CarPerson_Id");
            RenameIndex(table: "dbo.Repairs", name: "IX_CarPerson_CarPersonId", newName: "IX_CarPerson_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_Leader_CarPersonId", newName: "IX_Leader_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_Leader_Id", newName: "IX_Leader_CarPersonId");
            RenameIndex(table: "dbo.Repairs", name: "IX_CarPerson_Id", newName: "IX_CarPerson_CarPersonId");
            RenameIndex(table: "dbo.DriverTrucks", name: "IX_CarPerson_Id", newName: "IX_CarPerson_CarPersonId");
            RenameIndex(table: "dbo.CarPersons", name: "IX_Id", newName: "IX_CarPersonId");
            RenameColumn(table: "dbo.Groups", name: "Leader_Id", newName: "Leader_CarPersonId");
            RenameColumn(table: "dbo.Repairs", name: "CarPerson_Id", newName: "CarPerson_CarPersonId");
            RenameColumn(table: "dbo.DriverTrucks", name: "CarPerson_Id", newName: "CarPerson_CarPersonId");
            RenameColumn(table: "dbo.CarPersons", name: "Id", newName: "CarPersonId");
        }
    }
}
