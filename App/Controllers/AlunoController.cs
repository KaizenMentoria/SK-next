using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;

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

    public IActionResult Index()
    {
        // alunos = dbcontext.Alunos
        // return view(alunos)
        var alunos = _dbContext.Alunos;
        return View(alunos);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Aluno novoAluno)
    {
        return RedirectToAction("Index", novoAluno);
    }
}
