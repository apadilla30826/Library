using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
