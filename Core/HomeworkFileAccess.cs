using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Submitotron.Core
{
    public class HomeworkFileAccess
    {
        private readonly IConfiguration _configuration;

        public HomeworkFileAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> TrySaveAsync(HomeworkSubmission submission)
        {
            try
            {
                await SaveAsync(submission);
                return true;
            }
            catch (Exception e)
            {
                LogError(e);
                return false;
            }
        }

        private void LogError(Exception e)
        {
            Console.Error.WriteLine(e);
        }

        private async Task SaveAsync(HomeworkSubmission submission)
        {
            var rootPath = GetSubmissionDirectory(submission);
            foreach (var file in submission.Files)
            {
                var cleanedOriginalPath = FixPathFileSeperators(file.FullPath);
                var newFilePath = Path.Combine(rootPath, cleanedOriginalPath);
                var fileParentDirectory = CreateDirectoryIfNotExists(Directory.GetParent(newFilePath).ToString());
                await SaveFile(file, newFilePath);
            }
        }

        private async Task SaveFile(HomeworkFile file, string path)
        {
            var readStream = file.FormFile.OpenReadStream();
            var writeStream = new FileStream(path, FileMode.Create);
            await readStream.CopyToAsync(writeStream);
            writeStream.Close();
            readStream.Close();
            readStream.Dispose();
            writeStream.Dispose();
        }

        private string CreateDirectoryIfNotExists(string path)
        {
            var isFolderExists = Directory.Exists(path);
            if (!isFolderExists)
                Directory.CreateDirectory(path);
            return path;
        }

        private string FixPathFileSeperators(string path)
        {
            return path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }

        private string GetRepoRootPath()
        {
            var root = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            return Path.Combine(root, "repos");
        }

        public string GetSubmissionDirectory(HomeworkSubmission submission)
        {
            var homeworkName = submission.HomeworkID;
            var rootPath = Path.Combine(GetRepoRootPath(), "homeworks", homeworkName.ToString());
            return CreateDirectoryIfNotExists(rootPath);
        }
    }
}