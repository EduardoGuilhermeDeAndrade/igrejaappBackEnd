using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace igreja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_IgrejaTenants_IgrejaTenantId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Responsibilities",
                newName: "IgrejaTenantId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Assignments",
                newName: "IgrejaTenantId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Addresses",
                newName: "IgrejaTenantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "IgrejaTenantId",
                table: "Temples",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_IgrejaTenants_IgrejaTenantId",
                table: "Temples",
                column: "IgrejaTenantId",
                principalTable: "IgrejaTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_IgrejaTenants_IgrejaTenantId",
                table: "Temples");

            migrationBuilder.RenameColumn(
                name: "IgrejaTenantId",
                table: "Responsibilities",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "IgrejaTenantId",
                table: "Assignments",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "IgrejaTenantId",
                table: "Addresses",
                newName: "TenantId");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IgrejaTenantId",
                table: "Temples",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Temples",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_IgrejaTenants_IgrejaTenantId",
                table: "Temples",
                column: "IgrejaTenantId",
                principalTable: "IgrejaTenants",
                principalColumn: "Id");
        }
    }
}
