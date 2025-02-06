using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AppointmentValue",
                table: "Doctors",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentValue",
                table: "Doctors");
        }
    }
}
