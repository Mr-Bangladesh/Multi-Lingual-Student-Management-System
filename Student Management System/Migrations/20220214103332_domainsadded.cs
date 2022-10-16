using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Management_System.Migrations
{
    public partial class domainsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalizedProperty_Languages_LanguageIdId",
                table: "LocalizedProperty");

            migrationBuilder.DropTable(
                name: "CourseModelStudentModel");

            migrationBuilder.RenameColumn(
                name: "LanguageIdId",
                table: "LocalizedProperty",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_LocalizedProperty_LanguageIdId",
                table: "LocalizedProperty",
                newName: "IX_LocalizedProperty_LanguageId");

            migrationBuilder.CreateTable(
                name: "CourseDomainStudentDomain",
                columns: table => new
                {
                    EnrolledCoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDomainStudentDomain", x => new { x.EnrolledCoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseDomainStudentDomain_Courses_EnrolledCoursesId",
                        column: x => x.EnrolledCoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDomainStudentDomain_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDomainStudentDomain_StudentsId",
                table: "CourseDomainStudentDomain",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizedProperty_Languages_LanguageId",
                table: "LocalizedProperty",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalizedProperty_Languages_LanguageId",
                table: "LocalizedProperty");

            migrationBuilder.DropTable(
                name: "CourseDomainStudentDomain");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "LocalizedProperty",
                newName: "LanguageIdId");

            migrationBuilder.RenameIndex(
                name: "IX_LocalizedProperty_LanguageId",
                table: "LocalizedProperty",
                newName: "IX_LocalizedProperty_LanguageIdId");

            migrationBuilder.CreateTable(
                name: "CourseModelStudentModel",
                columns: table => new
                {
                    EnrolledCoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModelStudentModel", x => new { x.EnrolledCoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseModelStudentModel_Courses_EnrolledCoursesId",
                        column: x => x.EnrolledCoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModelStudentModel_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModelStudentModel_StudentsId",
                table: "CourseModelStudentModel",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizedProperty_Languages_LanguageIdId",
                table: "LocalizedProperty",
                column: "LanguageIdId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
