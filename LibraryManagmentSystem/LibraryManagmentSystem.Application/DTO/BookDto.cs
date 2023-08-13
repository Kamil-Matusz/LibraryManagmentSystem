using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Application.DTO;

public class BookDto
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublishedHouseId { get; set; }
    public DateTime PublishedDate { get; set; }
}