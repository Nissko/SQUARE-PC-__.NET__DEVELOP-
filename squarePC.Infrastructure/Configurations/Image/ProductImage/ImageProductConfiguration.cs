using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.Image;

namespace squarePC.Infrastructure.Configurations.Image.ProductImage
{
    public class ImageProductConfiguration
        : IEntityTypeConfiguration<ImageProductsEntity>
    {
        public void Configure(EntityTypeBuilder<ImageProductsEntity> imgConfiguration)
        {
            imgConfiguration.ToTable("ImageProducts");

            imgConfiguration.HasKey(o => o.Id);

            imgConfiguration
                .Property<string>("_name")
                .HasColumnName("Name");

            imgConfiguration
                .Property<int>("_displayOrder")
                .HasColumnName("DisplayOrder");

            imgConfiguration
                .Property<byte[]>("_image")
                .HasColumnName("Image");
        }
    }
}