using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkModelCode.Infrastructure.Migrations
{
    public partial class InitialCreateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsTimeCharacterisitc_Projects_ProjectId",
                table: "ItemsTimeCharacterisitc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsTimeCharacterisitc",
                table: "ItemsTimeCharacterisitc");

            migrationBuilder.RenameTable(
                name: "ItemsTimeCharacterisitc",
                newName: "ItemsTimeCharacteristic");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsTimeCharacterisitc_ProjectId",
                table: "ItemsTimeCharacteristic",
                newName: "IX_ItemsTimeCharacteristic_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsTimeCharacteristic",
                table: "ItemsTimeCharacteristic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsTimeCharacteristic_Projects_ProjectId",
                table: "ItemsTimeCharacteristic",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsTimeCharacteristic_Projects_ProjectId",
                table: "ItemsTimeCharacteristic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsTimeCharacteristic",
                table: "ItemsTimeCharacteristic");

            migrationBuilder.RenameTable(
                name: "ItemsTimeCharacteristic",
                newName: "ItemsTimeCharacterisitc");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsTimeCharacteristic_ProjectId",
                table: "ItemsTimeCharacterisitc",
                newName: "IX_ItemsTimeCharacterisitc_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsTimeCharacterisitc",
                table: "ItemsTimeCharacterisitc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsTimeCharacterisitc_Projects_ProjectId",
                table: "ItemsTimeCharacterisitc",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
