using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace olsoftware.Migrations
{
    public partial class OlSoftwareDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idcard = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    phone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idcard);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iduser = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    dinit = table.Column<DateTime>(nullable: false),
                    dend = table.Column<DateTime>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    Nhours = table.Column<int>(nullable: false),
                    lenguage = table.Column<string>(nullable: true),
                    level = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Clientes_iduser",
                        column: x => x.iduser,
                        principalTable: "Clientes",
                        principalColumn: "idcard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_iduser",
                table: "Proyectos",
                column: "iduser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
