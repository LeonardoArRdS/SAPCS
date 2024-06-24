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
    public class CotacoesController : Controller
    {
        private readonly SAPCSContext _context;

        public CotacoesController(SAPCSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getCotacoes()
        {
            return new JsonResult(new { 
                data = _context.Cotacoes
                                .Where(cot => cot.StatusCot != EnumStatusCot.CANCELADO)
                                .Include(c => c.Cliente)
                                .Include(c => c.Funcionario)
                                .Include(c => c.Servico)
                                .ToList()
            });
        }

        // GET: Cotacaos
        public IActionResult Index()
        {
            return View();
        }

        // GET: Cotacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotacao == null)
            {
                return NotFound();
            }

            return View(cotacao);
        }

        // GET: Cotacaos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc");
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "NomeServ");
            return View();
        }

        // POST: Cotacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,FuncionarioId,ServicoId,StatusCot")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                cotacao.DtCriacao = DateTime.Now;
                cotacao.DtModificacao = DateTime.Now;

                _context.Add(cotacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", cotacao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", cotacao.FuncionarioId);
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "NomeServ", cotacao.ServicoId);
            return View(cotacao);
        }

        // GET: Cotacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes.FindAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", cotacao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", cotacao.FuncionarioId);
            ViewData["FuncionarioId"] = new SelectList(_context.Servicos, "Id", "NomeServ", cotacao.ServicoId);
            return View(cotacao);
        }

        // POST: Cotacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,FuncionarioId,ServicoId,StatusCot")] Cotacao cotacao)
        {
            if (id != cotacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cotacao.DtModificacao = DateTime.Now;

                    _context.Update(cotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotacaoExists(cotacao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCli", cotacao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "NomeFunc", cotacao.FuncionarioId);
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "NomeServ", cotacao.ServicoId);
            return View(cotacao);
        }

        // GET: Cotacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotacao == null)
            {
                return NotFound();
            }

            return View(cotacao);
        }

        // POST: Cotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotacao = await _context.Cotacoes.FindAsync(id);
            cotacao.StatusCot = EnumStatusCot.CANCELADO;
            _context.Cotacoes.Update(cotacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotacaoExists(int id)
        {
            return _context.Cotacoes.Any(e => e.Id == id);
        }
    }
}
