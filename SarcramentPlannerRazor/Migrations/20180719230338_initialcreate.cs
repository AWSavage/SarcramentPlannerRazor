using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SarcramentPlannerRazor.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SacProgram",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Conducting = table.Column<string>(nullable: false),
                    OpeningHymn = table.Column<string>(nullable: false),
                    OpeningPrayer = table.Column<string>(nullable: false),
                    SacramentHymn = table.Column<string>(nullable: false),
                    IntermediateHymn = table.Column<string>(nullable: true),
                    ClosingHymn = table.Column<string>(nullable: false),
                    ClosingPrayer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacProgram", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SacProgramID = table.Column<int>(nullable: false),
                    SpeakerName = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    SpeakerOrder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_SacProgram_SacProgramID",
                        column: x => x.SacProgramID,
                        principalTable: "SacProgram",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacProgramID",
                table: "Speaker",
                column: "SacProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SacProgram");
        }
    }
}
