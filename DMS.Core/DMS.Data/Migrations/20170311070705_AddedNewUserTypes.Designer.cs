using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DMS.Data;

namespace DMS.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170311070705_AddedNewUserTypes")]
    partial class AddedNewUserTypes
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
                        .HasMaxLength(500);

                    b.Property<int>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedDateUtc");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ShortDescription")
                        .IsUnique();

                    b.ToTable("ProjectCategories");
                });

            modelBuilder.Entity("DMS.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedDateUtc");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("DMS.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("DMS.Domain.Entities.User");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("DMS.Domain.Entities.Donee", b =>
                {
                    b.HasBaseType("DMS.Domain.Entities.User");


                    b.ToTable("Donee");

                    b.HasDiscriminator().HasValue("Donee");
                });

            modelBuilder.Entity("DMS.Domain.Entities.Donor", b =>
                {
                    b.HasBaseType("DMS.Domain.Entities.User");


                    b.ToTable("Donor");

                    b.HasDiscriminator().HasValue("Donor");
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
