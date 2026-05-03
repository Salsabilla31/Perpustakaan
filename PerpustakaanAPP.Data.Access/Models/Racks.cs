using System;
using System.Collections.Generic;

namespace PerpustakaanAPP.Data.Access.Models;

public partial class Racks
{
    public int Rackid { get; set; }

    public int Areaid { get; set; }

    public string Rackcode { get; set; } = null!;

    public string Rackname { get; set; } = null!;

    public string? Rackdescription { get; set; }

    public int Capacity { get; set; }

    public bool Isactive { get; set; }

    public DateTime? Createdate { get; set; }

    public string? Createby { get; set; }

    public DateTime? Modifydate { get; set; }

    public string? Modifyby { get; set; }

    public virtual AreaBook Area { get; set; } = null!;

    public virtual ICollection<Storages> Storages { get; set; } = new List<Storages>();
}
