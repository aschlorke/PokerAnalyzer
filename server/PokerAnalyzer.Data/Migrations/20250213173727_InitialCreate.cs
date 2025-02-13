using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokerAnalyzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "PokerGames",
                columns: table => new
                {
                    PokerGameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerGames", x => x.PokerGameId);
                });

            migrationBuilder.CreateTable(
                name: "PokerHand",
                columns: table => new
                {
                    PokerHandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PokerGameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerHand", x => x.PokerHandId);
                    table.ForeignKey(
                        name: "FK_PokerHand_PokerGames_PokerGameId",
                        column: x => x.PokerGameId,
                        principalTable: "PokerGames",
                        principalColumn: "PokerGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Suit = table.Column<int>(type: "INTEGER", nullable: false),
                    PokerHandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Card_PokerHand_PokerHandId",
                        column: x => x.PokerHandId,
                        principalTable: "PokerHand",
                        principalColumn: "PokerHandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_PokerHandId",
                table: "Card",
                column: "PokerHandId");

            migrationBuilder.CreateIndex(
                name: "IX_PokerHand_PokerGameId",
                table: "PokerHand",
                column: "PokerGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PokerHand");

            migrationBuilder.DropTable(
                name: "PokerGames");
        }
    }
}
