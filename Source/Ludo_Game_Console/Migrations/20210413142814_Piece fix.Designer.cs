﻿// <auto-generated />
using LudoGame;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ludo_Game_Console.Migrations
{
    [DbContext(typeof(LudoContext))]
    [Migration("20210413142814_Piece fix")]
    partial class Piecefix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("LudoGame.Piece", b =>
                {
                    b.Property<int>("PieceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentSquareNr")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PieceNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Steps")
                        .HasColumnType("INTEGER");

                    b.HasKey("PieceId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Pieces");
                });

            modelBuilder.Entity("LudoGame.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int>("SaveGameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartSquareNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId");

                    b.HasIndex("SaveGameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("LudoGame.SaveGame", b =>
                {
                    b.Property<int>("SaveGameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SaveGameName")
                        .HasColumnType("TEXT");

                    b.HasKey("SaveGameId");

                    b.ToTable("SaveGame");
                });

            modelBuilder.Entity("LudoGame.Piece", b =>
                {
                    b.HasOne("LudoGame.Player", null)
                        .WithMany("Pieces")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LudoGame.Player", b =>
                {
                    b.HasOne("LudoGame.SaveGame", null)
                        .WithMany("Players")
                        .HasForeignKey("SaveGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LudoGame.Player", b =>
                {
                    b.Navigation("Pieces");
                });

            modelBuilder.Entity("LudoGame.SaveGame", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
