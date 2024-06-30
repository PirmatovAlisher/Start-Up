using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class CategoryModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 802, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d140eb54-ed6e-4ff2-9199-71fcbe722ef7",
                column: "ConcurrencyStamp",
                value: "72422fd4-4ba6-44ee-ab86-c410c64e978a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de820986-a707-4cc5-8306-776812617837",
                column: "ConcurrencyStamp",
                value: "f5f4018b-0e50-4089-9371-32570febb816");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "06-Jul-24 11:35:58 AM");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "256ac0cc-c4b0-458d-957d-24cbfd49225b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac1fbae8-8f93-4550-bf88-fd0bec603afb", "AQAAAAIAAYagAAAAEPKFdBl5csKp/J56HzfheBNZho26FvqhjyHoQFGEQjYiu3o5lq860jJa3OtnshUVVw==", "8d1da12c-c977-42db-b7a7-2713aa528b76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dce8cfd5-d290-4353-b50d-58707ed8da4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89aa8981-ab26-455b-8a4d-3ad93396e198", "AQAAAAIAAYagAAAAEMSkqdqQiK3Vctb69hgnLBxAs88KpbZkK34HEsHAS5cA6ZyHBTqhxkF81itxssMFUA==", "24adf50d-2794-4cc6-b170-bc588004d168" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 802, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 802, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 803, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 804, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 804, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 804, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 30, 11, 35, 58, 804, DateTimeKind.Local).AddTicks(2402));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "21-Jun-24 12:57:58 PM");

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
    }
}
