using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Sync3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expires",
                table: "AuthToken");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AuthToken");

            migrationBuilder.RenameColumn(
                name: "Attributes",
                table: "AuthToken",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "AuthToken",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AuthToken",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "AuthToken",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "AuthToken");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AuthToken");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "AuthToken");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AuthToken",
                newName: "Attributes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "AuthToken",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AuthToken",
                maxLength: 50,
                nullable: true);
        }
    }
}
