using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Goods",
                newName: "Specs");

            migrationBuilder.RenameColumn(
                name: "FullText",
                table: "Goods",
                newName: "Producer");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Specs",
                table: "Goods",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "Goods",
                newName: "FullText");
        }
    }
}
