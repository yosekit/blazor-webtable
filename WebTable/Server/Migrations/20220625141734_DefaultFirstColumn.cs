using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTable.Server.Migrations
{
    public partial class DefaultFirstColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "Id", "Name", "Type", "TypeId" },
                values: new object[] { 1, "Name", "Text", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
