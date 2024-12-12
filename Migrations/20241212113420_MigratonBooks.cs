using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.Migrations
{
    public partial class MigratonBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBook = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Author_ID = table.Column<int>(type: "int", nullable: false),
                    Num_Сhapters = table.Column<int>(type: "int", nullable: false),
                    Num_Pages = table.Column<int>(type: "int", nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Books__Author_ID__3B75D760",
                        column: x => x.Author_ID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksAddit",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BooksAdd__C223F39411DA6CAE", x => x.Book_ID);
                    table.ForeignKey(
                        name: "FK__BooksAddi__Book___3E52440B",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksCovers",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BooksCov__C223F3946A10BBCC", x => x.Book_ID);
                    table.ForeignKey(
                        name: "FK__BooksCove__Book___440B1D61",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID_Comment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Cr_Data = table.Column<DateTime>(type: "date", nullable: false),
                    Cr_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Ch_Data = table.Column<DateTime>(type: "date", nullable: true),
                    Ch_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__E19B6D4C21A60D13", x => x.ID_Comment);
                    table.ForeignKey(
                        name: "FK__Comments__Book_I__4E88ABD4",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Comments__UserID__4D94879B",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiniBooksCovers",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    MiniCover = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MiniBook__C223F394C37E432C", x => x.Book_ID);
                    table.ForeignKey(
                        name: "FK__MiniBooks__Book___412EB0B6",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notes__4BAAF395CD81289A", x => new { x.UserID, x.Book_ID });
                    table.ForeignKey(
                        name: "FK__Notes__Book_ID__4AB81AF0",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Notes__UserID__49C3F6B7",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ratings__C223F394EE85E471", x => x.Book_ID);
                    table.ForeignKey(
                        name: "FK__Ratings__Book_ID__46E78A0C",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeletedComments",
                columns: table => new
                {
                    ID_Comment = table.Column<int>(type: "int", nullable: false),
                    Deleted_Data = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_Time = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DeletedC__E19B6D4CBA7D1F2A", x => x.ID_Comment);
                    table.ForeignKey(
                        name: "FK__DeletedCo__ID_Co__5165187F",
                        column: x => x.ID_Comment,
                        principalTable: "Comments",
                        principalColumn: "ID_Comment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    ID_Comment = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evaluati__E19B6D4C22F23EAF", x => x.ID_Comment);
                    table.ForeignKey(
                        name: "FK__Evaluatio__ID_Co__5441852A",
                        column: x => x.ID_Comment,
                        principalTable: "Comments",
                        principalColumn: "ID_Comment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author_ID",
                table: "Books",
                column: "Author_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Book_ID",
                table: "Comments",
                column: "Book_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Book_ID",
                table: "Notes",
                column: "Book_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksAddit");

            migrationBuilder.DropTable(
                name: "BooksCovers");

            migrationBuilder.DropTable(
                name: "DeletedComments");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "MiniBooksCovers");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
