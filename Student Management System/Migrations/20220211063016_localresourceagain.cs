using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Management_System.Migrations
{
    public partial class localresourceagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalResourceModel_Languages_LanguageId",
                table: "LocalResourceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalResourceModel",
                table: "LocalResourceModel");

            migrationBuilder.RenameTable(
                name: "LocalResourceModel",
                newName: "LocalResource");

            migrationBuilder.RenameIndex(
                name: "IX_LocalResourceModel_LanguageId",
                table: "LocalResource",
                newName: "IX_LocalResource_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalResource",
                table: "LocalResource",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CurrentDefault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentDefault", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LocalResource_Languages_LanguageId",
                table: "LocalResource",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalResource_Languages_LanguageId",
                table: "LocalResource");

            migrationBuilder.DropTable(
                name: "CurrentDefault");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalResource",
                table: "LocalResource");

            migrationBuilder.RenameTable(
                name: "LocalResource",
                newName: "LocalResourceModel");

            migrationBuilder.RenameIndex(
                name: "IX_LocalResource_LanguageId",
                table: "LocalResourceModel",
                newName: "IX_LocalResourceModel_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalResourceModel",
                table: "LocalResourceModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalResourceModel_Languages_LanguageId",
                table: "LocalResourceModel",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
