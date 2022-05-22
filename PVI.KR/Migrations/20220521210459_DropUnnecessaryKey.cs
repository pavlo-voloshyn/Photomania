using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVI.KR.Migrations
{
    public partial class DropUnnecessaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "9e8a22ed-cccb-4894-b9d1-e3bbd37cb1f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c7e4450-50da-4641-90d2-7b7b7c6e16b8"),
                column: "ConcurrencyStamp",
                value: "24d31677-f6f7-4d7f-909a-bab09292836b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40e628e9-d40a-40d6-ba30-53b1be353d16", "AQAAAAEAACcQAAAAEIUDhVKD/WQtFhIjQOElugNjRh8YOCyLcaIgy8+yJ4GhttbMdAi0CWfF3fPUiX/cIA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "e74267f9-db73-4495-89b4-7ae844d60650");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c7e4450-50da-4641-90d2-7b7b7c6e16b8"),
                column: "ConcurrencyStamp",
                value: "6bdaf402-e5a5-4d81-a87e-736a9fecb955");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef9a96bf-0077-45d1-be9e-2b85b19aaee2", "AQAAAAEAACcQAAAAEBNiDbErlKveCG5ns9JNo5Fe3jCtObpblSw4QslfC5OE6tFOMkoH8/11rB5OhGBIVQ==" });
        }
    }
}
