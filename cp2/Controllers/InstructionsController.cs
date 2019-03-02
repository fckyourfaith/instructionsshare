using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cp2.Data;
using cp2.Models.BusinessModels;

namespace cp2.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageLink,Theme,UserId")] Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instruction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instruction);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions.SingleOrDefaultAsync(m => m.Id == id);
            if (instruction == null)
            {
                return NotFound();
            }
            return View(instruction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageLink,Theme,UserId")] Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructionExists(instruction.Id))
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
            return View(instruction);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instructions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instruction = await _context.Instructions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Instructions.Remove(instruction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructionExists(int id)
        {
            return _context.Instructions.Any(e => e.Id == id);
        }
    }
}
