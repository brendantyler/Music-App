using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class PlaylistSongsController : Controller
    {
        private readonly Assignment1Context _context;

        public PlaylistSongsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: PlaylistSongs
        public async Task<IActionResult> Index()
        {
            var assignment1Context = _context.PlaylistSongs.Include(p => p.Playlist).Include(p => p.Song);
            return View(await assignment1Context.ToListAsync());
        }

        // GET: PlaylistSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlaylistSongs == null)
            {
                return NotFound();
            }

            var playlistSong = _context.PlaylistSongs
                .Include(p => p.Playlist)
                .Include(p => p.Song)
                .Where(m => m.PlaylistId == id);

            if (playlistSong == null)
            {
                return NotFound();
            }

            return View(playlistSong);
        }

        // GET: PlaylistSongs/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id");
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id");
            return View();
        }

        // POST: PlaylistSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,PlaylistId,TimeAdded")] PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongId);
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlaylistSongs == null)
            {
                return NotFound();
            }

            var playlistSong = await _context.PlaylistSongs.FindAsync(id);
            if (playlistSong == null)
            {
                return NotFound();
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongId);
            return View(playlistSong);
        }

        // POST: PlaylistSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,PlaylistId,TimeAdded")] PlaylistSong playlistSong)
        {
            if (id != playlistSong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistSongExists(playlistSong.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongId);
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlaylistSongs == null)
            {
                return NotFound();
            }

            var playlistSong = await _context.PlaylistSongs
                .Include(p => p.Playlist)
                .Include(p => p.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistSong == null)
            {
                return NotFound();
            }

            return View(playlistSong);
        }

        // POST: PlaylistSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlaylistSongs == null)
            {
                return Problem("Entity set 'Assignment1Context.PlaylistSongs'  is null.");
            }
            var playlistSong = await _context.PlaylistSongs.FindAsync(id);
            if (playlistSong != null)
            {
                _context.PlaylistSongs.Remove(playlistSong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistSongExists(int id)
        {
          return _context.PlaylistSongs.Any(e => e.Id == id);
        }
    }
}
