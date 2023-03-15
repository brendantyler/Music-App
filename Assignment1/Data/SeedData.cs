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

            Artist Artist1 = new Artist("J.cole");
            Artist Artist2 = new Artist("Musiq Soulchild");
            Artist Artist3 = new Artist("Kehlani");
            Artist Artist4 = new Artist("Monsieur Perine");
            Artist Artist5 = new Artist("Vicente Garcia");

            Albums Album1 = new Albums("The Off Season");
            Albums Album2 = new Albums("2014 Forest Hills Drive");
            Albums Album3 = new Albums("Aijuswanaseing");
            Albums Album4 = new Albums("Juslisen");
            Albums Album5 = new Albums("Cloud19");
            Albums Album6 = new Albums("Caja de Musica");

            Songs song1 = new Songs("my.life", 196, Album1);
            Songs song2 = new Songs("pride.is.the.devil", 218, Album1);
            Songs song3 = new Songs("amari", 148, Album1);
            Songs song4 = new Songs("interlude", 133, Album1);
            Songs song5 = new Songs("the.climb.back", 306, Album1);
            
            Songs song6 = new Songs("No Role Modelz", 292, Album2); 
            Songs song7 = new Songs("Fire Squad", 288, Album2);
            Songs song8 = new Songs("Apparently", 292, Album2);
            Songs song9 = new Songs("A Tale Of Two Citiez", 269, Album2);
            Songs song10 = new Songs("Love Yourz", 222, Album2); 

            Songs song11 = new Songs("Just Friends (Sunny)", 251, Album3);
            Songs song12 = new Songs("Love", 304, Album3);
            Songs song13 = new Songs("Girl Next Door", 286, Album3);
            Songs song14 = new Songs("My Girl", 200, Album3);

            Songs song15 = new Songs("Newness", 226, Album4);
            Songs song16 = new Songs("Halfcrazy", 254, Album4);
            Songs song17 = new Songs("Dontchange", 304, Album4);
                
            Songs song18 = new Songs("As I Am", 246, Album5);
            Songs song19 = new Songs("FWU", 202, Album5);

            Songs song20 = new Songs("Nuestra Cancion", 260, Album6);

            //Initialize SongArtist
            SongArtist songArtist1 = new SongArtist(Artist1, song1);
            SongArtist songArtist2 = new SongArtist(Artist1, song2);
            SongArtist songArtist3 = new SongArtist(Artist1, song3);
            SongArtist songArtist4 = new SongArtist(Artist1, song4);
            SongArtist songArtist5 = new SongArtist(Artist1, song5);
            SongArtist songArtist6 = new SongArtist(Artist1, song6);
            SongArtist songArtist7 = new SongArtist(Artist1, song7);
            SongArtist songArtist8 = new SongArtist(Artist1, song8);
            SongArtist songArtist9 = new SongArtist(Artist1, song9);
            SongArtist songArtist10 = new SongArtist(Artist1, song10);

            SongArtist songArtist11 = new SongArtist(Artist2, song11);
            SongArtist songArtist12 = new SongArtist(Artist2, song12);
            SongArtist songArtist13 = new SongArtist(Artist2, song13);
            SongArtist songArtist14 = new SongArtist(Artist2, song14);
            SongArtist songArtist15 = new SongArtist(Artist2, song15);
            SongArtist songArtist16 = new SongArtist(Artist2, song16);
            SongArtist songArtist17 = new SongArtist(Artist2, song17);

            SongArtist songArtist18 = new SongArtist(Artist3, song18);
            SongArtist songArtist19 = new SongArtist(Artist3, song19);

            SongArtist songArtist20 = new SongArtist(Artist4, song20);
            SongArtist songArtist21 = new SongArtist(Artist5, song20);


            if (!context.Artists.Any())
            {
                context.Artists.Add(Artist1);
                context.Artists.Add(Artist2);
                context.Artists.Add(Artist3);
                context.Artists.Add(Artist4);
                context.Artists.Add(Artist5);
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


            await context.SaveChangesAsync();
        }
    }
}