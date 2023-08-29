# ChatDemoMVC
This is just example and demo code I have thrown together to test the ChatGPT and use it in an .Net 7.0 application.

## Getting Started
This package is run as locally debugged web application. Not effort has been made to make this a production deployable product.

### Dependencies
Newtonsoft.Json 13.0.3  
RestSharp 110.2.0  

### Setup
Update the appsettings.json file with your ChatGPT api key.  
Update the model to be used by the request. ** This will be implemented in a later version. **  
"Appsettings": {  
	"GptAPIKey": "sk-XXXXXXXXXXX",  
	"Model": "text-davinci-003"  
