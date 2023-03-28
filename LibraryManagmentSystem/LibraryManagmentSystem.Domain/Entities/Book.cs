namespace LibraryManagmentSystem.Domain.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }

    public Book(int bookId, string name, string author, string genre, DateTime publishedDate)
    {
        BookId = bookId;
        Name = name;
        Author = author;
        Genre = genre;
        PublishedDate = publishedDate;
    }
}