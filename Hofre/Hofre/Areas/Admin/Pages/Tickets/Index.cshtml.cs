using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;

namespace Hofre.Areas.Admin.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly ITicketApplication _repository;
        public List<TicketViewModel> Tickets { get; set; }
        public TicketViewModel ticket { get; set; }
        public IndexModel(ITicketApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            Tickets = await _repository.GetAll();

        }
        public async Task<RedirectToPageResult> OnPostClose(long Id)
        {
            await _repository.CloseTicket(Id);
            return RedirectToPage();
        }
        public async Task<RedirectToPageResult> OnPostOpen(long Id)
        {
            await _repository.OpenTicket(Id);
            return RedirectToPage();
        }

    }
}
