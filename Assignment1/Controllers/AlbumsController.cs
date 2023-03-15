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
    public class AlbumsController : Controller
    {
        private readonly Assignment1Context _context;

        public AlbumsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
              return View(await _context.Albums.ToListAsync());
        }

        public async Task<IActionResult> AlbumsByArtist(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }
                

            if (AlbumsByArtist == null)
            {
                return NotFound();
            }
            return View();
        }

        private bool AlbumsExists(int id)
        {
          return _context.Albums.Any(e => e.Id == id);
        }
    }
}
