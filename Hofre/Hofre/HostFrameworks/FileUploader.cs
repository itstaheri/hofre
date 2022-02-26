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

        public string ArticleUploader(IFormFile file,string folder)
        {
            if (file == null) return null;

            var filepath = $"{_env.WebRootPath}//Media//Article//{folder}";
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
    }
}
