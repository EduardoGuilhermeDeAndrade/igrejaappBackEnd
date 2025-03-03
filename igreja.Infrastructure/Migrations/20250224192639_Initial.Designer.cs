﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using igreja.Infrastructure.Data;

#nullable disable

namespace igreja.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250224192639_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("igreja.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("igreja.Domain.Models.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsibilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibilityId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("igreja.Domain.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("igreja.Domain.Models.IgrejaTenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IgrejaTenants");
                });

            modelBuilder.Entity("igreja.Domain.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IgrejaTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MemberFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("AttachmentId")
                        .IsUnique()
                        .HasFilter("[AttachmentId] IS NOT NULL");

                    b.HasIndex("IgrejaTenantId");

                    b.HasIndex("ResponsibilityId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("igreja.Domain.Models.Responsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("igreja.Domain.Models.Temple", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("IgrejaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IgrejaTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("AttachmentId")
                        .IsUnique()
                        .HasFilter("[AttachmentId] IS NOT NULL");

                    b.HasIndex("IgrejaTenantId");

                    b.ToTable("Temples");
                });

            modelBuilder.Entity("igreja.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IgrejaTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsResponsableMyTask")
                        .HasColumnType("bit");

                    b.Property<int>("NivelAcesso")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId")
                        .IsUnique()
                        .HasFilter("[AttachmentId] IS NOT NULL");

                    b.HasIndex("IgrejaTenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("igreja.Domain.Models.Assignment", b =>
                {
                    b.HasOne("igreja.Domain.Models.Responsibility", "Responsibility")
                        .WithMany("Assignments")
                        .HasForeignKey("ResponsibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsibility");
                });

            modelBuilder.Entity("igreja.Domain.Models.Member", b =>
                {
                    b.HasOne("igreja.Domain.Models.Address", "Address")
                        .WithOne("Member")
                        .HasForeignKey("igreja.Domain.Models.Member", "AddressId");

                    b.HasOne("igreja.Domain.Models.Attachment", "Attachment")
                        .WithOne("Member")
                        .HasForeignKey("igreja.Domain.Models.Member", "AttachmentId");

                    b.HasOne("igreja.Domain.Models.IgrejaTenant", "IgrejaTenant")
                        .WithMany("Members")
                        .HasForeignKey("IgrejaTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("igreja.Domain.Models.Responsibility", "Responsibility")
                        .WithMany("Members")
                        .HasForeignKey("ResponsibilityId");

                    b.Navigation("Address");

                    b.Navigation("Attachment");

                    b.Navigation("IgrejaTenant");

                    b.Navigation("Responsibility");
                });

            modelBuilder.Entity("igreja.Domain.Models.Temple", b =>
                {
                    b.HasOne("igreja.Domain.Models.Address", "Address")
                        .WithOne("Temple")
                        .HasForeignKey("igreja.Domain.Models.Temple", "AddressId");

                    b.HasOne("igreja.Domain.Models.Attachment", "Attachment")
                        .WithOne("Temple")
                        .HasForeignKey("igreja.Domain.Models.Temple", "AttachmentId");

                    b.HasOne("igreja.Domain.Models.IgrejaTenant", "IgrejaTenant")
                        .WithMany("Temples")
                        .HasForeignKey("IgrejaTenantId");

                    b.Navigation("Address");

                    b.Navigation("Attachment");

                    b.Navigation("IgrejaTenant");
                });

            modelBuilder.Entity("igreja.Domain.Models.User", b =>
                {
                    b.HasOne("igreja.Domain.Models.Attachment", "Attachment")
                        .WithOne("User")
                        .HasForeignKey("igreja.Domain.Models.User", "AttachmentId");

                    b.HasOne("igreja.Domain.Models.IgrejaTenant", "IgrejaTenans")
                        .WithMany("Users")
                        .HasForeignKey("IgrejaTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("IgrejaTenans");
                });

            modelBuilder.Entity("igreja.Domain.Models.Address", b =>
                {
                    b.Navigation("Member");

                    b.Navigation("Temple");
                });

            modelBuilder.Entity("igreja.Domain.Models.Attachment", b =>
                {
                    b.Navigation("Member");

                    b.Navigation("Temple");

                    b.Navigation("User");
                });

            modelBuilder.Entity("igreja.Domain.Models.IgrejaTenant", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Temples");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("igreja.Domain.Models.Responsibility", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
