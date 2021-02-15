using Microsoft.EntityFrameworkCore.Migrations;

namespace Cache.Data.Migrations
{
    public partial class AddUserIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Firearm",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CaliberGauge",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Firearm");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CaliberGauge");
        }
    }
}
