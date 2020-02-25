﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Multitenant.Dal;

namespace Multitenant.Migrations.MasterDb
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20200225100814_AuthOptions")]
    partial class AuthOptions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Multitenant.Multitenancy.AuthenticationSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ValidAudience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidIssuer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ValidateAudience")
                        .HasColumnType("bit");

                    b.Property<bool>("ValidateIssuer")
                        .HasColumnType("bit");

                    b.Property<bool>("ValidateLifetime")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationSettings");
                });

            modelBuilder.Entity("Multitenant.Multitenancy.FeatureFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeatureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("FeatureFlags");
                });

            modelBuilder.Entity("Multitenant.Multitenancy.ServiceMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Implementation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("ServiceMappings");
                });

            modelBuilder.Entity("Multitenant.Multitenancy.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthenticationSettingsId")
                        .HasColumnType("int");

                    b.Property<string>("ConnectionString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthenticationSettingsId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Multitenant.Multitenancy.FeatureFlag", b =>
                {
                    b.HasOne("Multitenant.Multitenancy.Tenant", "Tenant")
                        .WithMany("EnabledFeatureFlags")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Multitenant.Multitenancy.ServiceMapping", b =>
                {
                    b.HasOne("Multitenant.Multitenancy.Tenant", "Tenant")
                        .WithMany("TenantSpecificServices")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Multitenant.Multitenancy.Tenant", b =>
                {
                    b.HasOne("Multitenant.Multitenancy.AuthenticationSettings", "AuthenticationSettings")
                        .WithMany()
                        .HasForeignKey("AuthenticationSettingsId");
                });
#pragma warning restore 612, 618
        }
    }
}
