using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class UpdateApprovalSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalChanges_AssetApprovals_ApprovalId",
                table: "ApprovalChanges");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalChanges_ApprovalId",
                table: "ApprovalChanges");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "ApprovalChanges");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalChangeId",
                table: "AssetApprovals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ApprovalChanges",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AssetApprovals_ApprovalChangeId",
                table: "AssetApprovals",
                column: "ApprovalChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetApprovals_ApprovalChanges_ApprovalChangeId",
                table: "AssetApprovals",
                column: "ApprovalChangeId",
                principalTable: "ApprovalChanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetApprovals_ApprovalChanges_ApprovalChangeId",
                table: "AssetApprovals");

            migrationBuilder.DropIndex(
                name: "IX_AssetApprovals_ApprovalChangeId",
                table: "AssetApprovals");

            migrationBuilder.DropColumn(
                name: "ApprovalChangeId",
                table: "AssetApprovals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ApprovalChanges");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalId",
                table: "ApprovalChanges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c2eaa5e6-2519-4fe7-8f89-43907b074649");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05ad9c85-f063-4371-b1eb-44d2489b4fd7", "AQAAAAEAACcQAAAAEKkwMXMeHTuZ9YELgBWuO4ZheQUrOukEPGVyhgT6yVWYBYAEfUrsBETZIyZTqJxa6Q==", "435bafcd-915d-44bb-9d4b-620594325567" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalChanges_ApprovalId",
                table: "ApprovalChanges",
                column: "ApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalChanges_AssetApprovals_ApprovalId",
                table: "ApprovalChanges",
                column: "ApprovalId",
                principalTable: "AssetApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
