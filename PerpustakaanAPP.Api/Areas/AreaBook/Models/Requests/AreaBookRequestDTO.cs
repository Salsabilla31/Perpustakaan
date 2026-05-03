using PerpustakaanAPP.Data.Access.Models;

namespace PerpustakaanAPP.Api.Areas.AreaBook.Models.Request
{
    public class AreaBookRequestDTO
    {
        public string Areacode { get; set; } = null!;
        public string Areaname { get; set; } = null!;
        public string? Areadescription { get; set; }
        public bool Isactive { get; set; }
    }
}
