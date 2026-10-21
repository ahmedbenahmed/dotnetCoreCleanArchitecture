using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cleanArch.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class seedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", null, "SuperAdmin", "SUPERADMIN" },
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf7", null, "Admin", "ADMIN" },
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf8", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf9", 0, "92398016-cdf9-4173-8902-2007e77cf92b", "superadmin@example.com", false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAECU5+JN+JYTG9wIBd60aypxMotHrylK3Ud79rKtsj2BeZNCv0bBUDg2ciqO1dLuRkw==", null, false, "b859076c-2f69-42cd-b806-d9da56afc040", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf9" },
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf7", "02174cf0–9412–4cfe-afbf-59f706d72cf9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf7", "02174cf0–9412–4cfe-afbf-59f706d72cf9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf9");
        }
    }
}
