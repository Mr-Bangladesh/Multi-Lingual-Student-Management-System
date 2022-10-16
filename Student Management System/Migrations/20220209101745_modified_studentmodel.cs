using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Management_System.Migrations
{
    public partial class modified_studentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalizedProperty_Students_StudentModelId",
                table: "LocalizedProperty");

            migrationBuilder.DropIndex(
                name: "IX_LocalizedProperty_StudentModelId",
                table: "LocalizedProperty");

            migrationBuilder.DropColumn(
                name: "StudentModelId",
                table: "LocalizedProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentModelId",
                table: "LocalizedProperty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedProperty_StudentModelId",
                table: "LocalizedProperty",
                column: "StudentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizedProperty_Students_StudentModelId",
                table: "LocalizedProperty",
                column: "StudentModelId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
