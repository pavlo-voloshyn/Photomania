using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVI.KR.Migrations
{
    public partial class AddManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "ImageUser",
                columns: table => new
                {
                    UserImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserImagesId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUser", x => new { x.UserImagesId, x.UserImagesId1 });
                    table.ForeignKey(
                        name: "FK_ImageUser_AspNetUsers_UserImagesId1",
                        column: x => x.UserImagesId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUser_Images_UserImagesId",
                        column: x => x.UserImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_UserImagesId1",
                table: "ImageUser",
                column: "UserImagesId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUser");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "80278c72-b6e1-4a41-816b-fbe8dfeba9bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c7e4450-50da-4641-90d2-7b7b7c6e16b8"),
                column: "ConcurrencyStamp",
                value: "f6d4c227-e1a0-40e2-ab0d-405e1d1e8d97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7af323d-9e5b-4210-b203-aebd4cc782b5", "AQAAAAEAACcQAAAAECCBP2TEJ9Cm11L6Csf9CHg+9VPXBZptaxtZ3JNEgkUc1grxt7AA0vMrQEVjBh1UKw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
