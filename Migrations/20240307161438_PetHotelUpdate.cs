using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class PetHotelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "petCount",
                table: "PetOwners");

            migrationBuilder.AddColumn<int>(
                name: "PetOwnersid",
                table: "Pet",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetOwnersid",
                table: "Pet",
                column: "PetOwnersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetOwners_PetOwnersid",
                table: "Pet",
                column: "PetOwnersid",
                principalTable: "PetOwners",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_PetOwners_PetOwnersid",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_PetOwnersid",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetOwnersid",
                table: "Pet");

            migrationBuilder.AddColumn<int>(
                name: "petCount",
                table: "PetOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
