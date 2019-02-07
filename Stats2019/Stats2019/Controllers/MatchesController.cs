using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stats2019.Models;

namespace Stats2019.Controllers
{
    public class MatchesController : Controller
    {
        private readonly Stats2019Context _context;

        public MatchesController(Stats2019Context context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var stats2019Context = _context.Matches.Include(m => m.Arena).Include(m => m.Series).Include(m => m.TeamHome);
            return View(await stats2019Context.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.Arena)
                .Include(m => m.Series)
                .Include(m => m.TeamHome)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id");
            ViewData["SeriesId"] = new SelectList(_context.Set<Series>(), "Id", "Id");
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchDate,Day,TeamAway,ScoreTeamHome,ScoreTeamAway,PersonId,SeriesId,ArenaId,TeamId")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", matches.ArenaId);
            ViewData["SeriesId"] = new SelectList(_context.Set<Series>(), "Id", "Id", matches.SeriesId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", matches.TeamId);
            return View(matches);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", matches.ArenaId);
            ViewData["SeriesId"] = new SelectList(_context.Set<Series>(), "Id", "Id", matches.SeriesId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", matches.TeamId);
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchDate,Day,TeamAway,ScoreTeamHome,ScoreTeamAway,PersonId,SeriesId,ArenaId,TeamId")] Matches matches)
        {
            if (id != matches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchesExists(matches.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", matches.ArenaId);
            ViewData["SeriesId"] = new SelectList(_context.Set<Series>(), "Id", "Id", matches.SeriesId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", matches.TeamId);
            return View(matches);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.Arena)
                .Include(m => m.Series)
                .Include(m => m.TeamHome)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
