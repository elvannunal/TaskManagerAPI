using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_TeamLeadId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_AssigneeId1",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Teams_TeamId",
                table: "UserTasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "UserTasks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "UserTasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "AssigneeId1",
                table: "UserTasks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "UserTasks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "TeamLeadId",
                table: "Teams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_TeamLeadId",
                table: "Teams",
                column: "TeamLeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_AssigneeId1",
                table: "UserTasks",
                column: "AssigneeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Teams_TeamId",
                table: "UserTasks",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_TeamLeadId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_AssigneeId1",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Teams_TeamId",
                table: "UserTasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "UserTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "UserTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssigneeId1",
                table: "UserTasks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "UserTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamLeadId",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_TeamLeadId",
                table: "Teams",
                column: "TeamLeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_AssigneeId1",
                table: "UserTasks",
                column: "AssigneeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Teams_TeamId",
                table: "UserTasks",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
