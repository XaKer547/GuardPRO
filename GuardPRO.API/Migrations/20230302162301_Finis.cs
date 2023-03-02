using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardPRO.API.Migrations
{
    /// <inheritdoc />
    public partial class Finis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "Invites");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Invites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonDeny",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Invites",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Invites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Invites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Otdels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patromic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    OtdelId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applicants_Otdels_OtdelId",
                        column: x => x.OtdelId,
                        principalTable: "Otdels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invites_ApplicantId",
                table: "Invites",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_GroupId",
                table: "Invites",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_DepartmentId",
                table: "Applicants",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_OtdelId",
                table: "Applicants",
                column: "OtdelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Applicants_ApplicantId",
                table: "Invites",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Groups_GroupId",
                table: "Invites",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Applicants_ApplicantId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Groups_GroupId",
                table: "Invites");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Otdels");

            migrationBuilder.DropIndex(
                name: "IX_Invites_ApplicantId",
                table: "Invites");

            migrationBuilder.DropIndex(
                name: "IX_Invites_GroupId",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Invites");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Invites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReasonDeny",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Invites",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "Invites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
