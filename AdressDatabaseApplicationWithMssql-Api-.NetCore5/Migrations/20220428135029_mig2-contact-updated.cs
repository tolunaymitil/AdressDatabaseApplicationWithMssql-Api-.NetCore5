using Microsoft.EntityFrameworkCore.Migrations;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Migrations
{
    public partial class mig2contactupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContactIsAcceessable",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ContactValue",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactIsAcceessable",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactValue",
                table: "Contacts");
        }
    }
}
