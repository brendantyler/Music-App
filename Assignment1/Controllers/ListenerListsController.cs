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

namespace Assignment1.Controllers
{
    public class ListenerListsController : Controller
    {
        private readonly Assignment1Context _context;

        public ListenerListsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: ListenerLists
        public async Task<IActionResult> Index()
        {
              return _context.ListenerLists != null ? 
                          View(await _context.ListenerLists.ToListAsync()) :
                          Problem("Entity set 'Assignment1Context.ListenerLists'  is null.");
        }

        // GET: ListenerLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            var listenerLists = await _context.ListenerLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerLists == null)
            {
                return NotFound();
            }

            return View(listenerLists);
        }

        [HttpGet]
        public IActionResult AddToList(int id)
        {

            Podcast podcast = _context.Podcast.FirstOrDefault(s => s.Id == id);

            PodcastToListViewModel vm = new PodcastToListViewModel(podcast, _context.ListenerLists.ToList());

            ViewBag.songName = podcast.Name;

            return View(vm);
        }
        // POST: Playlists/AddToPlaylist
        [HttpPost]
        public async Task<IActionResult> AddToList(PodcastToListViewModel vm)
        {
            if (vm.PodcastId != null && vm.ListenerListsId != null)
            {
                ViewBag.PS = _context.PlaylistSongs.Count();

                PodcastListenerLists listpod= new PodcastListenerLists();

                ListenerLists list = _context.ListenerLists.First(p => p.Id == vm.ListenerListsId);
                Podcast pod = _context.Podcast.First(s => s.Id == vm.PodcastId);

                listpod.ListenerList = list;
                listpod.Podcast = pod;

                _context.PodcastListenerLists.Add(listpod);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return NotFound();
            }
        }

        // GET: ListenerLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListenerLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ListenerLists listenerLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenerLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listenerLists);
        }

        // GET: ListenerLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            var listenerLists = await _context.ListenerLists.FindAsync(id);
            if (listenerLists == null)
            {
                return NotFound();
            }
            return View(listenerLists);
        }

        // POST: ListenerLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ListenerLists listenerLists)
        {
            if (id != listenerLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenerLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenerListsExists(listenerLists.Id))
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
            return View(listenerLists);
        }

        // GET: ListenerLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            var listenerLists = await _context.ListenerLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerLists == null)
            {
                return NotFound();
            }

            return View(listenerLists);
        }

        // POST: ListenerLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListenerLists == null)
            {
                return Problem("Entity set 'Assignment1Context.ListenerLists'  is null.");
            }
            var listenerLists = await _context.ListenerLists.FindAsync(id);
            if (listenerLists != null)
            {
                _context.ListenerLists.Remove(listenerLists);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenerListsExists(int id)
        {
          return (_context.ListenerLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
