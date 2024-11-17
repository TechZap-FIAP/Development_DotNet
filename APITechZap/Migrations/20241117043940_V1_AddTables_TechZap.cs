using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V1_AddTables_TechZap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DS_ZIPCODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_ADDRESS", x => x.ID_ADDRESS);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_SOLAR_PANEL_TYPE",
                columns: table => new
                {
                    ID_SOLAR_PANEL_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_VOLTAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_MODEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_MANUFACTURER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_CELL_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_COST_PER_WATTS = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DS_PRODUCT_WARRANTY = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_SOLAR_PANEL_TYPE", x => x.ID_SOLAR_PANEL_TYPE);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_WIND_TURBINE_TYPE",
                columns: table => new
                {
                    ID_WIND_TURBINE_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_VOLTAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_MODEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_MANUFACTURER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_GENERATOR_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_WARRANTY_YEARS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_WIND_TURBINE_TYPE", x => x.ID_WIND_TURBINE_TYPE);
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_ADDITIONAL_DATA",
                columns: table => new
                {
                    ID_ADDITIONAL_DATA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_BIRTH_DATE = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    DS_CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    DS_PHONE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    ID_ADDRESS = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_ADDITIONAL_DATA", x => x.ID_ADDITIONAL_DATA);
                    table.ForeignKey(
                        name: "FK_T_TZ_ADDITIONAL_DATA_T_TZ_ADDRESS_ID_ADDRESS",
                        column: x => x.ID_ADDRESS,
                        principalTable: "T_TZ_ADDRESS",
                        principalColumn: "ID_ADDRESS");
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_SOLAR_PANEL",
                columns: table => new
                {
                    ID_SOLAR_PANEL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_SIZE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DS_MATERIAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_PRICE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ID_SOLAR_PANEL_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_SOLAR_PANEL", x => x.ID_SOLAR_PANEL);
                    table.ForeignKey(
                        name: "FK_T_TZ_SOLAR_PANEL_T_TZ_SOLAR_PANEL_TYPE_ID_SOLAR_PANEL_TYPE",
                        column: x => x.ID_SOLAR_PANEL_TYPE,
                        principalTable: "T_TZ_SOLAR_PANEL_TYPE",
                        principalColumn: "ID_SOLAR_PANEL_TYPE");
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_WIND_TURBINE",
                columns: table => new
                {
                    ID_WIND_TURBINE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_SIZE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DS_MATERIAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_PRICE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ID_WIND_TURBINE_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_WIND_TURBINE", x => x.ID_WIND_TURBINE);
                    table.ForeignKey(
                        name: "FK_T_TZ_WIND_TURBINE_T_TZ_WIND_TURBINE_TYPE_ID_WIND_TURBINE_TYPE",
                        column: x => x.ID_WIND_TURBINE_TYPE,
                        principalTable: "T_TZ_WIND_TURBINE_TYPE",
                        principalColumn: "ID_WIND_TURBINE_TYPE");
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
                    DT_DELETED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_USER_ADDITIONAL_DATA = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TZ_USER", x => x.ID_USER);
                    table.ForeignKey(
                        name: "FK_T_TZ_USER_T_TZ_ADDITIONAL_DATA_ID_USER_ADDITIONAL_DATA",
                        column: x => x.ID_USER_ADDITIONAL_DATA,
                        principalTable: "T_TZ_ADDITIONAL_DATA",
                        principalColumn: "ID_ADDITIONAL_DATA");
                });

            migrationBuilder.CreateTable(
                name: "T_TZ_CONTRACTED_PLAN",
                columns: table => new
                {
                    ID_CONTRACTED_PLAN = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_ADDITIONAL_DATA_ID_ADDRESS",
                table: "T_TZ_ADDITIONAL_DATA",
                column: "ID_ADDRESS");

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

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_SOLAR_PANEL_ID_SOLAR_PANEL_TYPE",
                table: "T_TZ_SOLAR_PANEL",
                column: "ID_SOLAR_PANEL_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_USER_ID_USER_ADDITIONAL_DATA",
                table: "T_TZ_USER",
                column: "ID_USER_ADDITIONAL_DATA");

            migrationBuilder.CreateIndex(
                name: "IX_T_TZ_WIND_TURBINE_ID_WIND_TURBINE_TYPE",
                table: "T_TZ_WIND_TURBINE",
                column: "ID_WIND_TURBINE_TYPE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TZ_CONTRACTED_PLAN");

            migrationBuilder.DropTable(
                name: "T_TZ_SOLAR_PANEL");

            migrationBuilder.DropTable(
                name: "T_TZ_USER");

            migrationBuilder.DropTable(
                name: "T_TZ_WIND_TURBINE");

            migrationBuilder.DropTable(
                name: "T_TZ_SOLAR_PANEL_TYPE");

            migrationBuilder.DropTable(
                name: "T_TZ_ADDITIONAL_DATA");

            migrationBuilder.DropTable(
                name: "T_TZ_WIND_TURBINE_TYPE");

            migrationBuilder.DropTable(
                name: "T_TZ_ADDRESS");
        }
    }
}
