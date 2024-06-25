using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2_Poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cars_colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "models",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_rentals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_rentals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_car_rentals_cars_CarID",
                        column: x => x.CarID,
                        principalTable: "cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_rentals_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ID", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Koszykowa 86", "Jan", "Kowalski" },
                    { 2, "Tenkaichi Street", "John", "Yakuza" }
                });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "white" },
                    { 2, "black" }
                });

            migrationBuilder.InsertData(
                table: "models",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Skoda" }
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "ID", "ColorID", "ModelID", "Name", "PricePerDay", "Seats", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 1, "Camry", 120, 4, "2D4HN11EX9R686008" },
                    { 2, 2, 2, "Octavia", 170, 4, "JTDBR32E630013672" }
                });

            migrationBuilder.InsertData(
                table: "car_rentals",
                columns: new[] { "ID", "CarID", "ClientID", "DateFrom", "DateTo", "Discount", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 480 },
                    { 2, 1, 1, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 360 },
                    { 3, 2, 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1530 },
                    { 4, 2, 2, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 340 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_CarID",
                table: "car_rentals",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_ClientID",
                table: "car_rentals",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ColorID",
                table: "cars",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ModelID",
                table: "cars",
                column: "ModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car_rentals");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
