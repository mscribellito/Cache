using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cache.Migrations
{
    public partial class AddDateSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateSold",
                table: "Firearm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSold",
                table: "Firearm");
        }
    }
}
