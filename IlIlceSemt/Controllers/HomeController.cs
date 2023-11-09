using IlIlceSemt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IlIlceSemt.Controllers
{

    public class City
    {


        public int Id { get; set; }
        public string Name { get; set; }

    }


    public class District
    {


        public int Id { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; }


    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCities()
        {

            List<City> cities = new List<City>() {

            new City(){ Id=1, Name="İstanbul" },
            new City(){ Id=2, Name="Ankara" },
            new City(){ Id=3, Name="İzmir" },
            new City(){ Id=4, Name="Antalya" }


            };

            return Json(cities);

        }
        [HttpPost]
        public JsonResult GetDistrict(int? cityid)
        {

            List<District> district = new List<District>() {

            new District(){ Id=1,CityId=1,Name="Zeytinburnu" },
            new District(){ Id=2,CityId=1,Name="Esenler" },
            new District(){ Id=3,CityId=1, Name="Bağcılar" },
            new District(){ Id=4,CityId=2, Name="Bala" },
            new District(){ Id=5,CityId=2, Name="Kızılay" },
            new District(){ Id=6,CityId=3, Name="Alsancak" },
            new District(){ Id=7,CityId=4, Name="Kepez" },
            new District(){ Id=8,CityId=4, Name="Finike" },
            new District(){ Id=9,CityId=4, Name="Kaş" },

            };

            return Json(district.Where(s=>s.CityId==cityid).ToList());

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
}