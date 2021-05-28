using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateTable_New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Education_TB_M_University_Universityid",
                table: "TB_M_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Educationid",
                table: "TB_T_Profiling");

            migrationBuilder.RenameColumn(
                name: "Education_id",
                table: "TB_T_Profiling",
                newName: "Education_Id");

            migrationBuilder.RenameColumn(
                name: "Educationid",
                table: "TB_T_Profiling",
                newName: "Education_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Profiling_Educationid",
                table: "TB_T_Profiling",
                newName: "IX_TB_T_Profiling_Education_Id1");

            migrationBuilder.RenameColumn(
                name: "universityName",
                table: "TB_M_University",
                newName: "UniversityName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TB_M_University",
                newName: "University_Id");

            migrationBuilder.RenameColumn(
                name: "University_id",
                table: "TB_M_Education",
                newName: "University_Id");

            migrationBuilder.RenameColumn(
                name: "Universityid",
                table: "TB_M_Education",
                newName: "University_Id1");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TB_M_Education",
                newName: "Education_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TB_M_Education_Universityid",
                table: "TB_M_Education",
                newName: "IX_TB_M_Education_University_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Education_TB_M_University_University_Id1",
                table: "TB_M_Education",
                column: "University_Id1",
                principalTable: "TB_M_University",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Education_Id1",
                table: "TB_T_Profiling",
                column: "Education_Id1",
                principalTable: "TB_M_Education",
                principalColumn: "Education_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Education_TB_M_University_University_Id1",
                table: "TB_M_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Education_Id1",
                table: "TB_T_Profiling");

            migrationBuilder.RenameColumn(
                name: "Education_Id",
                table: "TB_T_Profiling",
                newName: "Education_id");

            migrationBuilder.RenameColumn(
                name: "Education_Id1",
                table: "TB_T_Profiling",
                newName: "Educationid");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Profiling_Education_Id1",
                table: "TB_T_Profiling",
                newName: "IX_TB_T_Profiling_Educationid");

            migrationBuilder.RenameColumn(
                name: "UniversityName",
                table: "TB_M_University",
                newName: "universityName");

            migrationBuilder.RenameColumn(
                name: "University_Id",
                table: "TB_M_University",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "University_Id",
                table: "TB_M_Education",
                newName: "University_id");

            migrationBuilder.RenameColumn(
                name: "University_Id1",
                table: "TB_M_Education",
                newName: "Universityid");

            migrationBuilder.RenameColumn(
                name: "Education_Id",
                table: "TB_M_Education",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TB_M_Education_University_Id1",
                table: "TB_M_Education",
                newName: "IX_TB_M_Education_Universityid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Education_TB_M_University_Universityid",
                table: "TB_M_Education",
                column: "Universityid",
                principalTable: "TB_M_University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Educationid",
                table: "TB_T_Profiling",
                column: "Educationid",
                principalTable: "TB_M_Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
