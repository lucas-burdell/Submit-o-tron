using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Submitotron.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Submitotron.MVC.Controllers
{
    [Route("upload/")]
    public class UploadController : Controller
    {
        private readonly HomeworkFileAccess _fileAccess;

        public UploadController(HomeworkFileAccess fileAccess)
        {
            _fileAccess = fileAccess;
        }

         [HttpPost("")]
        public async Task<IActionResult> Upload(List<IFormFile> file, List<string> fullPath)
        {

            var submission = new HomeworkSubmission();
            submission.StudentID = Guid.NewGuid().ToString();
            submission.HomeworkID = Guid.NewGuid().ToString();
            for (var i = 0; i < file.Count; i++) 
            {
                var homeworkFile = new HomeworkFile();
                homeworkFile.FullPath = fullPath[i];
                homeworkFile.FormFile = file[i];
                submission.Files.Add(homeworkFile);
            }
            Console.WriteLine($"SAVING {file.Count} FILES");
            await _fileAccess.TrySaveAsync(submission);
            return RedirectToAction("Index", "Home");
        }               

        [HttpGet("/UploadComplete")]
        public IActionResult UploadComplete()
        {
            return View("UploadComplete");
        }
    }
}