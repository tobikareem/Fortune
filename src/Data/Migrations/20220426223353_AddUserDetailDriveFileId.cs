using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddUserDetailDriveFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "fort",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "DriveFileId",
                schema: "fort",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriveFileId",
                schema: "fort",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "fort",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
