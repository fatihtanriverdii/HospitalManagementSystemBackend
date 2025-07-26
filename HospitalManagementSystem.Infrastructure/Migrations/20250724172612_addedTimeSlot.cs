using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "TimeSlotId",
                table: "Appointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { 1L, new TimeOnly(8, 0, 0) },
                    { 2L, new TimeOnly(8, 30, 0) },
                    { 3L, new TimeOnly(9, 0, 0) },
                    { 4L, new TimeOnly(9, 30, 0) },
                    { 5L, new TimeOnly(10, 0, 0) },
                    { 6L, new TimeOnly(10, 30, 0) },
                    { 7L, new TimeOnly(11, 0, 0) },
                    { 8L, new TimeOnly(11, 30, 0) },
                    { 9L, new TimeOnly(12, 0, 0) },
                    { 10L, new TimeOnly(12, 30, 0) },
                    { 11L, new TimeOnly(13, 0, 0) },
                    { 12L, new TimeOnly(13, 30, 0) },
                    { 13L, new TimeOnly(14, 0, 0) },
                    { 14L, new TimeOnly(14, 30, 0) },
                    { 15L, new TimeOnly(15, 0, 0) },
                    { 16L, new TimeOnly(15, 30, 0) },
                    { 17L, new TimeOnly(16, 0, 0) },
                    { 18L, new TimeOnly(16, 30, 0) },
                    { 19L, new TimeOnly(17, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TimeSlot_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TimeSlot_TimeSlotId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Appointments");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Appointments",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
