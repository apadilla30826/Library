using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public partial class Author
{
    
    public int AuthorId { get; set; }

    [Required]
    [Display(Name = "Authors Name")]
    public string AuthorName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
