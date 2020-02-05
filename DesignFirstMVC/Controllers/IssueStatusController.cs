using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignFirstMVC.Models;

namespace DesignFirstMVC.Controllers
{
    public class IssueStatusController : Controller
    {
        private readonly DesignFirstContext _context;

        public IssueStatusController(DesignFirstContext context)
        {
            _context = context;
        }

        // GET: IssueStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.IssueStatus.ToListAsync());
        }

        // GET: IssueStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueStatus = await _context.IssueStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueStatus == null)
            {
                return NotFound();
            }

            return View(issueStatus);
        }

        // GET: IssueStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IssueStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] IssueStatus issueStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issueStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issueStatus);
        }

        // GET: IssueStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueStatus = await _context.IssueStatus.FindAsync(id);
            if (issueStatus == null)
            {
                return NotFound();
            }
            return View(issueStatus);
        }

        // POST: IssueStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] IssueStatus issueStatus)
        {
            if (id != issueStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueStatusExists(issueStatus.Id))
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
            return View(issueStatus);
        }

        // GET: IssueStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueStatus = await _context.IssueStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueStatus == null)
            {
                return NotFound();
            }

            return View(issueStatus);
        }

        // POST: IssueStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issueStatus = await _context.IssueStatus.FindAsync(id);
            _context.IssueStatus.Remove(issueStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueStatusExists(int id)
        {
            return _context.IssueStatus.Any(e => e.Id == id);
        }
    }
}
