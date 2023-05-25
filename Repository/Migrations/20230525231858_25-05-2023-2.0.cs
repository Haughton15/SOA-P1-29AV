using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _2505202320 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Empleado",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas",
                column: "Id_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Empleados_Id_Empleado",
                table: "Personas",
                column: "Id_Empleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Empleados_Id_Empleado",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id_Empleado",
                table: "Personas");
        }
    }
}
