using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixedAssetAPI.Migrations
{
    /// <inheritdoc />
    public partial class custodians_table_typo_fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Custodions_CustodianId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Custodions_Departments_DepartmentId",
                table: "Custodions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custodions",
                table: "Custodions");

            migrationBuilder.RenameTable(
                name: "Custodions",
                newName: "Custodians");

            migrationBuilder.RenameColumn(
                name: "CustodionId",
                table: "Custodians",
                newName: "CustodianId");

            migrationBuilder.RenameIndex(
                name: "IX_Custodions_DepartmentId",
                table: "Custodians",
                newName: "IX_Custodians_DepartmentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarketValue",
                table: "Assets",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BookValue",
                table: "Assets",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentDepreciatedValue",
                table: "Assets",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Assets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custodians",
                table: "Custodians",
                column: "CustodianId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DepartmentId",
                table: "Assets",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Custodians_CustodianId",
                table: "Assets",
                column: "CustodianId",
                principalTable: "Custodians",
                principalColumn: "CustodianId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Departments_DepartmentId",
                table: "Assets",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Custodians_Departments_DepartmentId",
                table: "Custodians",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Custodians_CustodianId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Departments_DepartmentId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Custodians_Departments_DepartmentId",
                table: "Custodians");

            migrationBuilder.DropIndex(
                name: "IX_Assets_DepartmentId",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custodians",
                table: "Custodians");

            migrationBuilder.DropColumn(
                name: "CurrentDepreciatedValue",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Custodians",
                newName: "Custodions");

            migrationBuilder.RenameColumn(
                name: "CustodianId",
                table: "Custodions",
                newName: "CustodionId");

            migrationBuilder.RenameIndex(
                name: "IX_Custodians_DepartmentId",
                table: "Custodions",
                newName: "IX_Custodions_DepartmentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarketValue",
                table: "Assets",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BookValue",
                table: "Assets",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custodions",
                table: "Custodions",
                column: "CustodionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Custodions_CustodianId",
                table: "Assets",
                column: "CustodianId",
                principalTable: "Custodions",
                principalColumn: "CustodionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Custodions_Departments_DepartmentId",
                table: "Custodions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
