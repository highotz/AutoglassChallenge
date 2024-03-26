using Microsoft.EntityFrameworkCore.Migrations;



namespace AutoglassChallenge.Infra.Data.Migrations
{
#nullable disable
    public partial class M202403261020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturingDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierCode = table.Column<string>(type: "int"),
                    SupplierDescription = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200),
                    SupplierCNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14)
                }, constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
