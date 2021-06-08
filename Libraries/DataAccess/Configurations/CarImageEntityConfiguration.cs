using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CarImageEntityConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}
