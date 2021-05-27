using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Education_TB_T_Profiling_ProfilingNIK",
                table: "TB_M_Education");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Education_ProfilingNIK",
                table: "TB_M_Education");

            migrationBuilder.DropColumn(
                name: "ProfilingNIK",
                table: "TB_M_Education");

            migrationBuilder.AddColumn<int>(
                name: "Educationid",
                table: "TB_T_Profiling",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Profiling_Educationid",
                table: "TB_T_Profiling",
                column: "Educationid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Educationid",
                table: "TB_T_Profiling",
                column: "Educationid",
                principalTable: "TB_M_Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Profiling_TB_M_Education_Educationid",
                table: "TB_T_Profiling");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Profiling_Educationid",
                table: "TB_T_Profiling");

            migrationBuilder.DropColumn(
                name: "Educationid",
                table: "TB_T_Profiling");

            migrationBuilder.AddColumn<int>(
                name: "ProfilingNIK",
                table: "TB_M_Education",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_ProfilingNIK",
                table: "TB_M_Education",
                column: "ProfilingNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Education_TB_T_Profiling_ProfilingNIK",
                table: "TB_M_Education",
                column: "ProfilingNIK",
                principalTable: "TB_T_Profiling",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
