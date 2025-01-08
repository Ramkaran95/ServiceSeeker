using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceSeeker.Migrations
{
    /// <inheritdoc />
    public partial class ProviderTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfEx = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LanguageSpoke = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SocialLink1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SocialLink2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TimeOfService = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaServe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    Skill1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Skill2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Skill3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceName1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServicePrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceImage1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceName2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServicePrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceImage2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceName3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServicePrice3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceImage3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PinCode = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Email",
                table: "Providers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_UserName",
                table: "Providers",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
