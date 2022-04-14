using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class ClassificacaosController : Controller
    {
        private readonly Contexto _context;

        public ClassificacaosController(Contexto context)
        {
            _context = context;
        }

        // GET: Classificacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classificacaos.ToListAsync());
        }

        // GET: Classificacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // GET: Classificacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classificacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificacao);
        }

        // GET: Classificacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacaos.FindAsync(id);
            if (classificacao == null)
            {
                return NotFound();
            }
            return View(classificacao);
        }

        // POST: Classificacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Classificacao classificacao)
        {
            if (id != classificacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificacaoExists(classificacao.Id))
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
            return View(classificacao);
        }

        // GET: Classificacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // POST: Classificacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificacao = await _context.Classificacaos.FindAsync(id);
            _context.Classificacaos.Remove(classificacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificacaoExists(int id)
        {
            return _context.Classificacaos.Any(e => e.Id == id);
        }
    }
}
