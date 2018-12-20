using Microsoft.AspNetCore.Http;

namespace Submitotron.Core
{
    public class HomeworkFile
    {
        public IFormFile FormFile {get; set;}
        public string FullPath {get; set;}
    }
}