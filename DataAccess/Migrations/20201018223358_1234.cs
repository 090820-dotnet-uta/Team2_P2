using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class _1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContractorId",
                table: "ProjectPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "HireRequests",
                columns: table => new
                {
                    HireRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    ContractorId = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HireRequests", x => x.HireRequestId);
                    table.ForeignKey(
                        name: "FK_HireRequests_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HireRequests_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HireRequests_ClientId",
                table: "HireRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HireRequests_ContractorId",
                table: "HireRequests",
                column: "ContractorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HireRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ContractorId",
                table: "ProjectPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
