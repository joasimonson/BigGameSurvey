using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BigGameSurvey.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GENRE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GENRE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_GAME",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_TITLE = table.Column<string>(maxLength: 50, nullable: false),
                    DS_PLATFORM = table.Column<string>(maxLength: 20, nullable: false),
                    FK_GENRE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GAME", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_GAME_TB_GENRE_FK_GENRE",
                        column: x => x.FK_GENRE,
                        principalTable: "TB_GENRE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RECORD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DS_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DT_INSERTEDAT = table.Column<DateTime>(nullable: false),
                    FK_GAME = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RECORD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_RECORD_TB_GAME_FK_GAME",
                        column: x => x.FK_GAME,
                        principalTable: "TB_GAME",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_GAME_FK_GENRE",
                table: "TB_GAME",
                column: "FK_GENRE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RECORD_FK_GAME",
                table: "TB_RECORD",
                column: "FK_GAME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RECORD");

            migrationBuilder.DropTable(
                name: "TB_GAME");

            migrationBuilder.DropTable(
                name: "TB_GENRE");
        }
    }
}
