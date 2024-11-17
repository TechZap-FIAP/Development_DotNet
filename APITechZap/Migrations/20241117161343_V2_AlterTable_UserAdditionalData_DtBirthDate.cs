using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITechZap.Migrations
{
    /// <inheritdoc />
    public partial class V2_AlterTable_UserAdditionalData_DtBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_BIRTH_DATE",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)");

            migrationBuilder.AlterColumn<string>(
                name: "DS_PHONE",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "DS_CPF",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "NVARCHAR2(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(11)",
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DT_BIRTH_DATE",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "NVARCHAR2(10)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "DS_PHONE",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "NVARCHAR2(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DS_CPF",
                table: "T_TZ_ADDITIONAL_DATA",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(14)",
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}
