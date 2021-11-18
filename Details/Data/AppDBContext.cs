using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Details.Data
{
    public partial class AppDBContext : DbContext
    {
        private static AppDBContext _context;

        public static AppDBContext GetContext()
        {
            if (_context == null)
            {
                return _context = new AppDBContext();
            }

            return _context;
        }

        public AppDBContext() : base("name=AppDBContext") { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TypeMachine> TypeMachines { get; set; }
        public virtual DbSet<TypeRepair> TypeRepairs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Repairs)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Machine>()
                .HasMany(e => e.Repairs)
                .WithRequired(e => e.Machine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeMachine>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.TypeMachine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeRepair>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TypeRepair>()
                .HasMany(e => e.Repairs)
                .WithRequired(e => e.TypeRepair)
                .WillCascadeOnDelete(false);
        }
    }
}
