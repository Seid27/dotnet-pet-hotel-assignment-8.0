using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class RestartPetHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    emailAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<int>(type: "integer", nullable: false),
                    chekedInAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    petOwnerId = table.Column<int>(type: "integer", nullable: false),
                    breed = table.Column<int>(type: "integer", nullable: false),
                    PetOwnersid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pet_PetOwners_PetOwnersid",
                        column: x => x.PetOwnersid,
                        principalTable: "PetOwners",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetOwnersid",
                table: "Pet",
                column: "PetOwnersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "PetOwners");
        }
    }
}
