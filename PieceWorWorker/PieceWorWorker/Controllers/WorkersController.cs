// WorkerControllers.cs
//         Title: Pieceworkworker
//       Created: November 2, 2021
//      Modified: December 15, 2021
//    Written By: Onur Ozkanca
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// Controls page for our page. This will define our actions when we click our tabs.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PieceWorWorker.Contexts;
using PieceWorWorker.Models;
using Microsoft.AspNetCore.Authorization;

namespace PieceWorWorker.Controllers
{
    [Authorize]
    public class WorkersController : Controller
    {
        private readonly WorkerContext _context;

        public WorkersController(WorkerContext context)
        {
            _context = context;
        }

        // GET: Workers
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers.ToListAsync());
        }

        // GET: Workers/Summary
        [AllowAnonymous]
        public async Task<IActionResult> Summary()
        {
            return View(await _context.Workers.ToListAsync());
        }

        // GET: Workers/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Messages,IsSenior")] PieceWorkWorkerModel pieceWorkWorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceWorkWorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.Workers.FindAsync(id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }
            return View(pieceWorkWorkerModel);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Messages,IsSenior")] PieceWorkWorkerModel pieceWorkWorkerModel)
        {
            if (id != pieceWorkWorkerModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceWorkWorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceWorkWorkerModelExists(pieceWorkWorkerModel.ID))
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
            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceWorkWorkerModel);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieceWorkWorkerModel = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(pieceWorkWorkerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceWorkWorkerModelExists(int id)
        {
            return _context.Workers.Any(e => e.ID == id);
        }
    }
}
