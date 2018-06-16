using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Submitotron.Core
{
    public class HomeworkFileAccess
    {

        private readonly IHomeworkRepo _homeworkRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly IConfiguration _configuration;

        public HomeworkFileAccess(IStudentRepo studentRepo, IHomeworkRepo homeworkRepo, IConfiguration configuration)
        {
            _studentRepo = studentRepo;
            _homeworkRepo = homeworkRepo;
            _configuration = configuration;
        }
        public async Task<bool> TrySaveAsync(HomeworkSubmission submission)
        {
            try
            {
                var rootPath = GetSubmissionPath(submission);

                var isFolderExists = Directory.Exists(rootPath);
                if (!isFolderExists)
                    System.IO.Directory.CreateDirectory(rootPath);
                foreach (var file in submission.Files)
                {
                    var cleanedOriginalPath = file.FullPath.Replace( Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                    var newFilePath = Path.Combine(rootPath, cleanedOriginalPath);
                    var fileParentDirectory = Directory.GetParent(newFilePath).ToString();
                    var UploadPathExists = Directory.Exists(fileParentDirectory);
                    if (!UploadPathExists)
                        Directory.CreateDirectory(fileParentDirectory);
                    var readStream = file.FormFile.OpenReadStream();
                    var writeStream = new FileStream(newFilePath, FileMode.Create);
                    await readStream.CopyToAsync(writeStream);
                    writeStream.Close();
                    readStream.Close();
                    readStream.Dispose();
                    writeStream.Dispose();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetSubmissionPath(HomeworkSubmission submission)
        {
            var homeworkName = Guid.NewGuid();
            var rootPath = Path.Combine("repos", "homeworks", homeworkName.ToString());
            return rootPath;
        }
    }
}