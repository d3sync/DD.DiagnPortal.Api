using DD.Shared.DataAccess;
using DD.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DiagnPortal.API.Data
{
    public class ReadDbContext : DbContextBase
    {
        public ReadDbContext(DbContextOptions<DbContextBase> options)
            : base(options)
        {
            //Setting default behavior not to track any entity
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=192.168.10.5\\ddsql;Initial Catalog=DIAGBASE;Persist Security Info=True;User ID=diagn;Password=99d!@gn;Encrypt=False", 
                    properties => properties.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatexetResult>()
                .HasNoKey();
        }
        public DbSet<PatexetResult> PatexetResults { get; set; }
        // Override SaveChanges to prevent write operations
        public override int SaveChanges()
        {
            throw new InvalidOperationException("Read-only context does not support SaveChanges.");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("Read-only context does not support SaveChangesAsync.");
        }
    }
}
