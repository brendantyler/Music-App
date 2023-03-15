using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;
using Assignment1.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Assignment1.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly Assignment1Context _context;

        public PlaylistsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
              return View(await _context.Playlists.ToListAsync());
        }

        // GET: Playlist/AddToPlaylist
        [HttpGet]
        public IActionResult AddToPlaylist(int id)
        {

            Songs song = _context.Songs.FirstOrDefault(s => s.Id == id);

            AddSongToPlaylistViewModel vm = new AddSongToPlaylistViewModel(song, _context.Playlists.ToList());

            ViewBag.songName = song.Title;

            return View(vm);
        }
        // POST: Playlists/AddToPlaylist
        [HttpPost]
        public async Task<IActionResult> AddToPlaylist(AddSongToPlaylistViewModel vm)
        {
            if (vm.SongId!=null && vm.PlaylistId != null)
            {
                ViewBag.PS = _context.PlaylistSongs.Count();

                PlaylistSong playlistSong = new PlaylistSong();

                Playlist playlist = _context.Playlists.First(p => p.Id == vm.PlaylistId);
                Songs song = _context.Songs.First(s => s.Id==vm.SongId);

                playlistSong.Playlist = playlist;
                playlistSong.Song = song;

                _context.PlaylistSongs.Add(playlistSong);
                _context.SaveChanges();

                return RedirectToAction("Index");

            } else
            {
                return NotFound();
            }
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }


        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'Assignment1Context.Playlists'  is null.");
            }
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
