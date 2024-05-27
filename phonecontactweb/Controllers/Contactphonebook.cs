using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phonecontactweb.Data;
using phonecontactweb.Models;

namespace phonecontactweb.Controllers
{
    public class Contactphonebook : Controller
    {
        private readonly phonecontactwebContext _context;

        public Contactphonebook(phonecontactwebContext context)
        {
            _context = context;
        }

        // GET: Contactphonebook
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactbook.ToListAsync());
        }

        // GET: Contactphonebook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactbook = await _context.Contactbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactbook == null)
            {
                return NotFound();
            }

            return View(contactbook);
        }

        // GET: Contactphonebook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactphonebook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Email,UserId")] Contactbook contactbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactbook);
        }

        // GET: Contactphonebook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactbook = await _context.Contactbook.FindAsync(id);
            if (contactbook == null)
            {
                return NotFound();
            }
            return View(contactbook);
        }

        // POST: Contactphonebook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email,UserId")] Contactbook contactbook)
        {
            if (id != contactbook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactbookExists(contactbook.Id))
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
            return View(contactbook);
        }

        // GET: Contactphonebook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactbook = await _context.Contactbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactbook == null)
            {
                return NotFound();
            }

            return View(contactbook);
        }

        // POST: Contactphonebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactbook = await _context.Contactbook.FindAsync(id);
            if (contactbook != null)
            {
                _context.Contactbook.Remove(contactbook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactbookExists(int id)
        {
            return _context.Contactbook.Any(e => e.Id == id);
        }
    }
}
