using GroceryStore.Api.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace GroceryStore.Api.DataAccessLayer
{
    public partial class DataContext : DbContext
    {        
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<UserManagement> usermanagement { get; set; }

        public virtual DbSet<SupplierManangement> suppliermanagement { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"User Id=root;password=Alisha@2015;Host=localhost;Database=gs;");//working string for windows   
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserManagement>().ToTable("usermanagement");
            modelBuilder.Entity<UserManagement>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<SupplierManangement>().ToTable("supplier");
            modelBuilder.Entity<SupplierManangement>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
