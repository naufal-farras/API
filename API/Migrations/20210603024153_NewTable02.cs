using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewTable02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_RoleId",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_RoleId",
                table: "TB_T_AccountRole");

            migrationBuilder.CreateTable(
                name: "AccountRoleRole",
                columns: table => new
                {
                    AccountRoleid = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoleRole", x => new { x.AccountRoleid, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoleRole_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoleRole_TB_T_AccountRole_AccountRoleid",
                        column: x => x.AccountRoleid,
                        principalTable: "TB_T_AccountRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoleRole_RoleId",
                table: "AccountRoleRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRoleRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_RoleId",
                table: "TB_T_AccountRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_RoleId",
                table: "TB_T_AccountRole",
                column: "RoleId",
                principalTable: "TB_M_Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
