using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoPtco.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detections",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idDevice = table.Column<int>(type: "INTEGER", nullable: false),
                    temperatura = table.Column<int>(type: "INTEGER", nullable: false),
                    umidita = table.Column<int>(type: "INTEGER", nullable: false),
                    pressione = table.Column<int>(type: "INTEGER", nullable: false),
                    altitudine = table.Column<int>(type: "INTEGER", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detections", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detections");
        }
    }
}
