using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations.SqlMigrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSearchWordsEntities_TaskEntities_TaskEntityId",
                table: "TaskSearchWordsEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextTaskEntities",
                table: "TextTaskEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSearchWordsEntities",
                table: "TaskSearchWordsEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntities",
                table: "TaskEntities");

            migrationBuilder.RenameTable(
                name: "TextTaskEntities",
                newName: "TextTaskEntity");

            migrationBuilder.RenameTable(
                name: "TaskSearchWordsEntities",
                newName: "TaskSearchWordsEntity");

            migrationBuilder.RenameTable(
                name: "TaskEntities",
                newName: "TaskEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSearchWordsEntities_TaskEntityId",
                table: "TaskSearchWordsEntity",
                newName: "IX_TaskSearchWordsEntity_TaskEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextTaskEntity",
                table: "TextTaskEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSearchWordsEntity",
                table: "TaskSearchWordsEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSearchWordsEntity_TaskEntity_TaskEntityId",
                table: "TaskSearchWordsEntity",
                column: "TaskEntityId",
                principalTable: "TaskEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSearchWordsEntity_TaskEntity_TaskEntityId",
                table: "TaskSearchWordsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextTaskEntity",
                table: "TextTaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSearchWordsEntity",
                table: "TaskSearchWordsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity");

            migrationBuilder.RenameTable(
                name: "TextTaskEntity",
                newName: "TextTaskEntities");

            migrationBuilder.RenameTable(
                name: "TaskSearchWordsEntity",
                newName: "TaskSearchWordsEntities");

            migrationBuilder.RenameTable(
                name: "TaskEntity",
                newName: "TaskEntities");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSearchWordsEntity_TaskEntityId",
                table: "TaskSearchWordsEntities",
                newName: "IX_TaskSearchWordsEntities_TaskEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextTaskEntities",
                table: "TextTaskEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSearchWordsEntities",
                table: "TaskSearchWordsEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntities",
                table: "TaskEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSearchWordsEntities_TaskEntities_TaskEntityId",
                table: "TaskSearchWordsEntities",
                column: "TaskEntityId",
                principalTable: "TaskEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
