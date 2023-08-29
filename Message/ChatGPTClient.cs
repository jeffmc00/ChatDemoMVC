using ChatDemoMVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Text;

namespace ChatDemoMVC.Message
{
    public class ChatGPTClient
    {
        private readonly string _apiKey;
        private readonly RestClient _client;
        private string _conversationHistory = string.Empty;

        public ChatGPTClient(string apiKey)
        {
            _apiKey = apiKey;
            // Initialize the RestClient with the ChatGPT API endpoint
            _client = new RestClient("https://api.openai.com/v1/engines/text-davinci-003/completions");
        }


        public string SendMessage(ChatRequest message)
        {


            // Check for empty input
            if (string.IsNullOrWhiteSpace(message.Prompt))
            {
                return "Sorry, Please try again!";
            }

            try
            {

                // Update the conversation history with the user's message
                _conversationHistory += $"User: {message.Prompt}\n";


                // The rest of the SendMessage method implementation...
                var request = new RestRequest("", Method.Post);
                // Set the Content-Type header
                request.AddHeader("Content-Type", "application/json");
                // Set the Authorization header with the API key
                request.AddHeader("Authorization", $"Bearer {_apiKey}");

                // Create the request body with the message and other parameters
                var requestBody = new
                {
                    prompt = message.Prompt,
                    max_tokens = 100,
                    n = 1,
                    stop = (string?)null,
                    temperature = 0.7,
                };

                // Add the JSON body to the request
                request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

                // Execute the request and receive the response
                var response = _client.Execute(request);

                // Deserialize the response JSON content
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content ?? string.Empty);


                // Extract and return the chatbot's response text
                string chatbotResponse = jsonResponse?.choices[0]?.text?.ToString()?.Trim() ?? string.Empty;

                // Update the conversation history with the chatbot's response
                _conversationHistory += $"Chatbot: {chatbotResponse}\n";


               
                return chatbotResponse;

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the API request
                Console.WriteLine($"Error: {ex.Message}");
                return "Sorry, there was an error processing your request. Please try again later.";
            }


        }


    }
}
