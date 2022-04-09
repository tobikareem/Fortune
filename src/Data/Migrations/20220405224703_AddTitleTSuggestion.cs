using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddTitleTSuggestion : Migration
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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(55)",
                oldUnicode: false,
                oldMaxLength: 55,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "fort",
                table: "Suggestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "fort",
                table: "Suggestions");

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
        }
    }
}
