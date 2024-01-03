using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? BookId { get; set; }

    public int? MemberId { get; set; }

    public DateTime? BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}
