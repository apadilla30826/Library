using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    [Required]
    [Display(Name = "Genre Name")]
    public string GenreName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
