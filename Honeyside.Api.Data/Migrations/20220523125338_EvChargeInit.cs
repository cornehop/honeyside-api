using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honeyside.Api.Data.Migrations
{
    /// <summary>
    /// Migration that creates the initial tables for recording the charging of electric vehicles
    /// </summary>
    public partial class EvChargeInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryIsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalIdentifier = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvChargingStations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalIdentifier = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvChargingStations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvChargingStations_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvCharges",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EvChargingStationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kwh = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvCharges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvCharges_EvChargingStations_EvChargingStationID",
                        column: x => x.EvChargingStationID,
                        principalTable: "EvChargingStations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvCharges_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvCharges_EvChargingStationID",
                table: "EvCharges",
                column: "EvChargingStationID");

            migrationBuilder.CreateIndex(
                name: "IX_EvCharges_InvoiceID",
                table: "EvCharges",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_EvChargingStations_AddressID",
                table: "EvChargingStations",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvCharges");

            migrationBuilder.DropTable(
                name: "EvChargingStations");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
