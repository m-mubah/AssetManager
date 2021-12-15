using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class AddApprovalStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApprovalStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Rejected" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "48502ea0-cc27-4b30-ad15-20c7ab5f864c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f8c2546-0894-4eb4-894b-a0b6ce00c565", "AQAAAAEAACcQAAAAEEMrL32L3Y2wye5tr93Z6zZM4M3bZ/AGAyA+mEZPbgtnSiPTgknnx/OWKIsfI299rg==", "8cbfd6cb-2eb9-4502-a475-8030affdcfab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApprovalStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5092ae1e-8429-4c30-9866-d155988080b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50851694-ba12-4b9b-bc90-eb412ace7fce", "AQAAAAEAACcQAAAAEAw95cnOd3T4SoSG0oNPi10ZWGsEvcFZ/+uIgKNTr2eYWcAzU52t/SOPD+W1JdUKJQ==", "1a44aa1b-dd28-44c4-9481-08ca5a002f33" });
        }
    }
}
