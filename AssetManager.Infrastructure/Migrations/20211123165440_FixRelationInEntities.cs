using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class FixRelationInEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedDate",
                table: "Assets",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "AssetId",
                table: "AssetHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RequestedByStaffId",
                table: "AssetApprovals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByStaffId",
                table: "AssetApprovals",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AssetHistories_AssetId",
                table: "AssetHistories",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetApprovals_RequestedByStaffId",
                table: "AssetApprovals",
                column: "RequestedByStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetApprovals_UpdatedByStaffId",
                table: "AssetApprovals",
                column: "UpdatedByStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetApprovals_Staffs_RequestedByStaffId",
                table: "AssetApprovals",
                column: "RequestedByStaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetApprovals_Staffs_UpdatedByStaffId",
                table: "AssetApprovals",
                column: "UpdatedByStaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetHistories_Assets_AssetId",
                table: "AssetHistories",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetApprovals_Staffs_RequestedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetApprovals_Staffs_UpdatedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetHistories_Assets_AssetId",
                table: "AssetHistories");

            migrationBuilder.DropIndex(
                name: "IX_AssetHistories_AssetId",
                table: "AssetHistories");

            migrationBuilder.DropIndex(
                name: "IX_AssetApprovals_RequestedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.DropIndex(
                name: "IX_AssetApprovals_UpdatedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AssetHistories");

            migrationBuilder.DropColumn(
                name: "RequestedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.DropColumn(
                name: "UpdatedByStaffId",
                table: "AssetApprovals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedDate",
                table: "Assets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5903501d-e635-4627-bc97-52d146dde882");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53a96e67-8ce9-4748-9146-b0531a5efb34", "AQAAAAEAACcQAAAAEOA4Bi6SsjtbuQAE5JEjWzVVzh5pyUqCG+n5EKGpKjjJGVsdT6r1C00iM1Bb9Dv/UQ==", "e641c0b1-876c-4b4d-90d1-58997c45b010" });
        }
    }
}
