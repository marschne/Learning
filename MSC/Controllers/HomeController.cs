using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MSC.Models;
using System.Data.SqlClient;

namespace MSC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public List<User> Personen = new(); 

    public HomeController(ILogger<HomeController> logger,
        IConfiguration configuration)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public IActionResult Index()
    {
        dynamic model = new ExpandoObject();
        model.Parameter = new RequestParam()
        {
            Vorname = this.Request.Query["vn"].ToString(),
            Nachname = this.Request.Query["nn"].ToString()
        };
        model.User = new User()
        {
            Username = _configuration.GetValue<string>("username"),
            Password = _configuration.GetValue<string>("pwd")
        };
        //string connectionString = _configuration.GetConnectionString("SqlServer");

        //GetUser(connectionString);
        model.Personen = this.Personen;
        return View(model);
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

    public void GetUser(string connectionString)
    {
        //string connectionString = _configuration.GetConnectionString("SqlServer");
        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    string query = "SELECT top 5 * FROM Adressen";
        //    using (SqlCommand command = new SqlCommand(query, connection))
        //    {
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                this.Personen.Add(new User
        //                {
        //                    Anrede = (string)reader["Anrede"],
        //                    Vorname = (string)reader["Vorname"],
        //                    Nachname = (string)reader["Nachname"]
        //            });
        //            }
        //        }
        //    }
        //    connection.Close();
        //}
    }
}

