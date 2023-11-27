using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PCStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Categoryseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Processor" },
                    { 2, "Graphics card" },
                    { 3, "Motherboard" },
                    { 4, "RAM" },
                    { 5, "Cooling" },
                    { 6, "Memory card" },
                    { 7, "Power supply" },
                    { 8, "Case" },
                    { 9, "Monitor" },
                    { 10, "Mouse" },
                    { 11, "Keyboard" },
                    { 12, "Headphone" },
                    { 13, "Microphone" },
                    { 14, "Laptop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
