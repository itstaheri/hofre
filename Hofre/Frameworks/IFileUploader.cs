using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    public interface IFileUploader
    {
        string SingleUploader(IFormFile file,string part, string folder);
        List<string> CourseUploader(List<IFormFile> files, string folder);
    }
}
