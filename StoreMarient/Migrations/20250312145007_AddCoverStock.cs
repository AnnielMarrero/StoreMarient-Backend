using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreMarient.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverStocks_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverStocks_Covers_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Covers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverStocks_CoverId_CoverTypeId",
                table: "CoverStocks",
                columns: new[] { "CoverId", "CoverTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoverStocks_CoverTypeId",
                table: "CoverStocks",
                column: "CoverTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverStocks");
        }
    }
}
