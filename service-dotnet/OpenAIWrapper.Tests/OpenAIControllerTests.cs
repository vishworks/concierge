using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OpenAIWrapper.Tests
{
    public class OpenAIControllerTests
    {
        private readonly HttpClient _httpClient;

        public OpenAIControllerTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:9080"); // Assuming the application is running locally
        }

        [Fact]
        public async Task GenerateChatCompletion_ReturnsChatCompletionResponse()
        {
            // Arrange
            var prompt = new { prompt = "Can you suggest a message I can send to my customer who needs a botox appointment?" };
            var content = new StringContent(JsonSerializer.Serialize(prompt), System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("/concierge/generateChatCompletion", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var chatResponse = JsonSerializer.Deserialize<ChatResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.NotNull(chatResponse);
            Assert.NotEmpty(chatResponse.Choices);
            Assert.NotEmpty(chatResponse.Choices[0].Message.Content);
        }
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
}

