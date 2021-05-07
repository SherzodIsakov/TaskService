using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextTaskEntities_TaskTypeEntity_TaskTypeEntityId",
                table: "TextTaskEntities");

            migrationBuilder.DropTable(
                name: "FindEntity");

            migrationBuilder.DropTable(
                name: "TaskTypeEntity");

            migrationBuilder.DropIndex(
                name: "IX_TextTaskEntities_TaskTypeEntityId",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "TaskTypeEntityId",
                table: "TextTaskEntities");

            migrationBuilder.AddColumn<int>(
                name: "FindindWordsCount",
                table: "TextTaskEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "TextTaskEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TextId",
                table: "TextTaskEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FindindWordsCount",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TextTaskEntities");

            migrationBuilder.DropColumn(
                name: "TextId",
                table: "TextTaskEntities");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TextTaskEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TextTaskEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TextTaskEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "TaskTypeEntityId",
                table: "TextTaskEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FindEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FindValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextTaskEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TaskTypeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextTaskEntities_TaskTypeEntityId",
                table: "TextTaskEntities",
                column: "TaskTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FindEntity_TextTaskEntityId",
                table: "FindEntity",
                column: "TextTaskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypeEntity_Name_Scope",
                table: "TaskTypeEntity",
                columns: new[] { "Name", "Scope" });

            migrationBuilder.AddForeignKey(
                name: "FK_TextTaskEntities_TaskTypeEntity_TaskTypeEntityId",
                table: "TextTaskEntities",
                column: "TaskTypeEntityId",
                principalTable: "TaskTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
