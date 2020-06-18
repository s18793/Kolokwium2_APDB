using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2_apdb.Migrations
{
    public partial class InitalDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.IdChampionship);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<int>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(maxLength: 30, nullable: false),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipTeams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false),
                    IdChampionship = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipTeams", x => new { x.IdChampionship, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_ChampionshipTeams_Championships_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championships",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipTeams_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    PlayerIdPlayer = table.Column<int>(nullable: true),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => new { x.IdPlayer, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerIdPlayer",
                        column: x => x.PlayerIdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTeams_IdTeam",
                table: "ChampionshipTeams",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_IdTeam",
                table: "PlayerTeams",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerIdPlayer",
                table: "PlayerTeams",
                column: "PlayerIdPlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipTeams");

            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
