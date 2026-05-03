using System.ComponentModel.DataAnnotations;
using PerpustakaanAPP.Data.Access.Models;

namespace PerpustakaanAPP.Api.Areas.Rack.Models.Request
{
    public class RackRequestDTO
    {
        public int Areaid { get; set; }

        [Required]
        public string Rackcode { get; set; } = null!;

        [Required]
        public string Rackname { get; set; } = null!;

        public string? Rackdescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }

        public bool Isactive { get; set; }
    }
}
