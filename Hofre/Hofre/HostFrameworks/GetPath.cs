using Frameworks;
using Microsoft.AspNetCore.Hosting;

namespace Hofre.HostFrameworks
{
    public class GetPath : IGetPath
    {
        private readonly IWebHostEnvironment _env;

        public GetPath(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string Path()
        {
            return _env.WebRootPath;
        }
    }
}
