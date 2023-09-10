using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WTM.CarManager.Business.Domains.Models;
using WTM.CarManager.Business.Enumerators;

namespace WTM.CarManager.Infrasctructure.Mappings
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Marcas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).HasColumnName("Nome").IsRequired();
            builder.Property(x => x.Status).HasConversion(new EnumToStringConverter<StatusTypeEnum>()).HasMaxLength(30);
        }
    }
}
