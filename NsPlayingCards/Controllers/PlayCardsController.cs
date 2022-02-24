using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NsPlayingCards.Data;
using NsPlayingCards.Models;

namespace NsPlayingCards.Controllers
{
    public class PlayCardsController : Controller
    {
        private readonly NsPlayingCardsContext _context;

        public PlayCardsController(NsPlayingCardsContext context)
        {
            _context = context;
        }

        // GET: PlayCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayCard.ToListAsync());
        }

        // GET: PlayCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playCard = await _context.PlayCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playCard == null)
            {
                return NotFound();
            }

            return View(playCard);
        }

        // GET: PlayCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardName,CardShape,CardColor,Type,Rating")] PlayCard playCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playCard);
        }

        // GET: PlayCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playCard = await _context.PlayCard.FindAsync(id);
            if (playCard == null)
            {
                return NotFound();
            }
            return View(playCard);
        }

        // POST: PlayCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardName,CardShape,CardColor,Rating")] PlayCard playCard)
        {
            if (id != playCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayCardExists(playCard.Id))
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
            return View(playCard);
        }

        // GET: PlayCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playCard = await _context.PlayCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playCard == null)
            {
                return NotFound();
            }

            return View(playCard);
        }

        // POST: PlayCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playCard = await _context.PlayCard.FindAsync(id);
            _context.PlayCard.Remove(playCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayCardExists(int id)
        {
            return _context.PlayCard.Any(e => e.Id == id);
        }
    }
}
