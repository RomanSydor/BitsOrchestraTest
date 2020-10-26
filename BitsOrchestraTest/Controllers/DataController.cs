using BitsOrchestraTest.Models;
using BitsOrchestraTest.Service;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace BitsOrchestraTest.Controllers
{
    public class DataController : Controller
    {
        private IDataReceiver _receiverCSV;

        public DataController(IDataReceiver receiverCSV)
        {
            _receiverCSV = receiverCSV;
        }

        public IActionResult Parse()// TODO input string path 
        {
            var sr = new StreamReader("C:\\C#\\ASP.NET Core\\BitsOrchestraTest\\Users.csv");
            var csvLine = sr.ReadToEnd();
            UsersList.Users.Clear();
            UsersList.Users = _receiverCSV.ParseToUsers(csvLine).ToList();
            if (UsersList.Users == null)
            {
                return RedirectToPage("/Error.cshtml");
            }

            return RedirectToAction("Index", "Data");
        }

        public IActionResult Index()
        {
            return View(UsersList.Users);
        }
    }
}
