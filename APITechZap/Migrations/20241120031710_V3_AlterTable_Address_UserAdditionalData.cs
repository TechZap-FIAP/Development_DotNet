using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V3_AlterTable_Address_UserAdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DT_FINISHED_AT",
                table: "T_TZ_USER_ADDITIONAL_DATA",
                newName: "DT_DELETED_AT");

            migrationBuilder.RenameColumn(
                name: "DT_FINISHED_AT",
                table: "T_TZ_ADDRESS",
                newName: "DT_DELETED_AT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DT_DELETED_AT",
                table: "T_TZ_USER_ADDITIONAL_DATA",
                newName: "DT_FINISHED_AT");

            migrationBuilder.RenameColumn(
                name: "DT_DELETED_AT",
                table: "T_TZ_ADDRESS",
                newName: "DT_FINISHED_AT");
        }
    }
}
