using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Netmvc.Data;
using Netmvc.Models;

namespace Netmvc.Controllers
{
    public class DemoabcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemoabcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Demoabc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Demoabc.ToListAsync());
        }

        // GET: Demoabc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.Demoabc
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (demoabc == null)
            {
                return NotFound();
            }

            return View(demoabc);
        }

        // GET: Demoabc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Demoabc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,Phone")] Demoabc demoabc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demoabc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demoabc);
        }

        // GET: Demoabc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.Demoabc.FindAsync(id);
            if (demoabc == null)
            {
                return NotFound();
            }
            return View(demoabc);
        }

        // POST: Demoabc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,Email,Phone")] Demoabc demoabc)
        {
            if (id != demoabc.FullName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demoabc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoabcExists(demoabc.FullName))
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
            return View(demoabc);
        }

        // GET: Demoabc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.Demoabc
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (demoabc == null)
            {
                return NotFound();
            }

            return View(demoabc);
        }

        // POST: Demoabc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var demoabc = await _context.Demoabc.FindAsync(id);
            if (demoabc != null)
            {
                _context.Demoabc.Remove(demoabc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoabcExists(string id)
        {
            return _context.Demoabc.Any(e => e.FullName == id);
        }
    }
}
