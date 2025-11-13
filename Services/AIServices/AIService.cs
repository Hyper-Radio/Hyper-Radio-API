using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Types;

public class AIService {
    
    public static async Task main() {
        // assuming credentials are set up in environment variables as instructed above.
        var client = new Client(apiKey: "AIzaSyCtnQuH8vRUJqQFpMT9qa-7n65-iJIlp5c");
        
        var response = await client.Models.GenerateContentAsync(
            model: "gemini-2.0-flash", contents: "why is the sky blue?"
        );
        Console.WriteLine(response.Candidates[0].Content.Parts[0].Text);
    }
    
}