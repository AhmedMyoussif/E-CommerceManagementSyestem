using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceManagementSyestem.Migrations
{
    /// <inheritdoc />
    public partial class alterTableOrderAndCrudOp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Customers");
        }
    }
}
