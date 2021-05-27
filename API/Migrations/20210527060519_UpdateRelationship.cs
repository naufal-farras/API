using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Profiling",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Education_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_T_Profiling_TB_M_Acount_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Acount",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Education",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Universityid = table.Column<int>(type: "int", nullable: true),
                    ProfilingNIK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Education", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_University_Universityid",
                        column: x => x.Universityid,
                        principalTable: "TB_M_University",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_T_Profiling_ProfilingNIK",
                        column: x => x.ProfilingNIK,
                        principalTable: "TB_T_Profiling",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_ProfilingNIK",
                table: "TB_M_Education",
                column: "ProfilingNIK");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_Universityid",
                table: "TB_M_Education",
                column: "Universityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Education");

            migrationBuilder.DropTable(
                name: "TB_M_University");

            migrationBuilder.DropTable(
                name: "TB_T_Profiling");
        }
    }
}
