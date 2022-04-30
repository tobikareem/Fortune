using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddUserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Suggestions",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Post",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Comment",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Category",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55);

            migrationBuilder.CreateTable(
                name: "UserDetails",
                schema: "fort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                schema: "fort",
                table: "UserDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails",
                schema: "fort");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Suggestions",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Post",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Comment",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "fort",
                table: "Category",
                type: "varchar(55)",
                unicode: false,
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55,
                oldNullable: true);
        }
    }
}
