using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejournal.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarkId);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    StudyYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyYears", x => x.StudyYearId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculums",
                columns: table => new
                {
                    CurriculumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.CurriculumId);
                    table.ForeignKey(
                        name: "FK_Curriculums_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculums_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.StudentGroupId);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMembers",
                columns: table => new
                {
                    DepartmentMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMembers", x => x.DepartmentMemberId);
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_Users_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumParts",
                columns: table => new
                {
                    CurriculumPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CurriculumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumParts", x => x.CurriculumPartId);
                    table.ForeignKey(
                        name: "FK_CurriculumParts_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    HomeWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorks", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK_HomeWorks_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "StudentGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeWorks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "StudentGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroupMembers",
                columns: table => new
                {
                    StudentGroupMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroupMembers", x => x.StudentGroupMemberId);
                    table.ForeignKey(
                        name: "FK_StudentGroupMembers_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "StudentGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroupMembers_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumPartSubjects",
                columns: table => new
                {
                    CurriculumPartSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    CurriculumPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumPartSubjects", x => x.CurriculumPartSubjectId);
                    table.ForeignKey(
                        name: "FK_CurriculumPartSubjects_CurriculumParts_CurriculumPartId",
                        column: x => x.CurriculumPartId,
                        principalTable: "CurriculumParts",
                        principalColumn: "CurriculumPartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumPartSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDays",
                columns: table => new
                {
                    Day = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleDayId = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDays", x => new { x.ScheduleId, x.Day })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ScheduleDays_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaitingLogs",
                columns: table => new
                {
                    RaitingLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaitingLogs", x => x.RaitingLogId);
                    table.ForeignKey(
                        name: "FK_RaitingLogs_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "DepartmentMemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaitingLogs_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "MarkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaitingLogs_StudentGroupMembers_StudentGroupMemberId",
                        column: x => x.StudentGroupMemberId,
                        principalTable: "StudentGroupMembers",
                        principalColumn: "StudentGroupMemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaitingLogs_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSubjects",
                columns: table => new
                {
                    ScheduleSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleDayScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleDayDay = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSubjects", x => x.ScheduleSubjectId);
                    table.ForeignKey(
                        name: "FK_ScheduleSubjects_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "DepartmentMemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleSubjects_ScheduleDays_ScheduleDayScheduleId_ScheduleDayDay",
                        columns: x => new { x.ScheduleDayScheduleId, x.ScheduleDayDay },
                        principalTable: "ScheduleDays",
                        principalColumns: new[] { "ScheduleId", "Day" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumParts_CurriculumId",
                table: "CurriculumParts",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumParts_CurriculumPartId",
                table: "CurriculumParts",
                column: "CurriculumPartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumParts_PartId",
                table: "CurriculumParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumPartSubjects_CurriculumPartId",
                table: "CurriculumPartSubjects",
                column: "CurriculumPartId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumPartSubjects_CurriculumPartSubjectId",
                table: "CurriculumPartSubjects",
                column: "CurriculumPartSubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumPartSubjects_SubjectId",
                table: "CurriculumPartSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_CourseId",
                table: "Curriculums",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_CurriculumId",
                table: "Curriculums",
                column: "CurriculumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_SpecializationId",
                table: "Curriculums",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_DepartmentId",
                table: "DepartmentMembers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_DepartmentMemberId",
                table: "DepartmentMembers",
                column: "DepartmentMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_ProfessorId",
                table: "DepartmentMembers",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId",
                table: "Departments",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_HomeWorkId",
                table: "HomeWorks",
                column: "HomeWorkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_StudentGroupId",
                table: "HomeWorks",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_SubjectId",
                table: "HomeWorks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_MarkId",
                table: "Marks",
                column: "MarkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartId",
                table: "Parts",
                column: "PartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaitingLogs_DepartmentMemberId",
                table: "RaitingLogs",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RaitingLogs_MarkId",
                table: "RaitingLogs",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_RaitingLogs_RaitingLogId",
                table: "RaitingLogs",
                column: "RaitingLogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaitingLogs_StudentGroupMemberId",
                table: "RaitingLogs",
                column: "StudentGroupMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RaitingLogs_SubjectId",
                table: "RaitingLogs",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDays_ScheduleDayId",
                table: "ScheduleDays",
                column: "ScheduleDayId",
                unique: true,
                filter: "[ScheduleDayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PartId",
                table: "Schedules",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleId",
                table: "Schedules",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StudentGroupId",
                table: "Schedules",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubjects_DepartmentMemberId",
                table: "ScheduleSubjects",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubjects_ScheduleDayScheduleId_ScheduleDayDay",
                table: "ScheduleSubjects",
                columns: new[] { "ScheduleDayScheduleId", "ScheduleDayDay" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubjects_ScheduleSubjectId",
                table: "ScheduleSubjects",
                column: "ScheduleSubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSubjects_SubjectId",
                table: "ScheduleSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecializationId",
                table: "Specializations",
                column: "SpecializationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupMembers_StudentGroupId",
                table: "StudentGroupMembers",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupMembers_StudentGroupMemberId",
                table: "StudentGroupMembers",
                column: "StudentGroupMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupMembers_StudentId",
                table: "StudentGroupMembers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_SpecializationId",
                table: "StudentGroups",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_StudentGroupId",
                table: "StudentGroups",
                column: "StudentGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyYears_StudyYearId",
                table: "StudyYears",
                column: "StudyYearId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentId",
                table: "Subjects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectId",
                table: "Subjects",
                column: "SubjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumPartSubjects");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "RaitingLogs");

            migrationBuilder.DropTable(
                name: "ScheduleSubjects");

            migrationBuilder.DropTable(
                name: "StudyYears");

            migrationBuilder.DropTable(
                name: "CurriculumParts");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "StudentGroupMembers");

            migrationBuilder.DropTable(
                name: "DepartmentMembers");

            migrationBuilder.DropTable(
                name: "ScheduleDays");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Curriculums");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
