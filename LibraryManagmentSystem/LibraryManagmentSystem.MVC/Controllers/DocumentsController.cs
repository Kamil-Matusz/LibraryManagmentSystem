using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagmentSystem.Infrastructure.DAL;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryManagmentSystem.MVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public DocumentsController(LibraryDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateBookListPDF()
        {
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            var data = _dbContext.Books.ToList();

            PdfPTable table = new PdfPTable(3);
            PdfPCell headerCell = new PdfPCell(new Phrase("Books List"));
            headerCell.Colspan = 4;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCell.BackgroundColor = BaseColor.CYAN;
            table.AddCell(headerCell);

            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            table.AddCell(new PdfPCell(new Phrase("Name", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("Author", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("Genre", boldFont)));

            foreach (var item in data)
            {
                table.AddCell(new PdfPCell(new Phrase(item.Name)));
                table.AddCell(new PdfPCell(new Phrase(item.Author)));
                table.AddCell(new PdfPCell(new Phrase(item.Genre)));
            }

            document.Add(table);
            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Dispose();

            return File(bytes, "application/pdf", "BookList.pdf");
        }

        public IActionResult GenerateBookingListPDF()
        {
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            var data = _dbContext.Reservations
                .Where(x => x.StatusId == 3)
                .ToList();

            PdfPTable table = new PdfPTable(5);
            PdfPCell headerCell = new PdfPCell(new Phrase("Completed Booking List"));
            headerCell.Colspan = 5;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCell.BackgroundColor = BaseColor.CYAN;
            table.AddCell(headerCell);

            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            table.AddCell(new PdfPCell(new Phrase("ReservationId", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("BookId", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("ReservationStart", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("ReservationEnd", boldFont)));
            table.AddCell(new PdfPCell(new Phrase("UserId", boldFont)));

            foreach (var item in data)
            {
                table.AddCell(new PdfPCell(new Phrase(item.ReservationId.ToString())));
                table.AddCell(new PdfPCell(new Phrase(item.BookId.ToString())));
                table.AddCell(new PdfPCell(new Phrase(item.ReservationStart.ToString())));
                table.AddCell(new PdfPCell(new Phrase(item.ReservationEnd.ToString())));
                table.AddCell(new PdfPCell(new Phrase(item.UserId.ToString())));
            }

            document.Add(table);
            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Dispose();

            return File(bytes, "application/pdf", "CompletedBookingList.pdf");
        }

    }
}
