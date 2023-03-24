﻿// <auto-generated />
using System;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1.Migrations
{
    [DbContext(typeof(Assignment1Context))]
    partial class Assignment1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("PodcastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PodcastId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Assignment1.Models.Episodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AirDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("GuestArtistId")
                        .HasColumnType("int");

                    b.Property<int>("MediaCollectId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GuestArtistId");

                    b.HasIndex("PodcastId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Assignment1.Models.ListenerLists", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("ListenerLists");
                });

            modelBuilder.Entity("Assignment1.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Podcast");
                });

            modelBuilder.Entity("Assignment1.Models.PodcastAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastAuth");
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
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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

                    b.Property<int>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MediaCollectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumsId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Assignment1.Models.Artist", b =>
                {
                    b.HasOne("Assignment1.Models.Podcast", null)
                        .WithMany("Cast")
                        .HasForeignKey("PodcastId");
                });

            modelBuilder.Entity("Assignment1.Models.Episodes", b =>
                {
                    b.HasOne("Assignment1.Models.Artist", "GuestArtist")
                        .WithMany()
                        .HasForeignKey("GuestArtistId");

                    b.HasOne("Assignment1.Models.Podcast", "Podcast")
                        .WithMany("Episodes")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuestArtist");

                    b.Navigation("Podcast");
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

            modelBuilder.Entity("Assignment1.Models.PodcastAuth", b =>
                {
                    b.HasOne("Assignment1.Models.Artist", "Artist")
                        .WithMany("PodcastAuths")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Podcast", "Podcast")
                        .WithMany("PodcastAuth")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Podcast");
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
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Assignment1.Models.Albums", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Assignment1.Models.Artist", b =>
                {
                    b.Navigation("PodcastAuths");

                    b.Navigation("SongArtists");
                });

            modelBuilder.Entity("Assignment1.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSong");
                });

            modelBuilder.Entity("Assignment1.Models.Podcast", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("Episodes");

                    b.Navigation("PodcastAuth");
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
