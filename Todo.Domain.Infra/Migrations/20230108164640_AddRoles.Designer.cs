﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Domain.Infra.Data;

#nullable disable

namespace Todo.Domain.Infra.Migrations
{
    [DbContext(typeof(TodoDataContext))]
    [Migration("20230108164640_AddRoles")]
    partial class AddRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Todo.Domain.Entitys.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Name");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Todo.Domain.Entitys.Todo", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(557))
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("Done")
                        .HasColumnType("BIT")
                        .HasColumnName("Done");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 1, 8, 16, 46, 40, 149, DateTimeKind.Utc).AddTicks(826))
                        .HasColumnName("LastUpdate");

                    b.HasKey("Title", "Email");

                    b.HasIndex("Email");

                    b.ToTable("Todo", (string)null);
                });

            modelBuilder.Entity("Todo.Domain.Entitys.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("PasswordHash");

                    b.HasKey("Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Todo.Domain.Entitys.UserRole", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UserEmail")
                        .HasColumnType("NVARCHAR");

                    b.HasKey("RoleName", "UserEmail");

                    b.HasIndex("UserEmail");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Todo.Domain.Entitys.Todo", b =>
                {
                    b.HasOne("Todo.Domain.Entitys.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Todo.Domain.Entitys.UserRole", b =>
                {
                    b.HasOne("Todo.Domain.Entitys.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Todo.Domain.Entitys.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Todo.Domain.Entitys.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Todo.Domain.Entitys.User", b =>
                {
                    b.Navigation("Todos");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}