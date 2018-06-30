using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Submitotron.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Submitotron.MVC.Controllers
{
    public class UploadController : Controller
    {
        private readonly HomeworkFileAccess _fileAccess;

        public UploadController(HomeworkFileAccess fileAccess)
        {
            _fileAccess = fileAccess;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> file, List<string> fullPath)
        {
            var submission = new HomeworkSubmission();
            submission.StudentID = "LucasBurdell";
            submission.HomeworkID = "Homework01";
            for (var i = 0; i < file.Count; i++) 
            {
                var homeworkFile = new HomeworkFile();
                homeworkFile.FullPath = fullPath[i];
                homeworkFile.FormFile = file[i];
                submission.Files.Add(homeworkFile);
            }
            await _fileAccess.TrySaveAsync(submission);
            return RedirectToAction("UploadComplete");
        }               

        [HttpGet]
        public IActionResult UploadComplete()
        {
            return View("UploadComplete");
        }
    }
}