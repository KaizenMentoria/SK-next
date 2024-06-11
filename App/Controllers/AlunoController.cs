using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class AlunoController : Controller
{
    private readonly ILogger<AlunoController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public AlunoController(ILogger<AlunoController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()//ListAll
    {
        return View(await _dbContext.Alunos.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Aluno novoAluno)
    {
        novoAluno.DataNascimento = DateTime.SpecifyKind(novoAluno.DataNascimento, DateTimeKind.Utc);

        if (!ModelState.IsValid)
        {
            return View(novoAluno);
        }

        _dbContext.Add(novoAluno);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ShowDetails(int id)
    {
        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);

        if (aluno != null)
        {
            return View(aluno);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);

        if (aluno != null)
            return View(aluno);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Aluno alunoChanges)
    {
        if (!await AlunoExists(alunoChanges.AlunoId))
        {
            return NotFound();
        }
        alunoChanges.DataNascimento = DateTime.SpecifyKind(alunoChanges.DataNascimento, DateTimeKind.Utc);
        if (!ModelState.IsValid)
        {
            return View(alunoChanges);
        }
        try
        {
            _dbContext.Update(alunoChanges);
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await AlunoExists(alunoChanges.AlunoId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction("Index");
    }

    private async Task<bool> AlunoExists(int id)
    {
        return await _dbContext.Alunos.AnyAsync(a => a.AlunoId == id);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(m => m.AlunoId == id);
        if (aluno == null)
        {
            return NotFound();
        }

        return View(aluno);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var aluno = await _dbContext.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }
        _dbContext.Alunos.Remove(aluno);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
