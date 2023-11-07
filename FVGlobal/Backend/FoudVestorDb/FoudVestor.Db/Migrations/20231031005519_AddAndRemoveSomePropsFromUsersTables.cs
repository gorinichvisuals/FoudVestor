using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoudVestor.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddAndRemoveSomePropsFromUsersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_notify_new_projects",
                table: "FounderSubscriptions");

            migrationBuilder.DropColumn(
                name: "is_notify_new_projects_by_category",
                table: "FounderSubscriptions");

            migrationBuilder.DropColumn(
                name: "is_notify_new_projects_by_company",
                table: "FounderSubscriptions");

            migrationBuilder.DropColumn(
                name: "is_notify_new_projects_by_country",
                table: "FounderSubscriptions");

            migrationBuilder.DropColumn(
                name: "is_notify_new_projects_by_founder",
                table: "FounderSubscriptions");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "PlatformSupports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Investors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "PlatformSupports");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Investors");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Founders");

            migrationBuilder.AddColumn<bool>(
                name: "is_notify_new_projects",
                table: "FounderSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_notify_new_projects_by_category",
                table: "FounderSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_notify_new_projects_by_company",
                table: "FounderSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_notify_new_projects_by_country",
                table: "FounderSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_notify_new_projects_by_founder",
                table: "FounderSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
