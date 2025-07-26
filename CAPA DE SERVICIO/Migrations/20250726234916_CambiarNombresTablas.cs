using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICRUDGABRIEL.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombresTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Entrenadores");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Miembros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrenadores",
                table: "Entrenadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrenadores",
                table: "Entrenadores");

            migrationBuilder.RenameTable(
                name: "Miembros",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "Entrenadores",
                newName: "Trainers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");
        }
    }
}
