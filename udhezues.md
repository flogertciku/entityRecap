<!-- TODO 1) Krijoni aplikacionin -->
dotnet new mvc --no-https -o EmriProjektit

<!-- TODO 2)  Vetem heren e pare instaloni EF -->
dotnet tool install --global dotnet-ef --version 6.0.3
<!-- TODO 3) Opsionale per cdo projekt checkoni nese keni dotnet EF  -->
dotnet ef

<!-- TODO 4) Beni instalimet e paketave per cdo projekt -->
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3

<!--5 TODO) Krijoni Modelin / Modelet sipas struktures me poshte -->
<!--  tek file Models/User.cs -->
<!-- Fillimi Modelit -->

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EMRIPROJEKTITTEND.Models;   
public class User
{
    [Key]
    public int UserId { get; set; }
    public string Name { get; set; } 
    public int Height { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
<!-- Fundi Modelit -->

<!--TODO 6) Krijoni MyContext -->
<!-- ne filen  Models/MyContext.cs -->
<!-- Fillimi MyContext -->
#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace EMRIPROJEKTITTEND.Models;

public class MyContext : DbContext 
{   

    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> Users { get; set; } 
}

<!-- Fundi MyContenxt -->

<!-- LIDHJA ME DATABAZEN KONFIGURIMET -->
<!--TODO 7 Konfiguroni filen appsetings.json -->
{  
    "Logging": {    
        "LogLevel": {      
            "Default": "Information",      
            "Microsoft.AspNetCore": "Warning"    
        }  
    },
    "AllowedHosts": "*",    
    "ConnectionStrings":    
    {        
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=root;database=emriProjektitdb;"    
    }
}
<!--TODO 8) shtoni configurimet tek Program.cs -->
<!--! Perpara rrjeshtit 1 -->
using Microsoft.EntityFrameworkCore;
using EMRIPROJEKTIT.Models;
<!--! Direkt pas var builder = WebApplication.CreateBuilder(args); -->
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

<!-- TODO 9) beni migrimet e modelit per databazen -->
dotnet ef migrations add migrimiNje
<!-- ?  pas cdo ndryshimi qe do beni tek models/user.cs ose modelet e tjera do shtoni nje migrim te ri si psh migrimiDy etj etj -->
<!-- TODO 10) beni update databasen -->
dotnet ef database update

<!--? CONTROLLERS -->
<!-- TODO 11) shtoni rrjeshtat tek Controllers/HomeController.cs -->
<!--! perpara namespace  -->
using entityRecap.Models;
<!-- ! poshte private readonly ILogger<HomeController> _logger;  -->
 private MyContext _context; 
 <!-- zevendesoni constructer   
 public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
-->
<!-- me rrjeshtat me poshte -->
 public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    } 







