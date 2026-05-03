using PerpustakaanAPP.Data.Access.Models;

namespace PerpustakaanAPP.Api.Areas.AreaBook.Models.Responses
{
    public class AreaBookResponsesDTO
    {
        public int Areaid { get; set; }
        public string Areacode { get; set; } = null!;
        public string Areaname { get; set; } = null!;
        public string? Areadescription { get; set; }
        public bool Isactive { get; set; }
    }
}
