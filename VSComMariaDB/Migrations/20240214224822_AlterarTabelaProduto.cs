using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSComMariaDB.Migrations
{
    /// <inheritdoc />
    public partial class AlterarTabelaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricacao",
                table: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Produto",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Produto",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Produto");

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Imagem",
                keyValue: null,
                column: "Imagem",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Produto",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricacao",
                table: "Produto",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
