using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V3_AlterTables_ContractedPlan_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_USER",
                unique: true,
                filter: "\"ID_USER\" IS NOT NULL");
        }
    }
}
