using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Categories_CategoryId",
                table: "Portfolios");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 637, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 637, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 637, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 637, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 22, 26, 47, 638, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Categories_CategoryId",
                table: "Portfolios",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Categories_CategoryId",
                table: "Portfolios");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 159, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 160, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 161, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 161, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 161, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 8, 12, 29, 11, 161, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Categories_CategoryId",
                table: "Portfolios",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
