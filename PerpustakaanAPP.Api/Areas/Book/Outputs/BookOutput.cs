using PerpustakaanAPP.Api.Base;
using PerpustakaanAPP.Api.Areas.Book.Models.Resposes;

namespace PerpustakaanAPP.Api.Areas.Book.Outputs
{
    public class BookOutput : OutputBase
    {
        public BookResponsesDTO? Data { get; set; }
    }

    public class BookOutputListOutput : OutputBase
    {
        public  List<BookResponsesDTO>? Data { get; set; }
    }
}