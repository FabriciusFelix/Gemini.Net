using Gemini.Net.Models;
using GeminiCSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Gemini.Net.Controllers
{
    public class GeminiController : Controller
    {
        private readonly IConfiguration _configuration;
        public GeminiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: GeminiController
        public IActionResult Index(GeminiPrompt prompt)
        {
            var menu = "Faça sua pergunta para o Gemini: ";
            ViewBag.Menu = menu;
            return View(prompt); 
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostPrompt([Bind("Id,Prompt")]GeminiPrompt form)
        {
            try
            {
                var apiKey = _configuration.GetValue<string>("API_KEY");
                var geminiChat = new GeminiChat(apiKey);

                 
               
                using var httpClient = new HttpClient();


                var response = await geminiChat.SendMessageAsync(form.Prompt, httpClient);
                if (response is not null)
                {
                    form.Response = response;
                    return View("Index",form);
                }
                Console.WriteLine($"[Gemini]: {form}");
                geminiChat.ResetToNewChat();
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

         
    }
}
