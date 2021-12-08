using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcwithSqliteDemo.Sql.Entities;

namespace mvcwithSqliteDemo.Controllers
{
    public class DepartController : Controller
    {
        private readonly SqlContext _context;

        public DepartController(SqlContext context)
        {
            _context = context;
        }

        // GET: Depart
        public async Task<IActionResult> Index()
        {
            return View(await _context.DepartMember.ToListAsync());
        }

        // GET: Depart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departMember = await _context.DepartMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departMember == null)
            {
                return NotFound();
            }

            return View(departMember);
        }

        // GET: Depart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,age,comment")] DepartMember departMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departMember);
        }

        // GET: Depart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departMember = await _context.DepartMember.FindAsync(id);
            if (departMember == null)
            {
                return NotFound();
            }
            return View(departMember);
        }

        // POST: Depart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,age,comment")] DepartMember departMember)
        {
            if (id != departMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartMemberExists(departMember.Id))
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
            return View(departMember);
        }

        // GET: Depart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departMember = await _context.DepartMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departMember == null)
            {
                return NotFound();
            }

            return View(departMember);
        }

        // POST: Depart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departMember = await _context.DepartMember.FindAsync(id);
            _context.DepartMember.Remove(departMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartMemberExists(int id)
        {
            return _context.DepartMember.Any(e => e.Id == id);
        }
    }
}
