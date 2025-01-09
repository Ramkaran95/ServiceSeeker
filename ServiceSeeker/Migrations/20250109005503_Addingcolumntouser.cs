using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceSeeker.Migrations
{
    /// <inheritdoc />
    public partial class Addingcolumntouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_UserName",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_UserName",
                table: "Users",
                columns: new[] { "Email", "UserName" },
                unique: true);
        }
    }
}
