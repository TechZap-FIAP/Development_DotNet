using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V2_AlterTables_ContractedPlan_WindTurbine_SolarPanel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_TZ_SOLAR_PANEL_T_TZ_SOLAR_PANEL_TYPE_ID_SOLAR_PANEL_TYPE",
                table: "T_TZ_SOLAR_PANEL");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_SOLAR_PANEL",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_WIND_TURBINE",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.RenameColumn(
                name: "ID_SOLAR_PANEL_TYPE",
                table: "T_TZ_SOLAR_PANEL",
                newName: "SolarPanelTypeIdSolarPanelType");

            migrationBuilder.RenameIndex(
                name: "IX_T_TZ_SOLAR_PANEL_ID_SOLAR_PANEL_TYPE",
                table: "T_TZ_SOLAR_PANEL",
                newName: "IX_T_TZ_SOLAR_PANEL_SolarPanelTypeIdSolarPanelType");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "DtUpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "DtDeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "DtCreatedAt");

            migrationBuilder.AlterColumn<double>(
                name: "DS_SIZE",
                table: "T_TZ_WIND_TURBINE",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<double>(
                name: "DS_PRICE",
                table: "T_TZ_WIND_TURBINE",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<string>(
                name: "DS_MATERIAL",
                table: "T_TZ_WIND_TURBINE",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_SOLAR_PANEL",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_SOLAR_PANEL",
                unique: true,
                filter: "\"ID_SOLAR_PANEL\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_USER",
                unique: true,
                filter: "\"ID_USER\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_WIND_TURBINE",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_WIND_TURBINE",
                unique: true,
                filter: "\"ID_WIND_TURBINE\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_T_TZ_SOLAR_PANEL_T_TZ_SOLAR_PANEL_TYPE_SolarPanelTypeIdSolarPanelType",
                table: "T_TZ_SOLAR_PANEL",
                column: "SolarPanelTypeIdSolarPanelType",
                principalTable: "T_TZ_SOLAR_PANEL_TYPE",
                principalColumn: "ID_SOLAR_PANEL_TYPE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_TZ_SOLAR_PANEL_T_TZ_SOLAR_PANEL_TYPE_SolarPanelTypeIdSolarPanelType",
                table: "T_TZ_SOLAR_PANEL");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_SOLAR_PANEL",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_WIND_TURBINE",
                table: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.RenameColumn(
                name: "SolarPanelTypeIdSolarPanelType",
                table: "T_TZ_SOLAR_PANEL",
                newName: "ID_SOLAR_PANEL_TYPE");

            migrationBuilder.RenameIndex(
                name: "IX_T_TZ_SOLAR_PANEL_SolarPanelTypeIdSolarPanelType",
                table: "T_TZ_SOLAR_PANEL",
                newName: "IX_T_TZ_SOLAR_PANEL_ID_SOLAR_PANEL_TYPE");

            migrationBuilder.RenameColumn(
                name: "DtUpdatedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DtDeletedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DtCreatedAt",
                table: "T_TZ_CONTRACTED_PLAN",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<double>(
                name: "DS_SIZE",
                table: "T_TZ_WIND_TURBINE",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DS_PRICE",
                table: "T_TZ_WIND_TURBINE",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DS_MATERIAL",
                table: "T_TZ_WIND_TURBINE",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_SOLAR_PANEL",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_SOLAR_PANEL");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_WIND_TURBINE",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_WIND_TURBINE");

            migrationBuilder.AddForeignKey(
                name: "FK_T_TZ_SOLAR_PANEL_T_TZ_SOLAR_PANEL_TYPE_ID_SOLAR_PANEL_TYPE",
                table: "T_TZ_SOLAR_PANEL",
                column: "ID_SOLAR_PANEL_TYPE",
                principalTable: "T_TZ_SOLAR_PANEL_TYPE",
                principalColumn: "ID_SOLAR_PANEL_TYPE");
        }
    }
}
