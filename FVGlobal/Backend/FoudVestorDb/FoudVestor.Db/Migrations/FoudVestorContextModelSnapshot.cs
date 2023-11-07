﻿// <auto-generated />
using System;
using FoudVestor.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoudVestor.Db.Migrations
{
    [DbContext(typeof(FoudVestorContext))]
    partial class FoudVestorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoudVestor.Db.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("FoundationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("foundation_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("country_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("name");

                    b.Property<string>("ThreeLetterISOCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("three_letter_iso_code");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ThreeLetterISOCode")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.CountryToCategory", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.HasKey("CountryId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CountryToCategories");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.CountryToProject", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.HasKey("CountryId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CountryToProjects");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Founder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("address");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsTrusted")
                        .HasColumnType("bit")
                        .HasColumnName("is_trusted");

                    b.Property<DateTime>("LastLoginTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("last_login_time")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Founders");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.FounderSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FounderId")
                        .HasColumnType("int")
                        .HasColumnName("founder_id");

                    b.Property<bool>("IsNotifyNewCategory")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_category");

                    b.Property<bool>("IsNotifyNewCompanies")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_companies");

                    b.Property<bool>("IsNotifyNewInvestors")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_investors");

                    b.Property<bool>("IsNotifyNewInvestorsByCountry")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_investors_by_country");

                    b.Property<bool>("IsNotifyNewInvestorsByInvestmentArea")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_investors_by_investment_area");

                    b.HasKey("Id");

                    b.HasIndex("FounderId")
                        .IsUnique();

                    b.ToTable("FounderSubscriptions");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestmentPortfolio", b =>
                {
                    b.Property<int>("InvestorId")
                        .HasColumnType("int")
                        .HasColumnName("investor_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("currency");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("is_approved");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("InvestorId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("InvestmentPortfolios");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("address");

                    b.Property<decimal?>("Balance")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("balance");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("currency");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsTrusted")
                        .HasColumnType("bit")
                        .HasColumnName("is_trusted");

                    b.Property<DateTime>("LastLoginTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("last_login_time")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Investors");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestorArea", b =>
                {
                    b.Property<int>("InvestorId")
                        .HasColumnType("int")
                        .HasColumnName("investor_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.HasKey("InvestorId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("InvestorAreas");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestorSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvestorId")
                        .HasColumnType("int")
                        .HasColumnName("investor_id");

                    b.Property<bool>("IsNotifyNewCategory")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_category");

                    b.Property<bool>("IsNotifyNewCompanies")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_companies");

                    b.Property<bool>("IsNotifyNewFounders")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_founders");

                    b.Property<bool>("IsNotifyNewFoundersByCoutry")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_founders_by_country");

                    b.Property<bool>("IsNotifyNewProjects")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_projects");

                    b.Property<bool>("IsNotifyNewProjectsByCategory")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_projects_by_category");

                    b.Property<bool>("IsNotifyNewProjectsByCompany")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_projects_by_company");

                    b.Property<bool>("IsNotifyNewProjectsByCoutry")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_projects_by_country");

                    b.Property<bool>("IsNotifyNewProjectsByFounder")
                        .HasColumnType("bit")
                        .HasColumnName("is_notify_new_projects_by_founder");

                    b.HasKey("Id");

                    b.HasIndex("InvestorId")
                        .IsUnique();

                    b.ToTable("InvestorSubscriptions");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.PlatformSupport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("full_name");

                    b.Property<DateTime>("LastLoginTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("last_login_time")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("PlatformSupports");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("currency");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("FoundationDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("foundation_date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("is_verified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("name");

                    b.Property<decimal>("NecessaryFunds")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("necessary_funds");

                    b.Property<string>("ProjectVideoPresentationURL")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnName("project_video_presentation_url");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("stage");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.ProjectToFounder", b =>
                {
                    b.Property<int>("FounderId")
                        .HasColumnType("int")
                        .HasColumnName("founder_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.HasKey("FounderId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectFounders");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Company", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Category", "Category")
                        .WithMany("Companies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Country", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.CountryToCategory", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Category", "Category")
                        .WithMany("CategoryCountries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Country", "Country")
                        .WithMany("CountryAreas")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.CountryToProject", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Country", "Country")
                        .WithMany("CountryProjects")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Project", "Project")
                        .WithMany("ProjectCountries")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Founder", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Company", "Company")
                        .WithMany("Founders")
                        .HasForeignKey("CompanyId");

                    b.HasOne("FoudVestor.Db.Models.Country", "Country")
                        .WithMany("Founders")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.FounderSubscription", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Founder", "Founder")
                        .WithOne("Subscription")
                        .HasForeignKey("FoudVestor.Db.Models.FounderSubscription", "FounderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Founder");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestmentPortfolio", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Investor", "Investor")
                        .WithMany("InvestmentPortfolios")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Project", "Project")
                        .WithMany("InvestmentPortfolios")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Investor", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Country", "Country")
                        .WithMany("Investors")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestorArea", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Category", "Category")
                        .WithMany("AreaInvestors")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Investor", "Investor")
                        .WithMany("InvestorAreas")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.InvestorSubscription", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Investor", "Investor")
                        .WithOne("Subscription")
                        .HasForeignKey("FoudVestor.Db.Models.InvestorSubscription", "InvestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Project", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Category", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.ProjectToFounder", b =>
                {
                    b.HasOne("FoudVestor.Db.Models.Founder", "Founder")
                        .WithMany("FounderProjects")
                        .HasForeignKey("FounderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoudVestor.Db.Models.Project", "Project")
                        .WithMany("ProjectFounders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Founder");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Category", b =>
                {
                    b.Navigation("AreaInvestors");

                    b.Navigation("CategoryCountries");

                    b.Navigation("Companies");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Company", b =>
                {
                    b.Navigation("Founders");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Country", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("CountryAreas");

                    b.Navigation("CountryProjects");

                    b.Navigation("Founders");

                    b.Navigation("Investors");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Founder", b =>
                {
                    b.Navigation("FounderProjects");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Investor", b =>
                {
                    b.Navigation("InvestmentPortfolios");

                    b.Navigation("InvestorAreas");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("FoudVestor.Db.Models.Project", b =>
                {
                    b.Navigation("InvestmentPortfolios");

                    b.Navigation("ProjectCountries");

                    b.Navigation("ProjectFounders");
                });
#pragma warning restore 612, 618
        }
    }
}
