using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

[ApiController]
[Route("concierge")]
public class OpenAIController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public OpenAIController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    [HttpPost("generateChatCompletion")]
    public async Task<IActionResult> GenerateChatCompletion([FromBody] ChatRequest request)
    {
        var apiKey = _configuration["OpenAI:ApiKey"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", new
        {
            //model = "text-davinci-002",
            model = "gpt-3.5-turbo-0125",
            messages = new[]
            {
                new { role = "user", content = request.Prompt }
            }
        });

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        var result = await response.Content.ReadFromJsonAsync<ChatResponse>();
        return Ok(result);
    }
}

public class ChatRequest
{
    public string Prompt { get; set; }
}

public class ChatResponse
{
    public Choice[] Choices { get; set; }
}

public class Choice
{
    public Message Message { get; set; }
}

public class Message
{
    public string Content { get; set; }
}

