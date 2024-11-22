using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V1_CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_TZ_SOLAR_PANEL",
                columns: table => new
                {
                    ID_SOLAR_PANEL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_SIZE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    DS_MATERIAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_PRICE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    DT_CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_SOLAR_PANEL", x => x.ID_SOLAR_PANEL);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_UID_FB = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_SURNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_PASSWORD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_WIND_TURBINE",
                columns: table => new
                {
                    ID_WIND_TURBINE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_SIZE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    DS_MATERIAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_PRICE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    DT_CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_WIND_TURBINE", x => x.ID_WIND_TURBINE);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_SOLAR_PANEL_TYPE",
                columns: table => new
                {
                    ID_SOLAR_PANEL_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_VOLTAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_MODEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_MANUFACTURER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_CELL_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_COST_PER_WATTS = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    DS_PRODUCT_WARRANTY = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_SOLAR_PANEL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_SOLAR_PANEL_TYPE", x => x.ID_SOLAR_PANEL_TYPE);
                    table.ForeignKey(
                        name: "FK_T_TZ_SOLAR_PANEL_TYPE_T_TZ_SOLAR_PANEL_ID_SOLAR_PANEL",
                        column: x => x.ID_SOLAR_PANEL,
                        principalTable: "T_TZ_SOLAR_PANEL",
                        principalColumn: "ID_SOLAR_PANEL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_ADDRESS",
                columns: table => new
                {
                    ID_ADDRESS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_STREET = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DS_COMPLEMENT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_NEIGHBORHOOD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_CITY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_STATE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_ZIPCODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DT_CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_ADDRESS", x => x.ID_ADDRESS);
                    table.ForeignKey(
                        name: "FK_T_TZ_ADDRESS_T_TZ_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "T_TZ_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_USER_ADDITIONAL_DATA",
                columns: table => new
                {
                    ID_USER_ADDITIONAL_DATA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_BIRTH_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DS_CPF = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: true),
                    DS_PHONE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    DT_CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_USER_ADDITIONAL_DATA", x => x.ID_USER_ADDITIONAL_DATA);
                    table.ForeignKey(
                        name: "FK_T_TZ_USER_ADDITIONAL_DATA_T_TZ_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "T_TZ_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_CONTRACTED_PLAN",
                columns: table => new
                {
                    ID_CONTRACTED_PLAN = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtCreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DtUpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DtDeletedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_SOLAR_PANEL = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_WIND_TURBINE = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_CONTRACTED_PLAN", x => x.ID_CONTRACTED_PLAN);
                    table.ForeignKey(
                        name: "FK_T_TZ_CONTRACTED_PLAN_T_TZ_SOLAR_PANEL_ID_SOLAR_PANEL",
                        column: x => x.ID_SOLAR_PANEL,
                        principalTable: "T_TZ_SOLAR_PANEL",
                        principalColumn: "ID_SOLAR_PANEL");
                    table.ForeignKey(
                        name: "FK_T_TZ_CONTRACTED_PLAN_T_TZ_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "T_TZ_USER",
                        principalColumn: "ID_USER");
                    table.ForeignKey(
                        name: "FK_T_TZ_CONTRACTED_PLAN_T_TZ_WIND_TURBINE_ID_WIND_TURBINE",
                        column: x => x.ID_WIND_TURBINE,
                        principalTable: "T_TZ_WIND_TURBINE",
                        principalColumn: "ID_WIND_TURBINE");
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_WIND_TURBINE_TYPE",
                columns: table => new
                {
                    ID_WIND_TURBINE_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_VOLTAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_MODEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_MANUFACTURER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_GENERATOR_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_WARRANTY_YEARS = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_WIND_TURBINE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_WIND_TURBINE_TYPE", x => x.ID_WIND_TURBINE_TYPE);
                    table.ForeignKey(
                        name: "FK_T_TZ_WIND_TURBINE_TYPE_T_TZ_WIND_TURBINE_ID_WIND_TURBINE",
                        column: x => x.ID_WIND_TURBINE,
                        principalTable: "T_TZ_WIND_TURBINE",
                        principalColumn: "ID_WIND_TURBINE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_ADDRESS_ID_USER",
                table: "T_TZ_ADDRESS",
                column: "ID_USER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_SOLAR_PANEL",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_SOLAR_PANEL",
                unique: true,
                filter: "\"ID_SOLAR_PANEL\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_USER",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_CONTRACTED_PLAN_ID_WIND_TURBINE",
                table: "T_TZ_CONTRACTED_PLAN",
                column: "ID_WIND_TURBINE",
                unique: true,
                filter: "\"ID_WIND_TURBINE\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_SOLAR_PANEL_TYPE_ID_SOLAR_PANEL",
                table: "T_TZ_SOLAR_PANEL_TYPE",
                column: "ID_SOLAR_PANEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_USER_ADDITIONAL_DATA_ID_USER",
                table: "T_TZ_USER_ADDITIONAL_DATA",
                column: "ID_USER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_WIND_TURBINE_TYPE_ID_WIND_TURBINE",
                table: "T_TZ_WIND_TURBINE_TYPE",
                column: "ID_WIND_TURBINE",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TZ_ADDRESS");

            migrationBuilder.DropTable(
                name: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropTable(
                name: "T_TZ_SOLAR_PANEL_TYPE");

            migrationBuilder.DropTable(
                name: "T_TZ_USER_ADDITIONAL_DATA");

            migrationBuilder.DropTable(
                name: "T_TZ_WIND_TURBINE_TYPE");

            migrationBuilder.DropTable(
                name: "T_TZ_SOLAR_PANEL");

            migrationBuilder.DropTable(
                name: "T_TZ_USER");

            migrationBuilder.DropTable(
                name: "T_TZ_WIND_TURBINE");
        }
    }
}
