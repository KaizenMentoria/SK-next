// TODO: implementar CRUD de mentores
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class MentorController : Controller
{
    private readonly ILogger<MentorController> _logger;  
    private readonly ApplicationDbContext _dbContext;

    public MentorController(ILogger<MentorController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _dbContext.Mentores.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Mentor novoMentor)
    {
        novoMentor.DataNascimento = DateTime.SpecifyKind(novoMentor.DataNascimento, DateTimeKind.Utc);

        if (!ModelState.IsValid)
        {
            return View(novoMentor);
        }

        _dbContext.Add(novoMentor);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}