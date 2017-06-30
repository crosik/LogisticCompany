namespace Mas_Logistics_Company.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "PersonId");
            DropColumn("dbo.Brokers", "PersonId");
            DropColumn("dbo.CarPersons", "PersonId");
            DropColumn("dbo.Warehousemen", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehousemen", "PersonId", c => c.Int());
            AddColumn("dbo.CarPersons", "PersonId", c => c.Int());
            AddColumn("dbo.Brokers", "PersonId", c => c.Int());
            AddColumn("dbo.Admins", "PersonId", c => c.Int());
        }
    }
}
