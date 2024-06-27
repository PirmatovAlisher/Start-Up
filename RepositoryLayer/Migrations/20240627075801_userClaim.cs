using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class userClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserClaims",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 692, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d140eb54-ed6e-4ff2-9199-71fcbe722ef7",
                column: "ConcurrencyStamp",
                value: "5eef3fea-3879-4235-bfd5-4f3d334e3512");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de820986-a707-4cc5-8306-776812617837",
                column: "ConcurrencyStamp",
                value: "99738a46-0d19-495d-9835-fae32dddf681");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[] { 1, "AdminObserverExpireDate", "21-Jun-24 12:57:58 PM", "AppUserClaim", "dce8cfd5-d290-4353-b50d-58707ed8da4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "256ac0cc-c4b0-458d-957d-24cbfd49225b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddde2763-fe4f-4211-b2ef-00e592c246a2", "AQAAAAIAAYagAAAAEBVVH7XzRNZ9c6tWeHhEzzqHoR8W6jYO2HuL21UYR3DnFDzzZX8ZnEDUNB9VtZ2x4g==", "2cb40710-4aaa-49bf-a383-68aa8c447880" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dce8cfd5-d290-4353-b50d-58707ed8da4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "688f298a-a239-4b90-aa01-2ddc6a9ff028", "AQAAAAIAAYagAAAAEH2wdrTFvKxSGIpHckjO/ZFByqKEiTNtrU3uSVWRUwiW13ryaM+1CJTlSyPAlFklcA==", "e160151b-8a92-4807-8c6d-9ea00e3af0a3" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 695, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 695, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 695, DateTimeKind.Local).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 696, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 696, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 696, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 696, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 696, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 27, 12, 57, 58, 697, DateTimeKind.Local).AddTicks(6066));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserClaims");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d140eb54-ed6e-4ff2-9199-71fcbe722ef7",
                column: "ConcurrencyStamp",
                value: "d919a5b9-4c40-4d87-96ee-2676cbac9c9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de820986-a707-4cc5-8306-776812617837",
                column: "ConcurrencyStamp",
                value: "21ad7753-ca1d-476b-8ab4-60c79c797931");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "256ac0cc-c4b0-458d-957d-24cbfd49225b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd16ed86-35cd-40b6-97f6-f086f3ffe692", "AQAAAAIAAYagAAAAENIED/Len0vcr2O3tgDhHQgeOsEutQ+zQKAuyDvSuE+DBg0lonDA0Oxs56bq5AFCNA==", "2d888246-854c-40f7-9516-1ec768967ca5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dce8cfd5-d290-4353-b50d-58707ed8da4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dd36eb8-5931-4594-a4e6-8bd5b3b794cc", "AQAAAAIAAYagAAAAEITx4eu+6deC/g9hIOY8qdwGuPCLUnaR3d5j8kMD5ZRReTeicax7YoLxdH6/Tm+e3Q==", "2f960dc5-587d-44d9-976c-93b71ffb9ca2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 58, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 12, 30, 54, 59, DateTimeKind.Local).AddTicks(5930));
        }
    }
}
