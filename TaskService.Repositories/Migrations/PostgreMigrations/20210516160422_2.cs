using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations.PostgreMigrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskSearchWordsEntity");

            migrationBuilder.AddColumn<string>(
                name: "TaskSearchWords",
                table: "TaskEntity",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskSearchWords",
                table: "TaskEntity");

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
    }
}
