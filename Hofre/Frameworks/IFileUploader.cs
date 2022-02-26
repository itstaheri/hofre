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
        string ArticleUploader(IFormFile file, string folder);
    }
}
