﻿using Microsoft.AspNetCore.Identity;

namespace LibraryManagmentSystem.Domain.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public DateTime PublishedDate { get; set; }
    public int PublishedHouseId { get; set; }
    public string? CreatedByUserId { get; set; }
    public IdentityUser? CreatedBy { get; set; }
}