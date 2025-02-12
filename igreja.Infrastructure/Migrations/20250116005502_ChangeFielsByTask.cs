using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace igreja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFielsByTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "MyTasks");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "MyTasks",
                newName: "DeadlineInDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "MyTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "MyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsableId",
                table: "MyTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "ResponsableId",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MyTasks");

            migrationBuilder.RenameColumn(
                name: "DeadlineInDate",
                table: "MyTasks",
                newName: "DueDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "MyTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
