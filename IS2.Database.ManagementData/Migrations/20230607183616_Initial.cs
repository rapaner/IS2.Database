using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IS2.Database.ManagementData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: " StageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StageTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpecificationTemplatePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ StageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureAvailabilityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureAvailabilityTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureAvailabilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    DateStartPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinishPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateStartFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateFinishFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureToModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureToModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureAvailabilityTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureToModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcedureTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    DateStartPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinishPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateStartFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateFinishFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationTemplatePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationTemplatePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationTemplatePackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StageTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    DateStartPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinishPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateStartFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateFinishFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    DateStartPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinishPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateStartFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateFinishFact = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ StageTypes_VersionId_DateInsert_IsDeleted",
                table: " StageTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_VersionId_DateInsert_IsDeleted",
                table: "Assignments",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureAvailabilityTypes_VersionId_DateInsert_IsDeleted",
                table: "ProcedureAvailabilityTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_VersionId_DateInsert_IsDeleted",
                table: "Procedures",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureToModules_VersionId_DateInsert_IsDeleted",
                table: "ProcedureToModules",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureTypes_VersionId_DateInsert_IsDeleted",
                table: "ProcedureTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_VersionId_DateInsert_IsDeleted",
                table: "Projects",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_VersionId_DateInsert_IsDeleted",
                table: "Roles",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationTemplatePackages_VersionId_DateInsert_IsDeleted",
                table: "SpecificationTemplatePackages",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Stages_VersionId_DateInsert_IsDeleted",
                table: "Stages",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_VersionId_DateInsert_IsDeleted",
                table: "Tasks",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_VersionId_DateInsert_IsDeleted",
                table: "Users",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " StageTypes");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "ProcedureAvailabilityTypes");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "ProcedureToModules");

            migrationBuilder.DropTable(
                name: "ProcedureTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "SpecificationTemplatePackages");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
