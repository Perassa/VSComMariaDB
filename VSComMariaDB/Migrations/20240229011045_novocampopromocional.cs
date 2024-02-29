using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSComMariaDB.Migrations
{
    /// <inheritdoc />
    public partial class novocampopromocional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPromocional",
                table: "Produto",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoPromocional",
                table: "Produto");
        }
    }
}
