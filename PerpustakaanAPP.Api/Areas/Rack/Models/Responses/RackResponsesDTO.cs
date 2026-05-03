using PerpustakaanAPP.Data.Access.Models;

namespace PerpustakaanAPP.Api.Areas.Rack.Models.Responses
{
    public class RackResponsesDTO
    {
        public int Rackid { get; set; }

        public int Areaid { get; set; }

        public string Rackcode { get; set; } = null!;

        public string Rackname { get; set; } = null!;

        public string? Rackdescription { get; set; }

        public int Capacity { get; set; }

        public bool Isactive { get; set; }

    }
}
