using System;
using System.Collections.Generic;

namespace PerpustakaanAPP.Data.Access.Models;

public partial class Storages
{
    public int Storageid { get; set; }

    public int Books { get; set; }

    public int Racks { get; set; }

    public virtual Books BooksNavigation { get; set; } = null!;

    public virtual Racks RacksNavigation { get; set; } = null!;
}
