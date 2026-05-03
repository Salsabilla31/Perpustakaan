using System;
using System.Collections.Generic;

namespace PerpustakaanAPP.Data.Access.Models;

public partial class Books
{
    public int Bookid { get; set; }

    public string Bookname { get; set; } = null!;

    public string? Description { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public DateOnly? Releasedate { get; set; }

    public int? Pagebook { get; set; }

    public virtual ICollection<Storages> Storages { get; set; } = new List<Storages>();
}
