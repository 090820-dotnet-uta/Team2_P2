using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class newst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PositionNeedsSkills",
                columns: table => new
                {
                    PositionNeedsSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionNeedsSkills", x => x.PositionNeedsSkillId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPositions",
                columns: table => new
                {
                    ProjectPositionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    ContractorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPositions", x => x.ProjectPositionsId);
                    table.ForeignKey(
                        name: "FK_ProjectPositions_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectPositions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPositions_ContractorId",
                table: "ProjectPositions",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPositions_PositionId",
                table: "ProjectPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPositions_ProjectId",
                table: "ProjectPositions",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionNeedsSkills");

            migrationBuilder.DropTable(
                name: "ProjectPositions");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "AspNetUsers");
        }
    }
}
