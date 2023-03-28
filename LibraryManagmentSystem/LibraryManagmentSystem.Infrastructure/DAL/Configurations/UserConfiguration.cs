using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentSystem.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId);
        
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.Username)
            .HasMaxLength(30)
            .IsRequired();
        builder.Property(x => x.Password)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(x => x.Fullname)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.RoleId)
            .IsRequired();
    }
}