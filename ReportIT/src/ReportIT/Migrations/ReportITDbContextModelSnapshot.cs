using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReportIT.DataAccess;

namespace ReportIT.Migrations
{
    [DbContext(typeof(ReportITDbContext))]
    partial class ReportITDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("ReportIT.Domain.Aggregates.CityAgg.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasAnnotation("Npgsql:TableName", "city");
                });
        }
    }
}
