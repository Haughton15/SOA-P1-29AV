using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _25052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivosEmpleados_Personas_IdEmpleado",
                table: "ActivosEmpleados");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumEmpleado",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumEmpleado = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivosEmpleados_Empleados_IdEmpleado",
                table: "ActivosEmpleados",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivosEmpleados_Empleados_IdEmpleado",
                table: "ActivosEmpleados");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<int>(
                name: "NumEmpleado",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivosEmpleados_Personas_IdEmpleado",
                table: "ActivosEmpleados",
                column: "IdEmpleado",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
