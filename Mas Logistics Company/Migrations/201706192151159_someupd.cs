namespace Mas_Logistics_Company.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someupd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CPersonTypes",
                c => new
                    {
                        CPersonTypeId = c.Int(nullable: false, identity: true),
                        PersonType = c.Int(nullable: false),
                        CarPerson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CPersonTypeId)
                .ForeignKey("dbo.CarPersons", t => t.CarPerson_Id)
                .Index(t => t.CarPerson_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CPersonTypes", "CarPerson_Id", "dbo.CarPersons");
            DropIndex("dbo.CPersonTypes", new[] { "CarPerson_Id" });
            DropTable("dbo.CPersonTypes");
        }
    }
}
