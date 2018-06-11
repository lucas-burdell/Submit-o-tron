using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> file)
        {
            Console.WriteLine("GOT FILES. Number of files: " + file.Count);
            foreach (var item in file) {
                Console.WriteLine(item.FileName);
            }
            ViewBag.Message = "Upload successful!";
            ViewBag.MessageType = "text-success";   
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
