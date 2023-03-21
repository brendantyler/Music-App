﻿// <auto-generated />
using System;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1.Migrations
{
    [DbContext(typeof(Assignment1Context))]
    [Migration("20230321062229_AddPodcasts")]
    partial class AddPodcasts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment1.Models.Albums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Assignment1.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Assignment1.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Playlist");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Assignment1.Models.PlaylistSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("Assignment1.Models.Podcast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Podcast");
                });

            modelBuilder.Entity("Assignment1.Models.PodcastListenerLists", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ListenerListId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ListenerListId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastListenerLists");
                });

            modelBuilder.Entity("Assignment1.Models.SongArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("SongId");

                    b.ToTable("SongArtists");
                });

            modelBuilder.Entity("Assignment1.Models.Songs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumsId");

                    b.ToTable("Songs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Songs");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Assignment1.Models.ListenerLists", b =>
                {
                    b.HasBaseType("Assignment1.Models.Playlist");

                    b.HasDiscriminator().HasValue("ListenerLists");
                });

            modelBuilder.Entity("Assignment1.Models.Episodes", b =>
                {
                    b.HasBaseType("Assignment1.Models.Songs");

                    b.Property<DateTime>("AirDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuestArtistId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.HasIndex("GuestArtistId");

                    b.HasIndex("PodcastId");

                    b.HasDiscriminator().HasValue("Episodes");
                });

            modelBuilder.Entity("Assignment1.Models.PlaylistSong", b =>
                {
                    b.HasOne("Assignment1.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSong")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Songs", "Song")
                        .WithMany("PlaylistSong")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Assignment1.Models.PodcastListenerLists", b =>
                {
                    b.HasOne("Assignment1.Models.ListenerLists", "ListenerList")
                        .WithMany()
                        .HasForeignKey("ListenerListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Podcast", "Podcast")
                        .WithMany()
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListenerList");

                    b.Navigation("Podcast");
                });

            modelBuilder.Entity("Assignment1.Models.SongArtist", b =>
                {
                    b.HasOne("Assignment1.Models.Artist", "Artist")
                        .WithMany("SongArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Songs", "Song")
                        .WithMany("SongArtists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Assignment1.Models.Songs", b =>
                {
                    b.HasOne("Assignment1.Models.Albums", "Albums")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumsId");

                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Assignment1.Models.Episodes", b =>
                {
                    b.HasOne("Assignment1.Models.Artist", "GuestArtist")
                        .WithMany()
                        .HasForeignKey("GuestArtistId");

                    b.HasOne("Assignment1.Models.Podcast", "Podcast")
                        .WithMany()
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuestArtist");

                    b.Navigation("Podcast");
                });

            modelBuilder.Entity("Assignment1.Models.Albums", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Assignment1.Models.Artist", b =>
                {
                    b.Navigation("SongArtists");
                });

            modelBuilder.Entity("Assignment1.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSong");
                });

            modelBuilder.Entity("Assignment1.Models.Songs", b =>
                {
                    b.Navigation("PlaylistSong");

                    b.Navigation("SongArtists");
                });
#pragma warning restore 612, 618
        }
    }
}
