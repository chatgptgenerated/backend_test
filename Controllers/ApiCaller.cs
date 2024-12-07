using Microsoft.AspNetCore.Mvc;

namespace backend_test.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExternalApiController : ControllerBase
    {
        private readonly HttpClient client;

        // TODO add connection to api (localhost atm)
        public ExternalApiController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Accept.Clear();
        }

        [HttpGet(Name = "GetCall")]
        public async Task<IActionResult> Get()
        {
            var response = client.GetAsync("/");
            var content = await response;

            if (response.IsCompletedSuccessfully){
                
                return Ok(content.Content.ReadAsStringAsync().Result);
            } else {
                return StatusCode((int)content.StatusCode, "Error: Unable to fetch data from the external API.");
            }
            // TODO code goes here
            // return "test_net";
        }
    }
}
