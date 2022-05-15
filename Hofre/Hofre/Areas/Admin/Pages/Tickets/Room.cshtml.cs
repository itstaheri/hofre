using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;

namespace Hofre.Areas.Admin.Pages.Tickets
{
    public class RoomModel : PageModel
    {
        private readonly ITicketApplication _repository;
        public List<Messages> Messages { get; set; }
        [BindProperty] public TicketViewModel Ticket { get; set; }
        public RoomModel(ITicketApplication repository)
        {
            _repository = repository;
        }
        public async Task OnGet(long Id)
        {
            Messages = await _repository.GetMessages(Id);
            Ticket = await _repository.GetBy(Id);
        }
    }
}
