using Microsoft.EntityFrameworkCore.Migrations;

namespace DTC_CRUD_MVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryType = table.Column<string>(nullable: true),
                    SalaryNominal = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "Karyawans",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    gender = table.Column<bool>(nullable: false),
                    salaryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karyawans", x => x.id);
                    table.ForeignKey(
                        name: "FK_Karyawans_Salaries_salaryid",
                        column: x => x.salaryid,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    late = table.Column<float>(nullable: false),
                    idperson = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lates", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lates_Karyawans_idperson",
                        column: x => x.idperson,
                        principalTable: "Karyawans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karyawans_salaryid",
                table: "Karyawans",
                column: "salaryid");

            migrationBuilder.CreateIndex(
                name: "IX_Lates_idperson",
                table: "Lates",
                column: "idperson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lates");

            migrationBuilder.DropTable(
                name: "Karyawans");

            migrationBuilder.DropTable(
                name: "Salaries");
        }
    }
}
