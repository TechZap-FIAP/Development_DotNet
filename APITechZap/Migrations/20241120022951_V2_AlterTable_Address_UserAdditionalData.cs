using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V2_AlterTable_Address_UserAdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DT_FINISHED_AT",
                table: "T_TZ_USER_ADDITIONAL_DATA",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_FINISHED_AT",
                table: "T_TZ_ADDRESS",
                type: "TIMESTAMP(7)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT_FINISHED_AT",
                table: "T_TZ_USER_ADDITIONAL_DATA");

            migrationBuilder.DropColumn(
                name: "DT_FINISHED_AT",
                table: "T_TZ_ADDRESS");
        }
    }
}
