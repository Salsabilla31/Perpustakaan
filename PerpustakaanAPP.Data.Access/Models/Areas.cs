namespace PerpustakaanAPP.Data.Access.Models
{
    public partial class AreaBook
    {
        public int Areaid { get; set; }
        public string Areacode { get; set; } = null!;
        public string Areaname { get; set; } = null!;
        public string? Areadescription { get; set; }
        public bool Isactive { get; set; }
        public DateTime? Createdate { get; set; }
        public string? Createby { get; set; }
        public DateTime? Modifydate { get; set; }
        public string? Modifyby { get; set; }

        public virtual ICollection<Racks> Racks { get; set; } = new List<Racks>();
    }
}