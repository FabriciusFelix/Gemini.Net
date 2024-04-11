namespace Gemini.Net.Models
{

    public class GeminiPrompt
    {
        public GeminiPrompt(int id, string prompt)
        {
            Id = id;
            Prompt = prompt;
        }
        public GeminiPrompt()
        {
             
        }

        public int? Id { get; set; }


        public string Prompt { get; set; }
        public string? Response { get; set; }
    }

}
