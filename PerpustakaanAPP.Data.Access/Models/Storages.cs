using System;
using System.Collections.Generic;

namespace PerpustakaanAPP.Data.Access.Models;

public partial class Storages
{
    public int Storageid { get; set; }

    public int Bookid { get; set; }

    public int Rackid { get; set; }

    public DateTime? Createdate { get; set; }

    public string? Createby { get; set; }

    public DateTime? Modifydate { get; set; }

    public string? Modifyby { get; set; }

    public virtual Books BooksNavigation { get; set; } = null!;

    public virtual Racks RacksNavigation { get; set; } = null!;
}
