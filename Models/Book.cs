using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Isbn { get; set; }

    public int? PublicationYear { get; set; }

    public string? Publisher { get; set; }

    public int? TotalCopies { get; set; }

    public int? AvailableCopies { get; set; }

    public int? GenreId { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
