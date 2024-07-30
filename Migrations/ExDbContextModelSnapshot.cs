﻿// <auto-generated />
using Console_core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Console_core.Migrations
{
    [DbContext(typeof(ExDbContext))]
    partial class ExDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Console_core.Models.Models.Person", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("_id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("_firstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("_lastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("_id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Console_core.Models.Models.Todo", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("_id"));

                    b.Property<int>("Assignee_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Done")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("_assignee_id")
                        .HasColumnType("int");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("_done")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("_id");

                    b.HasIndex("Assignee_id");

                    b.HasIndex("_assignee_id");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("Console_core.Models.Models.Todo", b =>
                {
                    b.HasOne("Console_core.Models.Models.Person", "Assignee")
                        .WithMany()
                        .HasForeignKey("Assignee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Console_core.Models.Models.Person", "_assignee")
                        .WithMany()
                        .HasForeignKey("_assignee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("_assignee");
                });
#pragma warning restore 612, 618
        }
    }
}
