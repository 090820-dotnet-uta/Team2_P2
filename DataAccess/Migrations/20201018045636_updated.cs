using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPositions_Contractors_ContractorId",
                table: "ProjectPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPositions_Positions_PositionId",
                table: "ProjectPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPositions_Projects_ProjectId",
                table: "ProjectPositions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPositions_ContractorId",
                table: "ProjectPositions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPositions_PositionId",
                table: "ProjectPositions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPositions_ProjectId",
                table: "ProjectPositions");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectPositions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "ProjectPositions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractorId",
                table: "ProjectPositions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "ProjectPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ContractorId",
                table: "ProjectPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPositions_Contractors_ContractorId",
                table: "ProjectPositions",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "ContractorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPositions_Positions_PositionId",
                table: "ProjectPositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPositions_Projects_ProjectId",
                table: "ProjectPositions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
