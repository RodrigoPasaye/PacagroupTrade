using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasPrecision(9, 0)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Symbol)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Side)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.TransactTime)
                .IsRequired();

            builder.Property(x => x.Quanty)
                .HasPrecision(9, 0)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(x => x.Currency)
                .HasMaxLength(3)
                .IsRequired()
                .HasDefaultValue("USD");

            builder.Property(x => x.Text)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.LastModified)
                .IsRequired();

            builder.Property(x => x.LastModifiedBy)
                .HasMaxLength(120)
                .IsRequired(false);
        }
    }
}
