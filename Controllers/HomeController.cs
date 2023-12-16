using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using entityRecap.Models;

namespace entityRecap.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context; 

   public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    } 

    public IActionResult Index()
    {
       
        ViewBag.users = _context.Users.ToList();
        return View();
    }
    [HttpGet("Register")]
    public IActionResult Register(){
        return View();
    }
    [HttpPost("Create")]
    public IActionResult Create(User useriNgaForma){
        if (ModelState.IsValid)
        {
            _context.Add(useriNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Register");
    }
    [HttpGet("Details/{itemId}")]
    public IActionResult Details(int itemId){
        User useriNgaDb = _context.Users.FirstOrDefault(e=> e.UserId ==itemId );
        return View(useriNgaDb);
    }
    [HttpGet("Delete/{itemId}")]
    public IActionResult Delete(int itemId){
        User useriNgaDb = _context.Users.FirstOrDefault(e=>e.UserId==itemId);
        _context.Remove(useriNgaDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("Ndrysho/{itemId}")]
    public IActionResult Ndrysho(int itemId){
        User userNgadb = _context.Users.FirstOrDefault(e=>e.UserId==itemId);
        return View("Ndrysho",userNgadb);
        
    }

    [HttpPost("Update/{itemId}")]
    public IActionResult Update( User useriNgaForma,int itemId){
        User useriNgaDb = _context.Users.FirstOrDefault(e=>e.UserId==itemId);
        if (ModelState.IsValid)
        {
            useriNgaDb.Name= useriNgaForma.Name;
            useriNgaDb.Height = useriNgaForma.Height;
            useriNgaDb.Description = useriNgaForma.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        
        return View("Ndrysho",useriNgaDb);

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
