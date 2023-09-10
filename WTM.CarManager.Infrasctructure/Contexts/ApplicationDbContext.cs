using Microsoft.EntityFrameworkCore;
using WTM.CarManager.Business.Domains.Models;
using WTM.CarManager.Infrasctructure.Mappings;

namespace WTM.CarManager.Infrasctructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }
        //public ApplicationDbContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Server=(localdb)\mssqllocaldb;Database=SoCarroVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new BrandMapping());
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(p => p.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("VARCHAR");
            }
        }
        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    foreach (var entity in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreateDate") != null))
        //    {
        //        if (entity.State == EntityState.Added)
        //        {
        //            entity.Property("CreateDate").CurrentValue = DateTime.Now;
        //        }
        //        if (entity.State == EntityState.Modified)
        //        {
        //            entity.Property("CreateDate").IsModified = false;
        //        }
        //    }
        //    return base.SaveChangesAsync();
        //}
    }
}
