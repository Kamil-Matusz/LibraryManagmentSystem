using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Application.DTO;

public class BookDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public DateTime PublishedDate { get; set; }
}