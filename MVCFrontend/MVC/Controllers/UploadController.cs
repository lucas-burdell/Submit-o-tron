using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Submitotron.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Submitotron.MVC.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        public UploadController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> file, List<string> fullPath)
        {
            return View("UploadComplete");
        }               

        [HttpGet]
        public IActionResult UploadComplete()
        {
            return View("UploadComplete");
        }
    }
}