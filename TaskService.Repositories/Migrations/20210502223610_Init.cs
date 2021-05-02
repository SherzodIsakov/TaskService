using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextTaskEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskTypeEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTaskEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextTaskEntities_TaskTypeEntity_TaskTypeEntityId",
                        column: x => x.TaskTypeEntityId,
                        principalTable: "TaskTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FindEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FindValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextTaskEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindEntity_TextTaskEntities_TextTaskEntityId",
                        column: x => x.TextTaskEntityId,
                        principalTable: "TextTaskEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FindEntity_TextTaskEntityId",
                table: "FindEntity",
                column: "TextTaskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypeEntity_Name_Scope",
                table: "TaskTypeEntity",
                columns: new[] { "Name", "Scope" });

            migrationBuilder.CreateIndex(
                name: "IX_TextTaskEntities_TaskTypeEntityId",
                table: "TextTaskEntities",
                column: "TaskTypeEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FindEntity");

            migrationBuilder.DropTable(
                name: "TextTaskEntities");

            migrationBuilder.DropTable(
                name: "TaskTypeEntity");
        }
    }
}
