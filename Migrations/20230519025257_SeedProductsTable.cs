using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proyecto_Inventario.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sucursal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto_sucursal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "producto",
                        column: x => x.id_producto,
                        principalTable: "producto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sucursal",
                        column: x => x.id_sucursal,
                        principalTable: "sucursal",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "codigo",
                table: "producto",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "producto",
                table: "producto_sucursal",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "sucursal",
                table: "producto_sucursal",
                column: "id_sucursal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto_sucursal");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "sucursal");
        }
    }
}
