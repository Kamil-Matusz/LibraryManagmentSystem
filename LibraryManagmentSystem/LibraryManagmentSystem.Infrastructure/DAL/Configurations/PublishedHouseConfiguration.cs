using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Infrastructure.DAL.Configurations
{
    internal sealed class PublishedHouseConfiguration : IEntityTypeConfiguration<PublishedHouse>
    {
        public void Configure(EntityTypeBuilder<PublishedHouse> builder)
        {
            builder.HasKey(x => x.PublishedHouseId);
            builder.HasIndex(x => x.PublishedHouseName).IsUnique();
            builder.Property(x => x.PublishedHouseName)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
