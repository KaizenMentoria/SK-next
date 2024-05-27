using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers;

public class AlunoController : Controller
{
    private readonly ILogger<AlunoController> _logger;

    public AlunoController(ILogger<AlunoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
}
