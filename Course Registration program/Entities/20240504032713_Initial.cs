using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Course_Registration_program.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    courseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    courseNumber = table.Column<int>(type: "integer", nullable: false),
                    courseName = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.courseID);
                });

            migrationBuilder.CreateTable(
                name: "instructor",
                columns: table => new
                {
                    instructorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lName = table.Column<string>(type: "text", nullable: false),
                    fName = table.Column<string>(type: "text", nullable: false),
                    emailID = table.Column<string>(type: "text", nullable: false),
                    courseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructor", x => x.instructorID);
                    table.ForeignKey(
                        name: "FK_instructor_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    studentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lName = table.Column<string>(type: "text", nullable: false),
                    fName = table.Column<string>(type: "text", nullable: false),
                    emailID = table.Column<string>(type: "text", nullable: false),
                    phoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    courseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_student_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_instructor_courseID",
                table: "instructor",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_student_courseID",
                table: "student",
                column: "courseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instructor");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
