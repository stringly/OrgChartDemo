﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrgChartDemo.Models;

namespace OrgChartDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190327223433_ParentComponentId")]
    partial class ParentComponentId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrgChartDemo.Models.Component", b =>
                {
                    b.Property<int>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym");

                    b.Property<int?>("LineupPosition");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentComponentId");

                    b.HasKey("ComponentId");

                    b.HasIndex("ParentComponentId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DutyStatusId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("IdNumber");

                    b.Property<string>("LDAPName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<int?>("PositionId");

                    b.Property<int?>("RaceMemberRaceId");

                    b.Property<int?>("RankId");

                    b.HasKey("MemberId");

                    b.HasIndex("DutyStatusId");

                    b.HasIndex("GenderId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RaceMemberRaceId");

                    b.HasIndex("RankId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("OrgChartDemo.Models.MemberContactNumber", b =>
                {
                    b.Property<int>("MemberContactNumberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MemberId");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("TypePhoneNumberTypeId");

                    b.HasKey("MemberContactNumberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TypePhoneNumberTypeId");

                    b.ToTable("ContactNumbers");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Callsign");

                    b.Property<bool>("IsManager");

                    b.Property<bool>("IsUnique");

                    b.Property<string>("JobTitle");

                    b.Property<int?>("LineupPosition");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentComponentComponentId");

                    b.HasKey("PositionId");

                    b.HasIndex("ParentComponentComponentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Types.MemberDutyStatus", b =>
                {
                    b.Property<int>("DutyStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("DutyStatusName");

                    b.Property<bool>("HasPolicePower");

                    b.HasKey("DutyStatusId");

                    b.ToTable("DutyStatus");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Types.MemberGender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("GenderFullName");

                    b.HasKey("GenderId");

                    b.ToTable("MemberGender");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Types.MemberRace", b =>
                {
                    b.Property<int>("MemberRaceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("MemberRaceFullName");

                    b.HasKey("MemberRaceId");

                    b.ToTable("MemberRace");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Types.MemberRank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSworn");

                    b.Property<string>("PayGrade");

                    b.Property<string>("RankFullName");

                    b.Property<string>("RankShort");

                    b.HasKey("RankId");

                    b.ToTable("MemberRanks");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Types.PhoneNumberType", b =>
                {
                    b.Property<int>("PhoneNumberTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumberTypeName");

                    b.HasKey("PhoneNumberTypeId");

                    b.ToTable("PhoneNumberTypes");
                });

            modelBuilder.Entity("OrgChartDemo.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MemberId");

                    b.Property<int?>("RoleTypeId");

                    b.HasKey("RoleId");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoleTypeId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OrgChartDemo.Models.UserRoleType", b =>
                {
                    b.Property<int>("RoleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleTypeName");

                    b.HasKey("RoleTypeId");

                    b.ToTable("UserRoleType");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Component", b =>
                {
                    b.HasOne("OrgChartDemo.Models.Component", "ParentComponent")
                        .WithMany("ChildComponents")
                        .HasForeignKey("ParentComponentId");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Member", b =>
                {
                    b.HasOne("OrgChartDemo.Models.Types.MemberDutyStatus", "DutyStatus")
                        .WithMany()
                        .HasForeignKey("DutyStatusId");

                    b.HasOne("OrgChartDemo.Models.Types.MemberGender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("OrgChartDemo.Models.Position", "Position")
                        .WithMany("Members")
                        .HasForeignKey("PositionId");

                    b.HasOne("OrgChartDemo.Models.Types.MemberRace", "Race")
                        .WithMany()
                        .HasForeignKey("RaceMemberRaceId");

                    b.HasOne("OrgChartDemo.Models.Types.MemberRank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId");
                });

            modelBuilder.Entity("OrgChartDemo.Models.MemberContactNumber", b =>
                {
                    b.HasOne("OrgChartDemo.Models.Member", "Member")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("MemberId");

                    b.HasOne("OrgChartDemo.Models.Types.PhoneNumberType", "Type")
                        .WithMany()
                        .HasForeignKey("TypePhoneNumberTypeId");
                });

            modelBuilder.Entity("OrgChartDemo.Models.Position", b =>
                {
                    b.HasOne("OrgChartDemo.Models.Component", "ParentComponent")
                        .WithMany("Positions")
                        .HasForeignKey("ParentComponentComponentId");
                });

            modelBuilder.Entity("OrgChartDemo.Models.UserRole", b =>
                {
                    b.HasOne("OrgChartDemo.Models.Member")
                        .WithMany("CurrentRoles")
                        .HasForeignKey("MemberId");

                    b.HasOne("OrgChartDemo.Models.UserRoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
