using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentSystem.Infrastructure.DAL.Configurations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(x => x.ReservationId);
        builder.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId);
        builder.HasOne<Status>().WithMany().HasForeignKey(x => x.StatusId);
        builder.Property(x => x.BookId).IsRequired();
        builder.Property(x => x.StatusId).IsRequired();
    }
}