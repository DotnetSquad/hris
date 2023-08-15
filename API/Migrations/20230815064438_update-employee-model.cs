using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class updateemployeemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_jobs_job_guid",
                table: "tb_m_employees");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_profiles_profile_guid",
                table: "tb_m_employees");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_job_guid",
                table: "tb_m_employees");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_profile_guid",
                table: "tb_m_employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "profile_guid",
                table: "tb_m_employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "job_guid",
                table: "tb_m_employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_job_guid",
                table: "tb_m_employees",
                column: "job_guid",
                unique: true,
                filter: "[job_guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_profile_guid",
                table: "tb_m_employees",
                column: "profile_guid",
                unique: true,
                filter: "[profile_guid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_jobs_job_guid",
                table: "tb_m_employees",
                column: "job_guid",
                principalTable: "tb_m_jobs",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_profiles_profile_guid",
                table: "tb_m_employees",
                column: "profile_guid",
                principalTable: "tb_m_profiles",
                principalColumn: "guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_jobs_job_guid",
                table: "tb_m_employees");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_profiles_profile_guid",
                table: "tb_m_employees");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_job_guid",
                table: "tb_m_employees");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_profile_guid",
                table: "tb_m_employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "profile_guid",
                table: "tb_m_employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "job_guid",
                table: "tb_m_employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_job_guid",
                table: "tb_m_employees",
                column: "job_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_profile_guid",
                table: "tb_m_employees",
                column: "profile_guid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_jobs_job_guid",
                table: "tb_m_employees",
                column: "job_guid",
                principalTable: "tb_m_jobs",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_profiles_profile_guid",
                table: "tb_m_employees",
                column: "profile_guid",
                principalTable: "tb_m_profiles",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
