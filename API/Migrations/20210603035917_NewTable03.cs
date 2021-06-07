using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewTable03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Acount_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropTable(
                name: "AccountRoleRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "id",
                table: "TB_T_AccountRole");

            migrationBuilder.RenameColumn(
                name: "AccountNIK",
                table: "TB_T_AccountRole",
                newName: "NIK");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "RegisterVM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                columns: new[] { "NIK", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_RoleId",
                table: "TB_T_AccountRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Acount_NIK",
                table: "TB_T_AccountRole",
                column: "NIK",
                principalTable: "TB_M_Acount",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_RoleId",
                table: "TB_T_AccountRole",
                column: "RoleId",
                principalTable: "TB_M_Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Acount_NIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_RoleId",
                table: "TB_T_AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_RoleId",
                table: "TB_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "RegisterVM");

            migrationBuilder.RenameColumn(
                name: "NIK",
                table: "TB_T_AccountRole",
                newName: "AccountNIK");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Acount_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                principalTable: "TB_M_Acount",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
