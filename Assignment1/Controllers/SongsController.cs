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
    public class SongsController : Controller
    {
        private readonly Assignment1Context _context;

        public SongsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Songs.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        public async Task<IActionResult> SongsInAlbum(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            ViewBag.AlbumTitle = _context.Albums.FirstOrDefault(a => a.Id == id).Name.ToString();

            var songs = _context.Songs.Where(m => m.Albums.Id == id).ToList();

            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        private bool SongsExists(int id)
        {
          return _context.Songs.Any(e => e.Id == id);
        }
    }
}
