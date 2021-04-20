using Microsoft.EntityFrameworkCore.Migrations;

namespace GuzelSozlerim.Data.Migrations
{
    public partial class KullaniciSozIliski2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciSoz_AspNetUsers_KullaniciId",
                table: "KullaniciSoz");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciSoz_GuzelSozler_GuzelSozId",
                table: "KullaniciSoz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KullaniciSoz",
                table: "KullaniciSoz");

            migrationBuilder.RenameTable(
                name: "KullaniciSoz",
                newName: "KullaniciSozler");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciSoz_GuzelSozId",
                table: "KullaniciSozler",
                newName: "IX_KullaniciSozler_GuzelSozId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KullaniciSozler",
                table: "KullaniciSozler",
                columns: new[] { "KullaniciId", "GuzelSozId" });

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciSozler_AspNetUsers_KullaniciId",
                table: "KullaniciSozler",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciSozler_GuzelSozler_GuzelSozId",
                table: "KullaniciSozler",
                column: "GuzelSozId",
                principalTable: "GuzelSozler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciSozler_AspNetUsers_KullaniciId",
                table: "KullaniciSozler");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciSozler_GuzelSozler_GuzelSozId",
                table: "KullaniciSozler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KullaniciSozler",
                table: "KullaniciSozler");

            migrationBuilder.RenameTable(
                name: "KullaniciSozler",
                newName: "KullaniciSoz");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciSozler_GuzelSozId",
                table: "KullaniciSoz",
                newName: "IX_KullaniciSoz_GuzelSozId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KullaniciSoz",
                table: "KullaniciSoz",
                columns: new[] { "KullaniciId", "GuzelSozId" });

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciSoz_AspNetUsers_KullaniciId",
                table: "KullaniciSoz",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciSoz_GuzelSozler_GuzelSozId",
                table: "KullaniciSoz",
                column: "GuzelSozId",
                principalTable: "GuzelSozler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
