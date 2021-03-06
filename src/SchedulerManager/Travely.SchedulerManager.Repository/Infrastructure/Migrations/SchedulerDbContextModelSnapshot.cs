// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travely.SchedulerManager.Repository;

namespace Travely.SchedulerManager.Repository.Infrastructure.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    partial class SchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("JsonData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MessageTemplateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<long>("RecurseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MessageTemplateId" }, "IX_ScheduleInfos_MessageTemplateId");

                    b.ToTable("ScheduleInfos");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleJob", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("ScheduleInfoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ScheduleInfoId" }, "IX_ScheduleJobs_ScheduleInfoId");

                    b.ToTable("ScheduleJobs");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleMessageTemplate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateName")
                        .HasMaxLength(250)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MessageTemplates");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.UserSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("ScheduleInfoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ScheduleInfoId" }, "IX_UserSchedules_ScheduleInfoId");

                    b.ToTable("UserSchedules");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleInfo", b =>
                {
                    b.HasOne("Travely.SchedulerManager.Repository.Entities.ScheduleMessageTemplate", "ScheduleMessageTemplate")
                        .WithMany("ScheduleInfos")
                        .HasForeignKey("MessageTemplateId")
                        .HasConstraintName("FK_Schedule_MessageTemplate")
                        .IsRequired();

                    b.Navigation("ScheduleMessageTemplate");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleJob", b =>
                {
                    b.HasOne("Travely.SchedulerManager.Repository.Entities.ScheduleInfo", "ScheduleInfo")
                        .WithMany("ScheduleJobs")
                        .HasForeignKey("ScheduleInfoId")
                        .HasConstraintName("FK_ScheduleJobs_Schedule")
                        .IsRequired();

                    b.Navigation("ScheduleInfo");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.UserSchedule", b =>
                {
                    b.HasOne("Travely.SchedulerManager.Repository.Entities.ScheduleInfo", "ScheduleInfo")
                        .WithMany("UserSchedules")
                        .HasForeignKey("ScheduleInfoId")
                        .HasConstraintName("FK_UserSchedule_Schedule")
                        .IsRequired();

                    b.Navigation("ScheduleInfo");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleInfo", b =>
                {
                    b.Navigation("ScheduleJobs");

                    b.Navigation("UserSchedules");
                });

            modelBuilder.Entity("Travely.SchedulerManager.Repository.Entities.ScheduleMessageTemplate", b =>
                {
                    b.Navigation("ScheduleInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
