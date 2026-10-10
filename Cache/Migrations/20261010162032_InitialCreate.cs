using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cache.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaliberGauge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaliberGauge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firearm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManufacturerImporter = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CaliberGaugeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    PurchaseLocation = table.Column<string>(type: "TEXT", nullable: true),
                    SoldTransferredTo = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firearm_CaliberGauge_CaliberGaugeId",
                        column: x => x.CaliberGaugeId,
                        principalTable: "CaliberGauge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firearm_CaliberGaugeId",
                table: "Firearm",
                column: "CaliberGaugeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firearm");

            migrationBuilder.DropTable(
                name: "CaliberGauge");
        }
    }
}
