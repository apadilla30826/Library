using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TI-ANALISTA3-LT; DATABASE=Library; Trusted_connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__86516BCFA05D31B3");

            entity.Property(e => e.AuthorId)
                .ValueGeneratedNever()
                .HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__490D1AE186D2E68A");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AvailableCopies).HasColumnName("available_copies");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            entity.Property(e => e.Publisher)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("publisher");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TotalCopies).HasColumnName("total_copies");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__author_id__3C69FB99");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Books__genre_id__3B75D760");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__46ACF4CBD3AFA14F");

            entity.Property(e => e.FavoriteId)
                .ValueGeneratedNever()
                .HasColumnName("favorite_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");

            entity.HasOne(d => d.Book).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Favorites__book___45F365D3");

            entity.HasOne(d => d.Member).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Favorites__membe__44FF419A");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__18428D42D50921B7");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__B29B85344093548D");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("member_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("registration_date");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF0B8CAB9C");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BorrowDate)
                .HasColumnType("date")
                .HasColumnName("borrow_date");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");

            entity.HasOne(d => d.Book).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Transacti__book___412EB0B6");

            entity.HasOne(d => d.Member).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Transacti__membe__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
