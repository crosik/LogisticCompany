namespace Mas_Logistics_Company.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PersonId", c => c.Int());
            AddColumn("dbo.Brokers", "PersonId", c => c.Int());
            AddColumn("dbo.CarPersons", "PersonId", c => c.Int());
            AddColumn("dbo.SafetyWorkers", "PersonId", c => c.Int());
            AddColumn("dbo.Warehousemen", "PersonId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Warehousemen", "PersonId");
            DropColumn("dbo.SafetyWorkers", "PersonId");
            DropColumn("dbo.CarPersons", "PersonId");
            DropColumn("dbo.Brokers", "PersonId");
            DropColumn("dbo.Admins", "PersonId");
        }
    }
}
