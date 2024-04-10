using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName", "CategorySize" },
                values: new object[,]
                {
                    { new Guid("4c9a5ea0-4158-41d8-871e-32e473734302"), null, "Personal activities", 1 },
                    { new Guid("4c9a5ea0-4158-41d8-871e-32e4737343ad"), null, "Work activities", 1 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Created", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("4c9a5ea0-4158-41d8-871e-32e473734310"), new Guid("4c9a5ea0-4158-41d8-871e-32e4737343ad"), new DateTime(2024, 3, 26, 8, 28, 37, 805, DateTimeKind.Local).AddTicks(6427), null, 1, "Do the screen 1" },
                    { new Guid("4c9a5ea0-4158-41d8-871e-32e473734311"), new Guid("4c9a5ea0-4158-41d8-871e-32e473734302"), new DateTime(2024, 3, 26, 8, 28, 37, 805, DateTimeKind.Local).AddTicks(6459), null, 0, "Watch Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4c9a5ea0-4158-41d8-871e-32e473734310"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4c9a5ea0-4158-41d8-871e-32e473734311"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4c9a5ea0-4158-41d8-871e-32e473734302"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4c9a5ea0-4158-41d8-871e-32e4737343ad"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
