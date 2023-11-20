using ECom.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECom.Persistence.Configurations;

internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        #region ForeingKey

        builder.HasMany(x => x.BasketItems)
                  .WithOne(x => x.Basket)
                  .HasForeignKey(x => x.BasketId)
                  // => Sepet silinirken silinmek istenen sepet içeriği de silinmeli.
                  .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}