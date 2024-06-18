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

    public async Task<IActionResult> ShowDetails(int id)
    {
        var mentor = await _dbContext.Mentores.FirstOrDefaultAsync(m => m.MentorId == id);

        if (mentor != null)
        {
            return View(mentor);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var mentor = await _dbContext.Mentores.FirstOrDefaultAsync(m => m.MentorId == id);
        if (mentor != null)
        {
            return View(mentor);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Mentor mentorEditado)
    {
        if (!await _dbContext.Mentores.AnyAsync(m => m.MentorId == mentorEditado.MentorId))
        {
            return NotFound();
        }
        mentorEditado.DataNascimento = DateTime.SpecifyKind(mentorEditado.DataNascimento, DateTimeKind.Utc);
        if (!ModelState.IsValid)
        {
            return View(mentorEditado);
        }
        try
        {
            _dbContext.Update(mentorEditado);
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _dbContext.Mentores.AnyAsync(m => m.MentorId == mentorEditado.MentorId))
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
    public async Task<bool> MentorExists(int id)
    {
        return await _dbContext.Mentores.AnyAsync(m => m.MentorId == id);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var mentor = await _dbContext.Mentores.FirstOrDefaultAsync(m => m.MentorId == id);
        if (mentor != null)
        {
            return View(mentor);
        }
        return NotFound();
    }
}