using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Weather.Models
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BooksAddit> BooksAddits { get; set; } = null!;
        public virtual DbSet<BooksCover> BooksCovers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<DeletedComment> DeletedComments { get; set; } = null!;
        public virtual DbSet<Evaluation> Evaluations { get; set; } = null!;
        public virtual DbSet<MiniBooksCover> MiniBooksCovers { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("Book_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Patronymic).HasMaxLength(20);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("Author_ID");

                entity.Property(e => e.DescriptionB).HasMaxLength(250);

                entity.Property(e => e.Genres).HasMaxLength(50);

                entity.Property(e => e.NameBook).HasMaxLength(40);

                entity.Property(e => e.NumPages).HasColumnName("Num_Pages");

                entity.Property(e => e.NumСhapters).HasColumnName("Num_Сhapters");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__Author_ID__3B75D760");
            });

            modelBuilder.Entity<BooksAddit>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BooksAdd__C223F39411DA6CAE");

                entity.ToTable("BooksAddit");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("Book_ID");

                entity.Property(e => e.ShortDescription).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.BooksAddit)
                    .HasForeignKey<BooksAddit>(d => d.BookId)
                    .HasConstraintName("FK__BooksAddi__Book___3E52440B");
            });

            modelBuilder.Entity<BooksCover>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BooksCov__C223F3946A10BBCC");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("Book_ID");

                entity.Property(e => e.Cover).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.BooksCover)
                    .HasForeignKey<BooksCover>(d => d.BookId)
                    .HasConstraintName("FK__BooksCove__Book___440B1D61");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__Comments__E19B6D4C21A60D13");

                entity.Property(e => e.IdComment).HasColumnName("ID_Comment");

                entity.Property(e => e.BookId).HasColumnName("Book_ID");

                entity.Property(e => e.ChData)
                    .HasColumnType("date")
                    .HasColumnName("Ch_Data");

                entity.Property(e => e.ChTime).HasColumnName("Ch_Time");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(250)
                    .HasColumnName("Comment");

                entity.Property(e => e.CrData)
                    .HasColumnType("date")
                    .HasColumnName("Cr_Data");

                entity.Property(e => e.CrTime).HasColumnName("Cr_Time");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Comments__Book_I__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comments__UserID__4D94879B");
            });

            modelBuilder.Entity<DeletedComment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__DeletedC__E19B6D4CBA7D1F2A");

                entity.Property(e => e.IdComment)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Comment");

                entity.Property(e => e.DeletedData)
                    .HasColumnType("date")
                    .HasColumnName("Deleted_Data");

                entity.Property(e => e.DeletedTime).HasColumnName("Deleted_Time");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithOne(p => p.DeletedComment)
                    .HasForeignKey<DeletedComment>(d => d.IdComment)
                    .HasConstraintName("FK__DeletedCo__ID_Co__5165187F");
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__Evaluati__E19B6D4C22F23EAF");

                entity.Property(e => e.IdComment)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Comment");

                entity.Property(e => e.Evaluation1).HasColumnName("Evaluation");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithOne(p => p.Evaluation)
                    .HasForeignKey<Evaluation>(d => d.IdComment)
                    .HasConstraintName("FK__Evaluatio__ID_Co__5441852A");
            });

            modelBuilder.Entity<MiniBooksCover>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__MiniBook__C223F394C37E432C");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("Book_ID");

                entity.Property(e => e.MiniCover).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.MiniBooksCover)
                    .HasForeignKey<MiniBooksCover>(d => d.BookId)
                    .HasConstraintName("FK__MiniBooks__Book___412EB0B6");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId })
                    .HasName("PK__Notes__4BAAF395CD81289A");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BookId).HasColumnName("Book_ID");

                entity.Property(e => e.Note1)
                    .HasMaxLength(200)
                    .HasColumnName("Note");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Notes__Book_ID__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notes__UserID__49C3F6B7");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Ratings__C223F394EE85E471");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("Book_ID");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.Rating)
                    .HasForeignKey<Rating>(d => d.BookId)
                    .HasConstraintName("FK__Ratings__Book_ID__46E78A0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserEmail).HasMaxLength(35);

                entity.Property(e => e.UserLogin).HasMaxLength(35);

                entity.Property(e => e.UserPassword).HasMaxLength(35);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
