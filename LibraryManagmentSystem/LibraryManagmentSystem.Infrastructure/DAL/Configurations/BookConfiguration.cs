﻿using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentSystem.Infrastructure.DAL.Configurations;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.BookId);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name)
            .HasMaxLength(300)
            .IsRequired();
        builder.HasOne<PublishedHouse>().WithMany().HasForeignKey(x => x.PublishedHouseId);
    }
}