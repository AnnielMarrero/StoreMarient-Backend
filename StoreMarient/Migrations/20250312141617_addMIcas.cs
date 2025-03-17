using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreMarient.Migrations
{
    /// <inheritdoc />
    public partial class addMIcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Micas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Micas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Micas_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Micas_Model_PhoneTypeId",
                table: "Micas",
                columns: new[] { "Model", "PhoneTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Micas_PhoneTypeId",
                table: "Micas",
                column: "PhoneTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Micas");
        }
    }
}
