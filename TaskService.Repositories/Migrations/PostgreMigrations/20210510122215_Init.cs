using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations.PostgreMigrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskInterval = table.Column<int>(type: "integer", nullable: false),
                    TaskStartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskEndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextTaskEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    TextId = table.Column<Guid>(type: "uuid", nullable: false),
                    FindindWordsCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTaskEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSearchWordsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FindWord = table.Column<string>(type: "text", nullable: true),
                    TaskEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSearchWordsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSearchWordsEntity_TaskEntity_TaskEntityId",
                        column: x => x.TaskEntityId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskSearchWordsEntity_TaskEntityId",
                table: "TaskSearchWordsEntity",
                column: "TaskEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskSearchWordsEntity");

            migrationBuilder.DropTable(
                name: "TextTaskEntity");

            migrationBuilder.DropTable(
                name: "TaskEntity");
        }
    }
}
