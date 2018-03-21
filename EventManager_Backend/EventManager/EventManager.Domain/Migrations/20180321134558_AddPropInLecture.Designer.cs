﻿// <auto-generated />
using EventManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EventManager.Domain.Migrations
{
    [DbContext(typeof(EventManagerContext))]
    [Migration("20180321134558_AddPropInLecture")]
    partial class AddPropInLecture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventManager.Domain.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int>("ParticipantNumber");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventManager.Domain.Models.EventUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("EventManager.Domain.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<int>("ParticipantNumber");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("EventManager.Domain.Models.LectureUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LectureId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("UserId");

                    b.ToTable("LectureUser");
                });

            modelBuilder.Entity("EventManager.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("LectureId");

                    b.Property<string>("Nickname");

                    b.Property<int>("Rate");

                    b.Property<int>("ReviewerId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("EventManager.Domain.Models.SimpleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("SimpleUser");
                });

            modelBuilder.Entity("EventManager.Domain.Models.EventUser", b =>
                {
                    b.HasOne("EventManager.Domain.Models.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Domain.Models.SimpleUser", "SimpleUser")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EventManager.Domain.Models.Lecture", b =>
                {
                    b.HasOne("EventManager.Domain.Models.Event", "Event")
                        .WithMany("Lectures")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Domain.Models.LectureUser", b =>
                {
                    b.HasOne("EventManager.Domain.Models.Lecture", "Lecture")
                        .WithMany("LectureUsers")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Domain.Models.SimpleUser", "SimpleUser")
                        .WithMany("LectureUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Domain.Models.Review", b =>
                {
                    b.HasOne("EventManager.Domain.Models.Lecture", "Lecture")
                        .WithMany("Reviews")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Domain.Models.SimpleUser", "SimpleUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
