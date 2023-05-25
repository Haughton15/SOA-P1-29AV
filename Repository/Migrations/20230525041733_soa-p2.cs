using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class soap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Areas_IdArea",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdArea",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdArea",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estatus",
                table: "Personas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Personas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivosEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(type: "int", nullable: true),
                    IdActivo = table.Column<int>(type: "int", nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLiberacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivosEmpleados_Activos_IdActivo",
                        column: x => x.IdActivo,
                        principalTable: "Activos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivosEmpleados_Personas_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivosEmpleados_IdActivo",
                table: "ActivosEmpleados",
                column: "IdActivo");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosEmpleados_IdEmpleado",
                table: "ActivosEmpleados",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivosEmpleados");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdArea",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Personas",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdArea",
                table: "Personas",
                column: "IdArea");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Areas_IdArea",
                table: "Personas",
                column: "IdArea",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
