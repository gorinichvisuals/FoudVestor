using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoudVestor.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialFVPlatformCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    countrycode = table.Column<string>(name: "country_code", type: "nvarchar(12)", maxLength: 12, nullable: false),
                    threeletterisocode = table.Column<string>(name: "three_letter_iso_code", type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformSupports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    lastlogintime = table.Column<DateTime>(name: "last_login_time", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    role = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformSupports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(name: "country_id", type: "int", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    foundationdate = table.Column<string>(name: "foundation_date", type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Companies_Categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_country_id",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryToCategories",
                columns: table => new
                {
                    countryid = table.Column<int>(name: "country_id", type: "int", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryToCategories", x => new { x.countryid, x.categoryid });
                    table.ForeignKey(
                        name: "FK_CountryToCategories_Categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryToCategories_Countries_country_id",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(name: "country_id", type: "int", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    istrusted = table.Column<bool>(name: "is_trusted", type: "bit", nullable: false),
                    role = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    balance = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    lastlogintime = table.Column<DateTime>(name: "last_login_time", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Investors_Countries_country_id",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(name: "country_id", type: "int", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "int", nullable: true),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    istrusted = table.Column<bool>(name: "is_trusted", type: "bit", nullable: false),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "bit", nullable: false),
                    role = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    lastlogintime = table.Column<DateTime>(name: "last_login_time", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Founders_Companies_company_id",
                        column: x => x.companyid,
                        principalTable: "Companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Founders_Countries_country_id",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    isverified = table.Column<bool>(name: "is_verified", type: "bit", nullable: false),
                    necessaryfunds = table.Column<decimal>(name: "necessary_funds", type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectvideopresentationurl = table.Column<string>(name: "project_video_presentation_url", type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    foundationdate = table.Column<string>(name: "foundation_date", type: "nvarchar(max)", nullable: true),
                    stage = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_company_id",
                        column: x => x.companyid,
                        principalTable: "Companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InvestorAreas",
                columns: table => new
                {
                    investorid = table.Column<int>(name: "investor_id", type: "int", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorAreas", x => new { x.investorid, x.categoryid });
                    table.ForeignKey(
                        name: "FK_InvestorAreas_Categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestorAreas_Investors_investor_id",
                        column: x => x.investorid,
                        principalTable: "Investors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestorSubscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    investorid = table.Column<int>(name: "investor_id", type: "int", nullable: false),
                    isnotifynewcategory = table.Column<bool>(name: "is_notify_new_category", type: "bit", nullable: false),
                    isnotifynewprojects = table.Column<bool>(name: "is_notify_new_projects", type: "bit", nullable: false),
                    isnotifynewcompanies = table.Column<bool>(name: "is_notify_new_companies", type: "bit", nullable: false),
                    isnotifynewprojectsbycategory = table.Column<bool>(name: "is_notify_new_projects_by_category", type: "bit", nullable: false),
                    isnotifynewprojectsbycountry = table.Column<bool>(name: "is_notify_new_projects_by_country", type: "bit", nullable: false),
                    isnotifynewprojectsbyfounder = table.Column<bool>(name: "is_notify_new_projects_by_founder", type: "bit", nullable: false),
                    isnotifynewprojectsbycompany = table.Column<bool>(name: "is_notify_new_projects_by_company", type: "bit", nullable: false),
                    isnotifynewfounders = table.Column<bool>(name: "is_notify_new_founders", type: "bit", nullable: false),
                    isnotifynewfoundersbycountry = table.Column<bool>(name: "is_notify_new_founders_by_country", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorSubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_InvestorSubscriptions_Investors_investor_id",
                        column: x => x.investorid,
                        principalTable: "Investors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FounderSubscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    founderid = table.Column<int>(name: "founder_id", type: "int", nullable: false),
                    isnotifynewcategory = table.Column<bool>(name: "is_notify_new_category", type: "bit", nullable: false),
                    isnotifynewprojects = table.Column<bool>(name: "is_notify_new_projects", type: "bit", nullable: false),
                    isnotifynewcompanies = table.Column<bool>(name: "is_notify_new_companies", type: "bit", nullable: false),
                    isnotifynewprojectsbycategory = table.Column<bool>(name: "is_notify_new_projects_by_category", type: "bit", nullable: false),
                    isnotifynewprojectsbycountry = table.Column<bool>(name: "is_notify_new_projects_by_country", type: "bit", nullable: false),
                    isnotifynewprojectsbyfounder = table.Column<bool>(name: "is_notify_new_projects_by_founder", type: "bit", nullable: false),
                    isnotifynewprojectsbycompany = table.Column<bool>(name: "is_notify_new_projects_by_company", type: "bit", nullable: false),
                    isnotifynewinvestors = table.Column<bool>(name: "is_notify_new_investors", type: "bit", nullable: false),
                    isnotifynewinvestorsbyinvestmentarea = table.Column<bool>(name: "is_notify_new_investors_by_investment_area", type: "bit", nullable: false),
                    isnotifynewinvestorsbycountry = table.Column<bool>(name: "is_notify_new_investors_by_country", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderSubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_FounderSubscriptions_Founders_founder_id",
                        column: x => x.founderid,
                        principalTable: "Founders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryToProjects",
                columns: table => new
                {
                    countryid = table.Column<int>(name: "country_id", type: "int", nullable: false),
                    projectid = table.Column<int>(name: "project_id", type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryToProjects", x => new { x.countryid, x.projectid });
                    table.ForeignKey(
                        name: "FK_CountryToProjects_Countries_country_id",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryToProjects_Projects_project_id",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPortfolios",
                columns: table => new
                {
                    projectid = table.Column<int>(name: "project_id", type: "int", nullable: false),
                    investorid = table.Column<int>(name: "investor_id", type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isapproved = table.Column<bool>(name: "is_approved", type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPortfolios", x => new { x.investorid, x.projectid });
                    table.ForeignKey(
                        name: "FK_InvestmentPortfolios_Investors_investor_id",
                        column: x => x.investorid,
                        principalTable: "Investors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentPortfolios_Projects_project_id",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFounders",
                columns: table => new
                {
                    projectid = table.Column<int>(name: "project_id", type: "int", nullable: false),
                    founderid = table.Column<int>(name: "founder_id", type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFounders", x => new { x.founderid, x.projectid });
                    table.ForeignKey(
                        name: "FK_ProjectFounders_Founders_founder_id",
                        column: x => x.founderid,
                        principalTable: "Founders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFounders_Projects_project_id",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_category_id",
                table: "Companies",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_country_id",
                table: "Companies",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_name",
                table: "Companies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryToCategories_category_id",
                table: "CountryToCategories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_CountryToProjects_project_id",
                table: "CountryToProjects",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_company_id",
                table: "Founders",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_country_id",
                table: "Founders",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_email",
                table: "Founders",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Founders_phone",
                table: "Founders",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FounderSubscriptions_founder_id",
                table: "FounderSubscriptions",
                column: "founder_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPortfolios_project_id",
                table: "InvestmentPortfolios",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_InvestorAreas_category_id",
                table: "InvestorAreas",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Investors_country_id",
                table: "Investors",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Investors_email",
                table: "Investors",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investors_phone",
                table: "Investors",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestorSubscriptions_investor_id",
                table: "InvestorSubscriptions",
                column: "investor_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSupports_email",
                table: "PlatformSupports",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSupports_phone",
                table: "PlatformSupports",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFounders_project_id",
                table: "ProjectFounders",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_category_id",
                table: "Projects",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_company_id",
                table: "Projects",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_name",
                table: "Projects",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryToCategories");

            migrationBuilder.DropTable(
                name: "CountryToProjects");

            migrationBuilder.DropTable(
                name: "FounderSubscriptions");

            migrationBuilder.DropTable(
                name: "InvestmentPortfolios");

            migrationBuilder.DropTable(
                name: "InvestorAreas");

            migrationBuilder.DropTable(
                name: "InvestorSubscriptions");

            migrationBuilder.DropTable(
                name: "PlatformSupports");

            migrationBuilder.DropTable(
                name: "ProjectFounders");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropTable(
                name: "Founders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
