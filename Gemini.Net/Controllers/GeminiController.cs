using Gemini.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemini.Net.Controllers
{
    public class GeminiController : Controller
    {
        // GET: GeminiController
        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult EnviaPromptPage()
        {
            return View();
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostPrompt(IFormCollection collection)
        {
            var prompt = new Gemini.Net.Models.Gemini(1,"Quem é você?");
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(EnviaPromptPage());
            }
        }

         
    }
}
