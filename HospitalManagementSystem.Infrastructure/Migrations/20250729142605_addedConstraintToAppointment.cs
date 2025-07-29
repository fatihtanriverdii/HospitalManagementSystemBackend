using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedConstraintToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_Appointment_Date_Range",
                table: "Appointments",
                sql: "\"Date\" >= CURRENT_DATE AND \"Date\" <= (CURRENT_DATE + INTERVAL '1 month')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_Appointment_Date_Range",
                table: "Appointments");
        }
    }
}
