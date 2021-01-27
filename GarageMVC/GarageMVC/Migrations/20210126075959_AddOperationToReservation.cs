using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class AddOperationToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Voiture_Carburant",
                table: "Vehicules");

            migrationBuilder.RenameColumn(
                name: "TypeReservation",
                table: "Reservations",
                newName: "Operation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operation",
                table: "Reservations",
                newName: "TypeReservation");

            migrationBuilder.AddColumn<int>(
                name: "Voiture_Carburant",
                table: "Vehicules",
                type: "int",
                nullable: true);
        }
    }
}
