using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDashboard.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payroll" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "FirstName", "LastName", "Email", "DateOfBrith", "Gender", "DepartmentId", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "John", "Hastings", "david@pragimtech.com", new DateTime(1980, 10, 5).ToUniversalTime(), 0, 1, "images/john.png" },
                    { 2, "Sam", "Galloway", "sam@pragimtech.com", new DateTime(1981, 12, 22).ToUniversalTime(), 0, 2, "images/sam.jpg" },
                    { 3, "Mary", "Smith", "mary@pragimtech.com", new DateTime(1979, 11, 11).ToUniversalTime(), 1, 1, "images/mary.png" },
                    { 4, "Sara", "Longway", "sara@pragimtech.com", new DateTime(1982, 9, 23).ToUniversalTime(), 1, 3, "images/sara.png" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValues: new object[] { 1, 2, 3, 4 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
