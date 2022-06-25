using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTable.Server.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ColumnId",
                table: "Items",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RowId",
                table: "Items",
                column: "RowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Columns_ColumnId",
                table: "Items",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Rows_RowId",
                table: "Items",
                column: "RowId",
                principalTable: "Rows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Columns_ColumnId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Rows_RowId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ColumnId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RowId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "Items");
        }
    }
}
