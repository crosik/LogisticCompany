using System.Data.Entity;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;
using Mas_Logistics_Company.Models.Warehouses;

namespace Mas_Logistics_Company.Models
{
    public class Context : DbContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Mas_Logistics_Company.Models.Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Context' 
        // connection string in the application configuration file.
        public Context()
            : base("name=Context")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<SafetyWorker> Workers { get; set; }
        public DbSet<Warehouseman> Warehousemans { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Dock> Docks { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<DriverTruck> DriverTrucks { get; set; }
        public DbSet<Freight> Freights { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderTrailer> OrderTrailers { get; set; }
        public DbSet<OrderTruck> OrderTrucks { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairTrailer> RepairTrailers { get; set; }
        public DbSet<RepairTruck> RepairTrucks { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CarPerson> CarPersons { get; set; }
        public DbSet<CPersonType> CarPersonTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasOptional(p => p.Admin).WithRequired(a => a.Person).WillCascadeOnDelete();
            modelBuilder.Entity<Person>().HasOptional(p => p.Broker).WithRequired(a => a.Person).WillCascadeOnDelete();
            modelBuilder.Entity<Person>().HasOptional(p => p.CarPerson).WithRequired(a => a.Person).WillCascadeOnDelete();
            modelBuilder.Entity<Person>().HasOptional(p => p.SafetyWorker).WithRequired(a => a.Person).WillCascadeOnDelete();
            modelBuilder.Entity<Person>().HasOptional(p => p.Warehouseman).WithRequired(a => a.Person).WillCascadeOnDelete();

            modelBuilder.Entity<CarPerson>().HasKey(p => p.Id);

            modelBuilder.Entity<Sector>().HasRequired(p=>p.Warehouse).WithMany(p=> p.Sectors).WillCascadeOnDelete();
            modelBuilder.Entity<Dock>().HasRequired(p => p.Sector).WithMany(p => p.Docks).WillCascadeOnDelete();
            modelBuilder.Entity<Dock>().HasOptional(p => p.Freight).WithRequired(p => p.Dock);

            modelBuilder.Entity<Order>().HasOptional(p=>p.OrderTruck).WithRequired(p=>p.Order).WillCascadeOnDelete();
            modelBuilder.Entity<Order>().HasOptional(p=>p.OrderTrailer).WithRequired(p=>p.Order).WillCascadeOnDelete();
            modelBuilder.Entity<Order>().HasRequired(p => p.Freight).WithOptional(p => p.Order);

            modelBuilder.Entity<Repair>().HasOptional(p => p.RepairTrailer).WithRequired(p => p.Repair).WillCascadeOnDelete();
            modelBuilder.Entity<Repair>().HasOptional(p=>p.RepairTruck).WithRequired(p=>p.Repair).WillCascadeOnDelete();

            

           
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}