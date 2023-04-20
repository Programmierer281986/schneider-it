﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configuration;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20230420172518_ModelsBasicStructure1")]
    partial class ModelsBasicStructure1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("IDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("ROLES");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Can do anything",
                            Identifier = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Can give roles up to Moderator",
                            Identifier = "Moderator"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Can create and edit pages",
                            Identifier = "Creator"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Can translate pages in his languages",
                            Identifier = "Translator"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Can request changes with comments",
                            Identifier = "Commentator"
                        });
                });

            modelBuilder.Entity("Model.Entities.Authentication.RoleClaim", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USER_HAS_ROLES_JT");
                });

            modelBuilder.Entity("Model.Entities.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("REGISTERED_AT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Model.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("longblob")
                        .HasColumnName("DATA");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.ToTable("IMAGES");
                });

            modelBuilder.Entity("Model.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("IMAGE_ID");

                    b.Property<int?>("ParentNodeId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_NODE_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ParentNodeId");

                    b.ToTable("NODES_BT");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Model.Entities.UserEditsNode", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("NodeId")
                        .HasColumnType("int")
                        .HasColumnName("NODE_ID");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("EDITED_AT");

                    b.Property<string>("EditType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("EDIT_TYPE");

                    b.HasKey("UserId", "NodeId", "EditedAt");

                    b.HasIndex("NodeId");

                    b.ToTable("USER_EDITS_NODES");
                });

            modelBuilder.Entity("Model.Entities.CategoryNode", b =>
                {
                    b.HasBaseType("Model.Entities.Node");

                    b.Property<string>("Content")
                        .HasColumnType("longtext")
                        .HasColumnName("CONTENT");

                    b.ToTable("CATEGORY_NODES");
                });

            modelBuilder.Entity("Model.Entities.ContentNode", b =>
                {
                    b.HasBaseType("Model.Entities.Node");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CONTENT");

                    b.ToTable("CONTENT_NODES");
                });

            modelBuilder.Entity("Model.Entities.Authentication.RoleClaim", b =>
                {
                    b.HasOne("Model.Entities.Authentication.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Authentication.User", "User")
                        .WithMany("RoleClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.Node", b =>
                {
                    b.HasOne("Model.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Node", "ParentNode")
                        .WithMany("ChildNodes")
                        .HasForeignKey("ParentNodeId");

                    b.Navigation("Image");

                    b.Navigation("ParentNode");
                });

            modelBuilder.Entity("Model.Entities.UserEditsNode", b =>
                {
                    b.HasOne("Model.Entities.Node", "Node")
                        .WithMany("Edits")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Authentication.User", "User")
                        .WithMany("EditedNodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.CategoryNode", b =>
                {
                    b.HasOne("Model.Entities.Node", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.CategoryNode", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.ContentNode", b =>
                {
                    b.HasOne("Model.Entities.Node", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.ContentNode", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Authentication.Role", b =>
                {
                    b.Navigation("RoleClaims");
                });

            modelBuilder.Entity("Model.Entities.Authentication.User", b =>
                {
                    b.Navigation("EditedNodes");

                    b.Navigation("RoleClaims");
                });

            modelBuilder.Entity("Model.Entities.Node", b =>
                {
                    b.Navigation("ChildNodes");

                    b.Navigation("Edits");
                });
#pragma warning restore 612, 618
        }
    }
}