using Assignment1.Data;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new Assignment1Context(serviceProvider.GetRequiredService<DbContextOptions<Assignment1Context>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Artist Artist1 = new("J.cole");
            Artist Artist2 = new("Musiq Soulchild");
            Artist Artist3 = new("Kehlani");
            Artist Artist4 = new("Monsieur Perine");
            Artist Artist5 = new("Vicente Garcia");
            Artist PodcastArtist1 = new("Joe Rogan");
            Artist PodcastArtist2 = new("Michael Bisping");
            Artist PodcastArtist3 = new("Dr. Huberman");
            Artist PodcastArtist4 = new("Jeff Nippard");

            Albums Album1 = new("The Off Season");
            Albums Album2 = new("2014 Forest Hills Drive");
            Albums Album3 = new("Aijuswanaseing");
            Albums Album4 = new("Juslisen");
            Albums Album5 = new("Cloud19");
            Albums Album6 = new("Caja de Musica");

            Songs song1 = new("my.life", 196, Album1);
            Songs song2 = new("pride.is.the.devil", 218, Album1);
            Songs song3 = new("amari", 148, Album1);
            Songs song4 = new("interlude", 133, Album1);
            Songs song5 = new("the.climb.back", 306, Album1);
            
            Songs song6 = new("No Role Modelz", 292, Album2); 
            Songs song7 = new("Fire Squad", 288, Album2);
            Songs song8 = new("Apparently", 292, Album2);
            Songs song9 = new("A Tale Of Two Citiez", 269, Album2);
            Songs song10 = new("Love Yourz", 222, Album2); 

            Songs song11 = new("Just Friends (Sunny)", 251, Album3);
            Songs song12 = new("Love", 304, Album3);
            Songs song13 = new("Girl Next Door", 286, Album3);
            Songs song14 = new("My Girl", 200, Album3);

            Songs song15 = new("Newness", 226, Album4);
            Songs song16 = new("Halfcrazy", 254, Album4);
            Songs song17 = new("Dontchange", 304, Album4);
                    
            Songs song18 = new("As I Am", 246, Album5);
            Songs song19 = new("FWU", 202, Album5);
                
            Songs song20 = new("Nuestra Cancion", 260, Album6);
                
            //Initialize SongArtist
            SongArtist songArtist1 = new (Artist1, song1, "Lead");
            SongArtist songArtist2 = new(Artist1, song2, "Lead");
            SongArtist songArtist3 = new(Artist1, song3, "Lead");
            SongArtist songArtist4 = new(Artist1, song4, "Lead");
            SongArtist songArtist5 = new(Artist1, song5, "Lead");
            SongArtist songArtist6 = new(Artist1, song6, "Lead");
            SongArtist songArtist7 = new(Artist1, song7, "Lead");
            SongArtist songArtist8 = new(Artist1, song8, "Lead");
            SongArtist songArtist9 = new(Artist1, song9, "Lead");
            SongArtist songArtist10 = new(Artist1, song10, "Lead");

            SongArtist songArtist11 = new(Artist2, song11, "Lead");
            SongArtist songArtist12 = new(Artist2, song12, "Lead");
            SongArtist songArtist13 = new(Artist2, song13, "Lead");
            SongArtist songArtist14 = new(Artist2, song14, "Lead");
            SongArtist songArtist15 = new(Artist2, song15, "Lead");
            SongArtist songArtist16 = new(Artist2, song16, "Lead");
            SongArtist songArtist17 = new(Artist2, song17, "Lead");

            SongArtist songArtist18 = new(Artist3, song18, "Lead");
            SongArtist songArtist19 = new(Artist3, song19, "Lead");

            SongArtist songArtist20 = new(Artist4, song20, "Lead");
            SongArtist songArtist21 = new(Artist5, song20, "Feature");

            //Instantiate Playlist
            Playlist playlist1 = new ("PaRappa the Rapper");
            Playlist playlist2 = new("SlowJams");
            Playlist playlist3 = new("Sun's out");

            PlaylistSong playSong1 = new(song1, playlist1, DateTime.Now);
            PlaylistSong playSong2 = new(song2, playlist1, DateTime.Now);
            PlaylistSong playSong3 = new(song3, playlist1, DateTime.Now);

            PlaylistSong playSong4 = new(song10, playlist2, DateTime.Now);
            PlaylistSong playSong5 = new(song11, playlist2, DateTime.Now);
            PlaylistSong playSong6 = new(song12, playlist2, DateTime.Now);

            PlaylistSong playSong7 = new(song20, playlist3, DateTime.Now);
            PlaylistSong playSong8 = new(song14, playlist3, DateTime.Now);
            PlaylistSong playSong9 = new(song13, playlist3, DateTime.Now);


            ListenerLists listenerList1 = new("MMA Podcasts");
            ListenerLists listenerList2 = new("Gym Podcasts");

            Podcast podcast1 = new("Joe Rogan Experience");
            Podcast podcast2 = new("Believe You Me with Michael Bisping");
            Podcast podcast3 = new("Huberman Lab");
            Podcast podcast4 = new("Jeff Nippard Show");

            Episodes episode1 = new("JRE #1958", 7200, podcast1, null, new DateTime(2022, 01, 12));
            Episodes episode2 = new("JRE #1959", 7900, podcast1, null, new DateTime(2022, 01, 18));
            Episodes episode3 = new("JRE #1960", 8100, podcast1, null, new DateTime(2022, 01, 27));

            Episodes episode4 = new("That one UFC fight", 6500, podcast2, null, new DateTime(2022, 01, 12));
            Episodes episode5 = new("That Second UFC Fight", 7086, podcast2, null, new DateTime(2022, 02, 15));
            Episodes episode6 = new("That Third UFC Fight", 7100, podcast2, null, new DateTime(2022, 03, 15));

            Episodes episode7 = new("Creatine? Useful or Not", 8200, podcast3, null, new DateTime(2022, 01, 16));
            Episodes episode8 = new("Anabolic Steroids Arent Good", 7400, podcast3, null, new DateTime(2022, 02, 05));
            Episodes episode9 = new("How much do you need to workout", 6800, podcast3, null, new DateTime(2022, 02, 11));

            Episodes episode10 = new("What is a good Rep range", 4000, podcast4, null, new DateTime(2022, 01, 16));
            Episodes episode11 = new("Best Activation for Delts", 5000, podcast4, null, new DateTime(2022, 01, 25));
            Episodes episode12 = new("How important is Rest", 6700, podcast4, null, new DateTime(2022, 02, 10));

            PodcastListenerLists podcastListenerList1 = new(podcast1, listenerList1, DateTime.Now);
            PodcastListenerLists podcastListenerList2 = new(podcast2, listenerList1, DateTime.Now);
            PodcastListenerLists podcastListenerList3 = new(podcast3, listenerList2, DateTime.Now);
            PodcastListenerLists podcastListenerList4 = new(podcast4, listenerList2, DateTime.Now);

            if (!context.Artists.Any())
            {
                context.Artists.Add(Artist1);
                context.Artists.Add(Artist2);
                context.Artists.Add(Artist3);
                context.Artists.Add(Artist4);
                context.Artists.Add(Artist5);

                context.Artists.Add(PodcastArtist1);
                context.Artists.Add(PodcastArtist2);
                context.Artists.Add(PodcastArtist3);
                context.Artists.Add(PodcastArtist4);
                context.SaveChanges();
            }


            if (!context.Albums.Any())
            {
                context.Albums.Add(Album1);
                context.Albums.Add(Album2);
                context.Albums.Add(Album3);
                context.Albums.Add(Album4);
                context.Albums.Add(Album5);
                context.Albums.Add(Album6);
                context.SaveChanges();
            }

            if (!context.Songs.Any())
            {
                context.Songs.Add(song1);
                context.Songs.Add(song2);
                context.Songs.Add(song3);
                context.Songs.Add(song4);
                context.Songs.Add(song5);
                context.Songs.Add(song6);
                context.Songs.Add(song7);
                context.Songs.Add(song8);
                context.Songs.Add(song9);
                context.Songs.Add(song10);
                context.Songs.Add(song11);
                context.Songs.Add(song12);
                context.Songs.Add(song13);
                context.Songs.Add(song14);
                context.Songs.Add(song15);
                context.Songs.Add(song16);
                context.Songs.Add(song17);
                context.Songs.Add(song18);
                context.Songs.Add(song19);
                context.Songs.Add(song20);

                Album1.Songs.Add(song1);
                Album1.Songs.Add(song2);
                Album1.Songs.Add(song3);
                Album1.Songs.Add(song4);
                Album1.Songs.Add(song5);

                Album2.Songs.Add(song6);
                Album2.Songs.Add(song7);
                Album2.Songs.Add(song8);
                Album2.Songs.Add(song9);
                Album2.Songs.Add(song10);

                Album3.Songs.Add(song11);
                Album3.Songs.Add(song12);
                Album3.Songs.Add(song13);
                Album3.Songs.Add(song14);

                Album4.Songs.Add(song15);
                Album4.Songs.Add(song16);
                Album4.Songs.Add(song17);

                Album5.Songs.Add(song18);
                Album5.Songs.Add(song19);

                Album6.Songs.Add(song20);
            }


            if (!context.SongArtists.Any())
            {
                context.SongArtists.Add(songArtist1);
                context.SongArtists.Add(songArtist2);
                context.SongArtists.Add(songArtist3);
                context.SongArtists.Add(songArtist4);
                context.SongArtists.Add(songArtist5);
                context.SongArtists.Add(songArtist6);
                context.SongArtists.Add(songArtist7);
                context.SongArtists.Add(songArtist8);
                context.SongArtists.Add(songArtist9);
                context.SongArtists.Add(songArtist10);
                context.SongArtists.Add(songArtist11);
                context.SongArtists.Add(songArtist12);
                context.SongArtists.Add(songArtist13);
                context.SongArtists.Add(songArtist14);
                context.SongArtists.Add(songArtist15);
                context.SongArtists.Add(songArtist16);
                context.SongArtists.Add(songArtist17);
                context.SongArtists.Add(songArtist18);
                context.SongArtists.Add(songArtist19);
                context.SongArtists.Add(songArtist20);
                context.SongArtists.Add(songArtist21);
                context.SaveChanges();
            }

            if (!context.Playlists.Any())
            {
                context.Playlists.Add(playlist1);
                context.Playlists.Add(playlist2);
                context.Playlists.Add(playlist3);
                context.SaveChanges();

            }

            if (!context.PlaylistSongs.Any())
            {
                context.PlaylistSongs.Add(playSong1);
                context.PlaylistSongs.Add(playSong2);
                context.PlaylistSongs.Add(playSong3);
                context.PlaylistSongs.Add(playSong4);
                context.PlaylistSongs.Add(playSong5);
                context.PlaylistSongs.Add(playSong6);
                context.PlaylistSongs.Add(playSong7);
                context.PlaylistSongs.Add(playSong8);
                context.PlaylistSongs.Add(playSong9);
                context.SaveChanges();
            }

            //Add Podcast Data

            if (!context.ListenerLists.Any())
            {
                context.ListenerLists.Add(listenerList1);
                context.ListenerLists.Add(listenerList2);
                context.SaveChanges();

            }

            if (!context.Podcast.Any()) 
            {   
                context.Podcast.Add(podcast1);
                context.Podcast.Add(podcast2);
                context.Podcast.Add(podcast3);
                context.Podcast.Add(podcast4);
                context.SaveChanges();
            }

            if (!context.Episodes.Any())
            {
                context.Episodes.Add(episode1);
                context.Episodes.Add(episode2);
                context.Episodes.Add(episode3);
                context.Episodes.Add(episode4);
                context.Episodes.Add(episode5);
                context.Episodes.Add(episode6);
                context.Episodes.Add(episode7);
                context.Episodes.Add(episode8);
                context.Episodes.Add(episode9);
                context.Episodes.Add(episode10);
                context.Episodes.Add(episode11);
                context.Episodes.Add(episode12);
                context.SaveChanges();
            }

            if (!context.PodcastListenerLists.Any())
            {
                context.PodcastListenerLists.Add(podcastListenerList1);
                context.PodcastListenerLists.Add(podcastListenerList2);
                context.PodcastListenerLists.Add(podcastListenerList3);
                context.PodcastListenerLists.Add(podcastListenerList4);
                context.SaveChanges();
            }

            if (context.Podcast.Any()) 
            {
                podcast1.Cast.Add(PodcastArtist1);
                podcast2.Cast.Add(PodcastArtist2);
                podcast3.Cast.Add(PodcastArtist3);
                podcast4.Cast.Add(PodcastArtist4);
            }

            await context.SaveChangesAsync();
        }
    }
}