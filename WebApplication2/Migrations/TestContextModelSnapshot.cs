
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Context;

#nullable disable

namespace SGME.Migrations
{
    [DbContext(typeof(TestContext))]
    partial class TestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);


            modelBuilder.Entity("SGME.Model.Content", b =>
                {
                    b.Property<int>("ContentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentID"));

                    b.Property<string>("ContentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ContentID");

                    b.HasIndex("PlatformID");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("SGME.Model.ContentUsers", b =>
                {
                    b.Property<int>("ContentUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentUserID"));

                    b.Property<int>("ContentID")
                        .HasColumnType("int");

                    b.Property<string>("InteractionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ViewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewDuration")
                        .HasColumnType("int");

                    b.HasKey("ContentUserID");

                    b.HasIndex("ContentID");

                    b.HasIndex("UserID");

                    b.ToTable("ContentUsers");
                });

            modelBuilder.Entity("SGME.Model.PermissionPerUserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.HasKey("UserTypeID", "PermissionID");

                    b.HasIndex("PermissionID");

                    b.ToTable("PermissionPerUserTypes");
                });

            modelBuilder.Entity("SGME.Model.Permissions", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"));

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("SGME.Model.Platform", b =>
                {
                    b.Property<int>("PlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformID"));

                    b.Property<string>("PlatformDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("SGME.Model.UsageHistory", b =>
                {
                    b.Property<int>("HistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryID"));

                    b.Property<int>("ContentID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ViewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewDuration")
                        .HasColumnType("int");

                    b.HasKey("HistoryID");

                    b.HasIndex("ContentID");

                    b.HasIndex("UserID");

                    b.ToTable("UsageHistory");

            modelBuilder.Entity("SGME.Model.Comments", b =>
                {
                    b.Property<int>("CommentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentsId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("RefferencesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SGME.Model.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Records");

                });

            modelBuilder.Entity("SGME.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SGME.Model.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");


                    b.Property<string>("UserTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");


                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });


            modelBuilder.Entity("SGME.Model.Content", b =>
                {
                    b.HasOne("SGME.Model.Platform", "Platform")
                        .WithMany("Contents")
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("SGME.Model.ContentUsers", b =>
                {
                    b.HasOne("SGME.Model.Content", "Content")
                        .WithMany("ContentUsers")
                        .HasForeignKey("ContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGME.Model.User", "User")
                        .WithMany("ContentUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SGME.Model.PermissionPerUserType", b =>

            modelBuilder.Entity("SGME.Model.Comments", b =>
                {
                    b.HasOne("SGME.Model.User", null)
                        .WithOne("Comments")
                        .HasForeignKey("SGME.Model.Comments", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGME.Model.Record", b =>
                {
                    b.HasOne("SGME.Model.User", null)
                        .WithOne("Record")
                        .HasForeignKey("SGME.Model.Record", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGME.Model.User", b =>

                {
                    b.HasOne("SGME.Model.Permissions", "Permission")
                        .WithMany("PermissionPerUserTypes")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGME.Model.UserType", "UserType")
                        .WithMany("PermissionPerUserType")
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("SGME.Model.UsageHistory", b =>
                {
                    b.HasOne("SGME.Model.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGME.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SGME.Model.User", b =>
                {
                    b.HasOne("SGME.Model.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });


            modelBuilder.Entity("SGME.Model.Content", b =>
                {
                    b.Navigation("ContentUsers");
                });

            modelBuilder.Entity("SGME.Model.Permissions", b =>
                {
                    b.Navigation("PermissionPerUserTypes");
                });

            modelBuilder.Entity("SGME.Model.Platform", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("SGME.Model.User", b =>
                {
                    b.Navigation("ContentUsers");
                });

            modelBuilder.Entity("SGME.Model.UserType", b =>
                {
                    b.Navigation("PermissionPerUserType");

                    b.Navigation("Users");

            modelBuilder.Entity("SGME.Model.User", b =>
                {
                    b.Navigation("Comments")
                        .IsRequired();

                    b.Navigation("Record")
                        .IsRequired();

                });
#pragma warning restore 612, 618
        }
    }
}
