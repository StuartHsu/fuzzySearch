using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Week5.Models;
using Week5.Service;

namespace Week5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IFuzzySearchService _fuzzySearchService;

    public HomeController(ILogger<HomeController> logger,
    IFuzzySearchService fuzzySearchService
    )
    {
        this._logger = logger;
        this._fuzzySearchService = fuzzySearchService;
    }

    public IActionResult Index()
    {
        var result = this._fuzzySearchService.GetWordList();
        ViewData["List"] = result;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
