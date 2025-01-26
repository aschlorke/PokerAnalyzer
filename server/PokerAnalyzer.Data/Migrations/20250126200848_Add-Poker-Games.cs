using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokerAnalyzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPokerGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokerGameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_PokerGames_PokerGameId",
                        column: x => x.PokerGameId,
                        principalTable: "PokerGames",
                        principalColumn: "PokerGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokerGameResults",
                columns: table => new
                {
                    PokerGameResultsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokerGameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Winner = table.Column<string>(type: "TEXT", nullable: false),
                    WinningHand = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerGameResults", x => x.PokerGameResultsId);
                    table.ForeignKey(
                        name: "FK_PokerGameResults_PokerGames_PokerGameId",
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
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rank = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Suit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Card_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_PlayerId",
                table: "Card",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PokerGameId",
                table: "Player",
                column: "PokerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PokerGameResults_PokerGameId",
                table: "PokerGameResults",
                column: "PokerGameId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "PokerGameResults");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PokerGames");
        }
    }
}
