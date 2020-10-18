using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class _12435 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HireRequests",
                columns: new[] { "HireRequestId", "ClientId", "ContractorId", "PositionId", "RequestStatus" },
                values: new object[] { 1, null, null, 1, "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HireRequests",
                keyColumn: "HireRequestId",
                keyValue: 1);
        }
    }
}
