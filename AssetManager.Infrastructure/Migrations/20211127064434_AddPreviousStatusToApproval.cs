using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class AddPreviousStatusToApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousAssetStatus",
                table: "AssetApprovals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "89cd2a92-8ec6-4862-81b9-aede8b3bd68f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd7cc0cf-bc26-49d3-8a89-a2c39a92efd1", "AQAAAAEAACcQAAAAEHiku77gvq1cax4LU8UytEaYJO8FKFimCq2/X5pnXJwfiKmIA7qmdKv0oBEU9X/FAg==", "0a2667dc-5667-4be3-938e-22b9902b60fb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousAssetStatus",
                table: "AssetApprovals");

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
    }
}
