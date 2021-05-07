﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskService.Repositories.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskInterval = table.Column<int>(type: "int", nullable: false),
                    TaskStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastSavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FindEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FindWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindEntities_TaskEntities_TaskEntityId",
                        column: x => x.TaskEntityId,
                        principalTable: "TaskEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FindEntities_TaskEntityId",
                table: "FindEntities",
                column: "TaskEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FindEntities");

            migrationBuilder.DropTable(
                name: "TaskEntities");
        }
    }
}
