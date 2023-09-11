using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xp.Api.Application.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
