using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace igreja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFielsByTask1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "MyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "MyTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "MyTasks");
        }
    }
}
