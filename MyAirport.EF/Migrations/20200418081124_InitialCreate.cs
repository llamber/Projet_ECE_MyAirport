using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirport.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    VolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cie = table.Column<string>(nullable: false),
                    Lig = table.Column<string>(nullable: false),
                    Dhc = table.Column<DateTime>(nullable: true),
                    Pkg = table.Column<string>(nullable: true),
                    Imm = table.Column<string>(nullable: true),
                    Pax = table.Column<int>(nullable: true),
                    Des = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.VolId);
                });

            migrationBuilder.CreateTable(
                name: "Bagages",
                columns: table => new
                {
                    BagageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolId = table.Column<int>(nullable: true),
                    CodeIata = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Classe = table.Column<string>(nullable: true),
                    Prioritaire = table.Column<bool>(nullable: true),
                    Sta = table.Column<string>(nullable: true),
                    Ssur = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Escale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagages", x => x.BagageID);
                    table.ForeignKey(
                        name: "FK_Bagages_Vols_VolId",
                        column: x => x.VolId,
                        principalTable: "Vols",
                        principalColumn: "VolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bagages_VolId",
                table: "Bagages",
                column: "VolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bagages");

            migrationBuilder.DropTable(
                name: "Vols");
        }
    }
}
