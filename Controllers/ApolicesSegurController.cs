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
    public class ApolicesSegurController : Controller
    {
        private readonly SAPCSContext _context;

        public ApolicesSegurController(SAPCSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getApolicesSegur()
        {
            return new JsonResult(new { 
                data = _context.ApolicesSegur
                                .Include(c => c.Cliente)
                                .Include(c => c.Funcionario)
                                .ToList()
            });
        }

        // GET: ApolicesSegur
        public  IActionResult Index()
        {
            return View();
        }

        // GET: ApolicesSegur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoliceSegur = await _context.ApolicesSegur
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apoliceSegur == null)
            {
                return NotFound();
            }

            return View(apoliceSegur);
        }

        // GET: ApolicesSegur/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc");
            return View();
        }

        // POST: ApolicesSegur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeArquivo,ClienteId,FuncionarioId")] ApoliceSegur apoliceSegur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apoliceSegur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", apoliceSegur.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", apoliceSegur.FuncionarioId);
            return View(apoliceSegur);
        }

        // GET: ApolicesSegur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoliceSegur = await _context.ApolicesSegur.FindAsync(id);
            if (apoliceSegur == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", apoliceSegur.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", apoliceSegur.FuncionarioId);
            return View(apoliceSegur);
        }

        // POST: ApolicesSegur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeArquivo,ClienteId,FuncionarioId")] ApoliceSegur apoliceSegur)
        {
            if (id != apoliceSegur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apoliceSegur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApoliceSegurExists(apoliceSegur.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", apoliceSegur.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", apoliceSegur.FuncionarioId);
            return View(apoliceSegur);
        }

        // GET: ApolicesSegur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoliceSegur = await _context.ApolicesSegur
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apoliceSegur == null)
            {
                return NotFound();
            }

            return View(apoliceSegur);
        }

        // POST: ApolicesSegur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apoliceSegur = await _context.ApolicesSegur.FindAsync(id);
            _context.ApolicesSegur.Remove(apoliceSegur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApoliceSegurExists(int id)
        {
            return _context.ApolicesSegur.Any(e => e.Id == id);
        }
    }
}
