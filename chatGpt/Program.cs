using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = "YOUR_API_KEY"
        });
        

        while (true)
        {
            Console.Write("Question : ");
            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = Console.ReadLine(),
                Model = Models.TextDavinciV3,
                MaxTokens = 500
            });

            if (completionResult.Successful)
            {
                string answer = completionResult.Choices[0].Text.Remove(0,1);
                Console.WriteLine($"Answer :{answer}");
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }
                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }
        }
    }
}