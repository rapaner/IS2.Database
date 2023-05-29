using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IS2.Database.ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionFormalizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionFormalizationId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionFormalizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionLinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId2 = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId3 = table.Column<Guid>(type: "uuid", nullable: true),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionLinkTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionLinkTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLinkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalNumber = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ActionStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionFormalizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionStatusId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptElementClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptElementClassId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptElementClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptElementGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptElementGroupId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptElementGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptElementId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ConceptElementClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptElementGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    IsAutoRange = table.Column<bool>(type: "boolean", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionFormalizations_VersionId_DateInsert_IsDeleted",
                table: "ActionFormalizations",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLinks_VersionId_DateInsert_IsDeleted",
                table: "ActionLinks",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLinkTypes_VersionId_DateInsert_IsDeleted",
                table: "ActionLinkTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_VersionId_DateInsert_IsDeleted",
                table: "Actions",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionStatuses_VersionId_DateInsert_IsDeleted",
                table: "ActionStatuses",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_VersionId_DateInsert_IsDeleted",
                table: "ActionTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptElementClasses_VersionId_DateInsert_IsDeleted",
                table: "ConceptElementClasses",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptElementGroups_VersionId_DateInsert_IsDeleted",
                table: "ConceptElementGroups",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptElements_VersionId_DateInsert_IsDeleted",
                table: "ConceptElements",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_VersionId_DateInsert_IsDeleted",
                table: "Models",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelStatuses_VersionId_DateInsert_IsDeleted",
                table: "ModelStatuses",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelTypes_VersionId_DateInsert_IsDeleted",
                table: "ModelTypes",
                columns: new[] { "VersionId", "DateInsert", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionFormalizations");

            migrationBuilder.DropTable(
                name: "ActionLinks");

            migrationBuilder.DropTable(
                name: "ActionLinkTypes");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "ActionStatuses");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "ConceptElementClasses");

            migrationBuilder.DropTable(
                name: "ConceptElementGroups");

            migrationBuilder.DropTable(
                name: "ConceptElements");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelStatuses");

            migrationBuilder.DropTable(
                name: "ModelTypes");
        }
    }
}
