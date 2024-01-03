using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int? MemberId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}
