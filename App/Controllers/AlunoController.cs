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

    public async Task<IActionResult> Edit(int id)
    {
        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);

        if(aluno != null)
            return View(aluno);
        return NotFound();
    }
}
