using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class AddApprovalPendingStatusToAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "34dc044d-6241-440e-b277-e320ec59da46");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15b9b462-26c5-42ec-8a99-51fdba3dce09", "AQAAAAEAACcQAAAAEJcNOHCmLOci4eeXLzbiG0ZnRkKRScn/q+t2oYfoQybZ2WPOpEQDAQyExg0+e0bAwg==", "5a940601-25b0-4be5-a414-0e3cc4fdcb20" });

            migrationBuilder.UpdateData(
                table: "AssetStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Unassigned");

            migrationBuilder.InsertData(
                table: "AssetStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Approval Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5d25d2b4-6d52-40d7-a6e4-461a1f84a7cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9ff20c-6d91-4a2e-97f8-45cf051e3fed", "AQAAAAEAACcQAAAAEBGge02wMZXNUF1EQ9X3iDjBu/+lxI3jBa54rp3Kjd+mqQePD3Lk53PJlGLZwU7BRQ==", "abc95fae-80db-4c0a-bba7-7ebcd79f0480" });

            migrationBuilder.UpdateData(
                table: "AssetStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Not Assigned");
        }
    }
}
