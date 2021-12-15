using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Infrastructure.Migrations
{
    public partial class AddSystemAdministratoStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5092ae1e-8429-4c30-9866-d155988080b4");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { -1, "System" });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Name" },
                values: new object[] { -1, "System Administrator" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "DepartmentId", "FullName", "IsDepartmentHead", "JobTitleId", "NID", "StaffNumber", "UserId" },
                values: new object[] { new Guid("8b6bcca1-88a7-4e1c-9d2b-12b0f7030f05"), -1, "Administrator", false, -1, null, null, "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StaffId" },
                values: new object[] { "50851694-ba12-4b9b-bc90-eb412ace7fce", "AQAAAAEAACcQAAAAEAw95cnOd3T4SoSG0oNPi10ZWGsEvcFZ/+uIgKNTr2eYWcAzU52t/SOPD+W1JdUKJQ==", "1a44aa1b-dd28-44c4-9481-08ca5a002f33", new Guid("8b6bcca1-88a7-4e1c-9d2b-12b0f7030f05") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("8b6bcca1-88a7-4e1c-9d2b-12b0f7030f05"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "JobTitles",
                keyColumn: "Id",
                keyValue: -1);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StaffId" },
                values: new object[] { "15b9b462-26c5-42ec-8a99-51fdba3dce09", "AQAAAAEAACcQAAAAEJcNOHCmLOci4eeXLzbiG0ZnRkKRScn/q+t2oYfoQybZ2WPOpEQDAQyExg0+e0bAwg==", "5a940601-25b0-4be5-a414-0e3cc4fdcb20", null });
        }
    }
}
