﻿using Microsoft.AspNetCore.Identity;

namespace LibraryManagmentSystem.Domain.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? CreatedByUserId { get; set; }
    public IdentityUser? CreatedBy { get; set; }
}