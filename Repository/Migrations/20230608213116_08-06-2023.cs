using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _08062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_ActivosEmpleados_IdEmpleado",
                table: "ActivosEmpleados");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas",
                column: "Id_Empleado",
                unique: true,
                filter: "[Id_Empleado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosEmpleados_IdEmpleado",
                table: "ActivosEmpleados",
                column: "IdEmpleado",
                unique: true,
                filter: "[IdEmpleado] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_ActivosEmpleados_IdEmpleado",
                table: "ActivosEmpleados");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Personas");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_Empleado",
                table: "Personas",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosEmpleados_IdEmpleado",
                table: "ActivosEmpleados",
                column: "IdEmpleado");
        }
    }
}
