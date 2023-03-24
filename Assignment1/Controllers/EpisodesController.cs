using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;
using Microsoft.Data.SqlClient;

namespace Assignment1.Controllers
{
    public class EpisodesController : Controller
    {
        private readonly Assignment1Context _context;

        public EpisodesController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Episodes
        public async Task<IActionResult> Index()
        {
            var assignment1Context = _context.Episodes.Include(e => e.Podcast);
            return View(await assignment1Context.ToListAsync());
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id, string sortOrder)
        {
            ViewBag.DateSortParm = sortOrder == "date_desc" ? "Date" : "date_desc";

            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            ViewBag.PodcastTitle = _context.Podcast.FirstOrDefault(a => a.Id == id).Name.ToString();

            var episodes = _context.Episodes.Where(m => m.Podcast.Id == id);
            ViewBag.AscOrDesc = "Ascending";

            switch (sortOrder)
            {
                case "date_desc":
                    ViewBag.AscOrDesc = "Descending";
                    episodes = episodes.OrderByDescending(s => s.Duration);
                    break;
                case "Date":
                    ViewBag.AscOrDesc = "Ascending";
                    episodes = episodes.OrderBy(s => s.Duration);
                    break;
                default:
                    episodes = episodes.OrderBy(s => s.Id);
                    break;
            }

            if (episodes == null)
            {
                return NotFound();
            }

            return View(episodes.ToList());
        }

        // GET: Episodes/Create
        public IActionResult Create()
        {
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "Id", "Name");
            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PodcastId,AirDate,Id,Title,Duration,MediaCollectId")] Episodes episodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(episodes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "Id", "Name", episodes.PodcastId);
            return View(episodes);
        }

        // GET: Episodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episodes = await _context.Episodes.FindAsync(id);
            if (episodes == null)
            {
                return NotFound();
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "Id", "Name", episodes.PodcastId);
            return View(episodes);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PodcastId,AirDate,Id,Title,Duration,MediaCollectId")] Episodes episodes)
        {
            if (id != episodes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodesExists(episodes.Id))
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
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "Id", "Name", episodes.PodcastId);
            return View(episodes);
        }

        // GET: Episodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episodes = await _context.Episodes
                .Include(e => e.Podcast)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episodes == null)
            {
                return NotFound();
            }

            return View(episodes);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Episodes == null)
            {
                return Problem("Entity set 'Assignment1Context.Episodes'  is null.");
            }
            var episodes = await _context.Episodes.FindAsync(id);
            if (episodes != null)
            {
                _context.Episodes.Remove(episodes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodesExists(int id)
        {
          return (_context.Episodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
