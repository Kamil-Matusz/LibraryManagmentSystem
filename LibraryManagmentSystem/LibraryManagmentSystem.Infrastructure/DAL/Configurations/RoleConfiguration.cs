using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentSystem.Infrastructure.DAL.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.RoleId);
        builder.Property(x => x.RoleId).ValueGeneratedNever();
        builder.Property(x => x.RoleName).HasMaxLength(30);
    }
}