using Frameworks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.HostFrameworks
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _env;

        public FileUploader(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SingleUploader(IFormFile file, string part, string folder)
        {
            if (file == null) return null;

            var filepath = $"{_env.WebRootPath}//Media//{part}//{folder}";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            var filename = DateTime.Now.ToFileName() + "-" + file.FileName;
            var pathfile = $"{filepath}//{filename}";
            using (var stram = File.Create(pathfile))
            {
                file.CopyTo(stram);
            }
            return filename;
        }

        public List<string> CourseUploader(List<IFormFile> files, string folder)
        {
            List<string> filename = new List<string>();
            if (files == null) return null;

            var filepath = $"{_env.WebRootPath}//Media//Course//{folder}";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            foreach (var file in files)
            {
                filename.Add($"video {file.FileName}");
                var pathfile = $"{filepath}//{filename}";
                using (var stram = File.Create(pathfile))
                {
                    file.CopyTo(stram);
                }

            }

            return filename;
        }
    }
}
