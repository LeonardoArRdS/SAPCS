using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAPCS.Data;
using SAPCS.Models;

namespace SAPCS.Controllers
{
    public class SeguradorasController : Controller
    {
        private readonly SAPCSContext _context;

        public SeguradorasController(SAPCSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getSeguradoras()
        {
            return new JsonResult(new { data = _context.Seguradoras.ToList() });
        }

        // GET: Seguradoras
        public IActionResult Index()
        {
            return View();
        }

        // GET: Seguradoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seguradora == null)
            {
                return NotFound();
            }

            return View(seguradora);
        }

        // GET: Seguradoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seguradoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeSegur,EndSegur,TelSegur,SiteSegur,NomeContSegur,EmailContSegur,StatusSegur")] Seguradora seguradora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguradora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seguradora);
        }

        // GET: Seguradoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradoras.FindAsync(id);
            if (seguradora == null)
            {
                return NotFound();
            }
            return View(seguradora);
        }

        // POST: Seguradoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeSegur,EndSegur,TelSegur,SiteSegur,NomeContSegur,EmailContSegur,StatusSegur")] Seguradora seguradora)
        {
            if (id != seguradora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguradora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguradoraExists(seguradora.Id))
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
            return View(seguradora);
        }

        // GET: Seguradoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seguradora == null)
            {
                return NotFound();
            }

            return View(seguradora);
        }

        // POST: Seguradoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguradora = await _context.Seguradoras.FindAsync(id);
            seguradora.StatusSegur = false;
            _context.Seguradoras.Update(seguradora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeguradoraExists(int id)
        {
            return _context.Seguradoras.Any(e => e.Id == id);
        }
    }
}
