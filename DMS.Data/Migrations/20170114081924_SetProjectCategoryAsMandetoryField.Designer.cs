using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DMS.Data;

namespace DMS.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170114081924_SetProjectCategoryAsMandetoryField")]
    partial class SetProjectCategoryAsMandetoryField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMS.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EndDateUtc");

                    b.Property<int>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedDateUtc");

                    b.Property<int>("ProjectCategoryId");

                    b.Property<DateTime>("StartDateUtc");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DMS.Domain.Entities.ProjectCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedDateUtc");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ShortDescription")
                        .IsUnique();

                    b.ToTable("ProjectCategories");
                });

            modelBuilder.Entity("DMS.Domain.Entities.Project", b =>
                {
                    b.HasOne("DMS.Domain.Entities.ProjectCategory", "ProjectCategory")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
