using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Call = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Clients = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Projects = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    HoursOfSupport = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    HardWorkers = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abouts_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 27, 16, 16, 31, 936, DateTimeKind.Local).AddTicks(9905), "Projects", null },
                    { 2, new DateTime(2024, 5, 27, 16, 16, 31, 936, DateTimeKind.Local).AddTicks(9908), "SiteWorks", null }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Call", "CreatedDate", "Email", "Location", "Map", "UpdatedDate" },
                values: new object[] { 1, "+998-94-361-99-25", new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(1462), "pirmatovalisher000@gmail.com", "Tarraqiyot 35, 37-Xamza MFY, Chirchiq shaxri, Toshkent v., Uzb", "Location Link here", null });

            migrationBuilder.InsertData(
                table: "HomePages",
                columns: new[] { "Id", "CreatedDate", "Description", "Header", "UpdatedDate", "VideoLink" },
                values: new object[] { 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(2970), "Urna porttitor rhoncus dolor purus non enim praesent elementum facilisis. Nec nam aliquam sem et tortor. Est pellentesque elit ullamcorper dignissim cras tincidunt lobortis. Diam in arcu cursus euismod quis viverra nibh cras. Velit sed ullamcorper morbi tincidunt ornare. ", "Rutrum tellus pellentesque eu tincidunt.", null, "Video Link here" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "Icon", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(5885), "Augue interdum velit euismod in. Egestas dui id ornare arcu. Duis at tellus at urna condimentum mattis pellentesque id nibh. ", "bi bi-service1", "Tristique", null },
                    { 2, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(5888), "Donec adipiscing tristique risus nec feugiat in fermentum posuere.", "bi bi-service2", "Faucibus", null },
                    { 3, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(5889), "Neque egestas congue quisque egestas diam in.", "bi bi-service3", "Porttitor", null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedDate", "Facebook", "Instagram", "LinkedId", "Twitter", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(7177), "Facebook", "Instagram", null, "Twitter", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "Facebook", "FileName", "FileType", "FullName", "Instagram", "LinkedId", "Title", "Twitter", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(8607), "Test", "Lectus quam", ".sat", "Duis Tristique ", "Test", "Test", "Augue interdum velit euismod in.", null, null });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "CreatedDate", "FileName", "FileType", "FullName", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Vitae suscipit tellus mauris a diam maecenas sed.", new DateTime(2024, 5, 27, 16, 16, 31, 938, DateTimeKind.Local).AddTicks(98), "Hendrerit gravida", ".jpeg", "Massa Lobortis", "At elementum eu facilisis", null },
                    { 2, "Nulla posuere sollicitudin", new DateTime(2024, 5, 27, 16, 16, 31, 938, DateTimeKind.Local).AddTicks(103), "Proin sed libero enim", ".cs", "Vitae Eget", "Faucibus a pellentesque", null },
                    { 3, "Rutrum tellus pellentesque eu tincidunt.", new DateTime(2024, 5, 27, 16, 16, 31, 938, DateTimeKind.Local).AddTicks(104), "Donec adipiscing", ".cshtml", "Rutrum Cursus", " Sodales ut eu sem", null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Clients", "CreatedDate", "Description", "FileName", "FileType", "HardWorkers", "Header", "HoursOfSupport", "Projects", "SocialMediaId", "UpdatedDate" },
                values: new object[] { 1, 5, new DateTime(2024, 5, 27, 16, 16, 31, 936, DateTimeKind.Local).AddTicks(8308), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In ante metus dictum at tempor commodo ullamcorper a lacus. Suspendisse in est ante in nibh mauris. Lorem ipsum dolor sit amet consectetur adipiscing elit. Erat imperdiet sed euismod nisi. Sed blandit libero volutpat sed cras ornare arcu dui vivamus. Ut morbi tincidunt augue interdum velit euismod in pellentesque massa.", "Test", "Test", 3, "Euismod lacinia at quis risus", 150, 5, 1, null });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FileName", "FileType", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(4446), "Fames ac turpis", ".blend", "Sed velit dignissim sodales ut eu sem integer vitae justo.", null },
                    { 2, 2, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(4451), " Sed id interdum", ".DXF", "Arcu bibendum at varius vel.", null },
                    { 3, 1, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(4452), "Mattis ac turpis", ".blend", "Mattis pellentesque id nibh", null },
                    { 4, 2, new DateTime(2024, 5, 27, 16, 16, 31, 937, DateTimeKind.Local).AddTicks(4453), " Tellus id interdum", ".DXF", "Nec ullamcorper sit amet risus nullam eget felis eget.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_SocialMediaId",
                table: "Abouts",
                column: "SocialMediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CategoryId",
                table: "Portfolios",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
