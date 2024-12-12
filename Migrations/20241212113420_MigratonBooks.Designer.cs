﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Models;

#nullable disable

namespace Weather.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20241212113420_MigratonBooks")]
    partial class MigratonBooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Weather.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("First_Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Last_Name");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Weather.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("Author_ID");

                    b.Property<string>("DescriptionB")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameBook")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("NumPages")
                        .HasColumnType("int")
                        .HasColumnName("Num_Pages");

                    b.Property<int>("NumСhapters")
                        .HasColumnType("int")
                        .HasColumnName("Num_Сhapters");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Weather.Models.BooksAddit", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId")
                        .HasName("PK__BooksAdd__C223F39411DA6CAE");

                    b.ToTable("BooksAddit", (string)null);
                });

            modelBuilder.Entity("Weather.Models.BooksCover", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId")
                        .HasName("PK__BooksCov__C223F3946A10BBCC");

                    b.ToTable("BooksCovers");
                });

            modelBuilder.Entity("Weather.Models.Comment", b =>
                {
                    b.Property<int>("IdComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Comment");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComment"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<DateTime?>("ChData")
                        .HasColumnType("date")
                        .HasColumnName("Ch_Data");

                    b.Property<TimeSpan?>("ChTime")
                        .HasColumnType("time")
                        .HasColumnName("Ch_Time");

                    b.Property<string>("Comment1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Comment");

                    b.Property<DateTime>("CrData")
                        .HasColumnType("date")
                        .HasColumnName("Cr_Data");

                    b.Property<TimeSpan>("CrTime")
                        .HasColumnType("time")
                        .HasColumnName("Cr_Time");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("IdComment")
                        .HasName("PK__Comments__E19B6D4C21A60D13");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Weather.Models.DeletedComment", b =>
                {
                    b.Property<int>("IdComment")
                        .HasColumnType("int")
                        .HasColumnName("ID_Comment");

                    b.Property<DateTime?>("DeletedData")
                        .HasColumnType("date")
                        .HasColumnName("Deleted_Data");

                    b.Property<TimeSpan?>("DeletedTime")
                        .HasColumnType("time")
                        .HasColumnName("Deleted_Time");

                    b.HasKey("IdComment")
                        .HasName("PK__DeletedC__E19B6D4CBA7D1F2A");

                    b.ToTable("DeletedComments");
                });

            modelBuilder.Entity("Weather.Models.Evaluation", b =>
                {
                    b.Property<int>("IdComment")
                        .HasColumnType("int")
                        .HasColumnName("ID_Comment");

                    b.Property<int>("Evaluation1")
                        .HasColumnType("int")
                        .HasColumnName("Evaluation");

                    b.HasKey("IdComment")
                        .HasName("PK__Evaluati__E19B6D4C22F23EAF");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Weather.Models.MiniBooksCover", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<string>("MiniCover")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId")
                        .HasName("PK__MiniBook__C223F394C37E432C");

                    b.ToTable("MiniBooksCovers");
                });

            modelBuilder.Entity("Weather.Models.Note", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<string>("Note1")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Note");

                    b.HasKey("UserId", "BookId")
                        .HasName("PK__Notes__4BAAF395CD81289A");

                    b.HasIndex("BookId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Weather.Models.Rating", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_ID");

                    b.Property<double>("Rating1")
                        .HasColumnType("float")
                        .HasColumnName("Rating");

                    b.HasKey("BookId")
                        .HasName("PK__Ratings__C223F394EE85E471");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Weather.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Weather.Models.Book", b =>
                {
                    b.HasOne("Weather.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Books__Author_ID__3B75D760");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Weather.Models.BooksAddit", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithOne("BooksAddit")
                        .HasForeignKey("Weather.Models.BooksAddit", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BooksAddi__Book___3E52440B");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Weather.Models.BooksCover", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithOne("BooksCover")
                        .HasForeignKey("Weather.Models.BooksCover", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BooksCove__Book___440B1D61");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Weather.Models.Comment", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Comments__Book_I__4E88ABD4");

                    b.HasOne("Weather.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Comments__UserID__4D94879B");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Weather.Models.DeletedComment", b =>
                {
                    b.HasOne("Weather.Models.Comment", "IdCommentNavigation")
                        .WithOne("DeletedComment")
                        .HasForeignKey("Weather.Models.DeletedComment", "IdComment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__DeletedCo__ID_Co__5165187F");

                    b.Navigation("IdCommentNavigation");
                });

            modelBuilder.Entity("Weather.Models.Evaluation", b =>
                {
                    b.HasOne("Weather.Models.Comment", "IdCommentNavigation")
                        .WithOne("Evaluation")
                        .HasForeignKey("Weather.Models.Evaluation", "IdComment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Evaluatio__ID_Co__5441852A");

                    b.Navigation("IdCommentNavigation");
                });

            modelBuilder.Entity("Weather.Models.MiniBooksCover", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithOne("MiniBooksCover")
                        .HasForeignKey("Weather.Models.MiniBooksCover", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__MiniBooks__Book___412EB0B6");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Weather.Models.Note", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithMany("Notes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Notes__Book_ID__4AB81AF0");

                    b.HasOne("Weather.Models.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Notes__UserID__49C3F6B7");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Weather.Models.Rating", b =>
                {
                    b.HasOne("Weather.Models.Book", "Book")
                        .WithOne("Rating")
                        .HasForeignKey("Weather.Models.Rating", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Ratings__Book_ID__46E78A0C");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Weather.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Weather.Models.Book", b =>
                {
                    b.Navigation("BooksAddit")
                        .IsRequired();

                    b.Navigation("BooksCover")
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("MiniBooksCover")
                        .IsRequired();

                    b.Navigation("Notes");

                    b.Navigation("Rating")
                        .IsRequired();
                });

            modelBuilder.Entity("Weather.Models.Comment", b =>
                {
                    b.Navigation("DeletedComment")
                        .IsRequired();

                    b.Navigation("Evaluation")
                        .IsRequired();
                });

            modelBuilder.Entity("Weather.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
