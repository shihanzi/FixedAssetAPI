using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FixedAssetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedRemainingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Valuations",
                table: "Valuations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disposals",
                table: "Disposals");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Valuations",
                newName: "AssetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transfers",
                newName: "ToLocaiotnId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disposals",
                newName: "AssetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Custodians",
                table: "Custodions",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "AssetId",
                table: "Valuations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ValuationId",
                table: "Valuations",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketValue",
                table: "Valuations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ValuatedBy",
                table: "Valuations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValuationDate",
                table: "Valuations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ToLocaiotnId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Transfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Transfers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromLocationId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Transfers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "Transfers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Locations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Locations",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AssetId",
                table: "Disposals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "DisposalId",
                table: "Disposals",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Disposals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Disposals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisposalMethod",
                table: "Disposals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Disposals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Disposals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Departments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Custodions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Custodions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Valuations",
                table: "Valuations",
                column: "ValuationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "TransferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disposals",
                table: "Disposals",
                column: "DisposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_AssetId",
                table: "Valuations",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_AssetId",
                table: "Transfers",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DepartmentId",
                table: "Locations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Disposals_AssetId",
                table: "Disposals",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Custodions_DepartmentId",
                table: "Custodions",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Custodions_Departments_DepartmentId",
                table: "Custodions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disposals_Assets_AssetId",
                table: "Disposals",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Departments_DepartmentId",
                table: "Locations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Assets_AssetId",
                table: "Transfers",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Valuations_Assets_AssetId",
                table: "Valuations",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Custodions_Departments_DepartmentId",
                table: "Custodions");

            migrationBuilder.DropForeignKey(
                name: "FK_Disposals_Assets_AssetId",
                table: "Disposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Departments_DepartmentId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Assets_AssetId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Valuations_Assets_AssetId",
                table: "Valuations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Valuations",
                table: "Valuations");

            migrationBuilder.DropIndex(
                name: "IX_Valuations_AssetId",
                table: "Valuations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_AssetId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_DepartmentId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disposals",
                table: "Disposals");

            migrationBuilder.DropIndex(
                name: "IX_Disposals_AssetId",
                table: "Disposals");

            migrationBuilder.DropIndex(
                name: "IX_Custodions_DepartmentId",
                table: "Custodions");

            migrationBuilder.DropColumn(
                name: "ValuationId",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "MarketValue",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "ValuatedBy",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "ValuationDate",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "FromLocationId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DisposalId",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "DisposalMethod",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Disposals");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Custodions");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Custodions");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Valuations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ToLocaiotnId",
                table: "Transfers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Locations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Disposals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Custodions",
                newName: "Custodians");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Valuations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Transfers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Locations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Disposals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Valuations",
                table: "Valuations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disposals",
                table: "Disposals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
