using asp_party_invitation.Models;
using asp_party_invitation.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace asp_party_invitation.Controllers
{
    public class HomeController : Controller
    {
        private readonly RSVPResponseRepo _repo;
        public HomeController(RSVPResponseRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThanksForAttention()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(RSVPResponse response)
        {
            if(ModelState.IsValid)
            {
                await _repo.AddAsync(response);
                return RedirectToAction("ThanksForAttention", "Home");
            }
            return View(response);
        }

        public async Task<IActionResult> ResponsesAsync()
        {           
            var responses = await _repo.GetAllAsync();         
            return View(responses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
