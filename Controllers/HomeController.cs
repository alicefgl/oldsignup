using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using foglietta.alice._5i.ProvaDb.Models;

namespace foglietta.alice._5i.ProvaDb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Prenotazione> Prenotazioni;
    private List<Prodotto> Prodotti;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        Prenotazioni = new List<Prenotazione>();
        Prodotti = new List<Prodotto>();
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("NomeUtente", "Alice Foglietta");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(Prenotazione u)
    {
        return View(u);
    }

    [HttpPost]
    public ActionResult Conferma(Prenotazione p)
    {
        dbContext db = new dbContext();
        db.Prenotazioni.Add( p );
        db.SaveChanges();
        return View(db);
    }

    [HttpGet]
    public IActionResult Purchase()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cart(Prodotto prod)
    {
        dbContext db = new dbContext();
        db.Prodotti.Add( prod );
        db.SaveChanges();
        return View(db);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
