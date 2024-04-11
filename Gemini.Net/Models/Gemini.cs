namespace Gemini.Net.Models
{

    public class Gemini
    {
        public Gemini(int id, string prompt)
        {
            Id = id;
            Prompt = prompt;
        }

        public int Id { get; set; }


        public string Prompt { get; set; }
    }

}
