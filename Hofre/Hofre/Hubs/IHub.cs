using System.Threading.Tasks;

namespace Hofre.Hubs
{
    public interface IHub
    {
        Task SendMessage(string message);
    }
}
