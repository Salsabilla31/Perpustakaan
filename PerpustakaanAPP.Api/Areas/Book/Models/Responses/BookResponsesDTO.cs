namespace PerpustakaanAPP.Api.Areas.Book.Models.Resposes
{
    public class BookResponsesDTO
    {
        public int Bookid { get; set; }

        public string Bookname { get; set; } = null!;

        public string? Description { get; set; }

        public string? Author { get; set; }

        public string? Publisher { get; set; }

        public DateOnly? Releasedate { get; set; }

        public int? Pagebook { get; set; }
    }
}
