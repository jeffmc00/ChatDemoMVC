using ChatDemoMVC.Message;
using ChatDemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatDemoMVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

     
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult ChatWithMe()
        {
           
            return View();
        }


        [HttpPost]
        public string SendChatMessage(ChatRequest message)
        {
           
            string response = "responding... ";
            // ChatGPT API key
            var apiKey = _configuration.GetSection("Appsettings:GptAPIKey").Value;
            // check if we set our apiKey
            if (string.IsNullOrEmpty(apiKey)) {             
                  return "Missing API Key";
                }
            // Create a ChatGPTClient instance with the API key
            var chatGPTClient = new ChatGPTClient(apiKey);

            try
            {
                if (!string.IsNullOrEmpty(message.Prompt))
                {
                    //send our message object to the chat client and receive a response as a string
                   response = chatGPTClient.SendMessage(message);
                } else { response += " Promt Message Is Null"; }
               
            } catch (Exception ex) {
                return ex.Message.ToString();
            }

            return response;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}