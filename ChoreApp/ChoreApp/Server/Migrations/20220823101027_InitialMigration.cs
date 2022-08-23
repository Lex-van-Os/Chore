using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoreApp.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Done", "DueDate", "Name" },
                values: new object[] { 1, "Beiden persoonlijk als werk", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mails checken" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Done", "DueDate", "Name" },
                values: new object[] { 2, "Minstens 3 nieuwe features", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programmeerproject afmaken" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Done", "DueDate", "Name" },
                values: new object[] { 3, "Spik en span", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamer opruimen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
