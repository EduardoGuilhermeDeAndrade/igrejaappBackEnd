using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace igreja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Churchs_ChurchId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FinancialMovements");

            migrationBuilder.DropTable(
                name: "AccountApplications");

            migrationBuilder.DropTable(
                name: "Temples");

            migrationBuilder.DropTable(
                name: "Churchs");

            migrationBuilder.DropIndex(
                name: "IX_Users_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Members_ChurchId",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "IgrejaTenantId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IgrejaTenantId",
                table: "Users",
                column: "IgrejaTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_IgrejaTenantId",
                table: "Users",
                column: "IgrejaTenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_IgrejaTenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IgrejaTenantId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IgrejaTenantId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AccountApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Churchs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChurchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temples_Churchs_ChurchId",
                        column: x => x.ChurchId,
                        principalTable: "Churchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TempleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContributionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMovements_AccountApplications_AccountApplicationId",
                        column: x => x.AccountApplicationId,
                        principalTable: "AccountApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialMovements_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialMovements_Temples_TempleId",
                        column: x => x.TempleId,
                        principalTable: "Temples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ChurchId",
                table: "Members",
                column: "ChurchId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovements_AccountApplicationId",
                table: "FinancialMovements",
                column: "AccountApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovements_MemberId",
                table: "FinancialMovements",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovements_TempleId",
                table: "FinancialMovements",
                column: "TempleId");

            migrationBuilder.CreateIndex(
                name: "IX_Temples_ChurchId",
                table: "Temples",
                column: "ChurchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Churchs_ChurchId",
                table: "Members",
                column: "ChurchId",
                principalTable: "Churchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
