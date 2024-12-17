using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyExamsBackend.Migrations
{
    /// <inheritdoc />
    public partial class _241612_AddedCertificateModelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Certificates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Certificates",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Certificates");
        }
    }
}
