using Microsoft.EntityFrameworkCore;
using ReportIT.Domain.Aggregates.CityAgg;

namespace ReportIT.DataAccess
{
    public class ReportITDbContext : DbContext
    {
        public ReportITDbContext(
            DbContextOptions<ReportITDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>().ForNpgsqlToTable("city");
            builder.Entity<City>().HasKey(m => m.Id);
            builder.Entity<City>().Property(m => m.Name).IsRequired().HasMaxLength(50);

            base.OnModelCreating(builder);
        }
    }
}
