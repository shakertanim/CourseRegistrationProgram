using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Course_Registration_program.Entities
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_course_courseID",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_courseID",
                table: "student");

            migrationBuilder.DropColumn(
                name: "courseID",
                table: "student");

            migrationBuilder.CreateTable(
                name: "studentCourse",
                columns: table => new
                {
                    assignmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    studentID = table.Column<int>(type: "integer", nullable: false),
                    courseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourse", x => x.assignmentID);
                    table.ForeignKey(
                        name: "FK_studentCourse_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourse_student_studentID",
                        column: x => x.studentID,
                        principalTable: "student",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentCourse_courseID",
                table: "studentCourse",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourse_studentID",
                table: "studentCourse",
                column: "studentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentCourse");

            migrationBuilder.AddColumn<int>(
                name: "courseID",
                table: "student",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_courseID",
                table: "student",
                column: "courseID");

            migrationBuilder.AddForeignKey(
                name: "FK_student_course_courseID",
                table: "student",
                column: "courseID",
                principalTable: "course",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
