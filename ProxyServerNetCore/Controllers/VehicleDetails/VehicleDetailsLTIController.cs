using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProxyServerNetCore.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProxyServerNetCore.Controllers.VehicleDetails
{
    [ApiController]
    public class VehicleDetailsLTIController : ControllerBase
    {
        private readonly ILogger<VehicleDetailsLTIController> _logger;

        public VehicleDetailsLTIController(ILogger<VehicleDetailsLTIController> logger)
        {
            _logger = logger;
        }

        [HttpPost("api/DaVinci/vehicledetails/lti/summary")]
        public async Task<LTISummary> GetSummary([FromBody] GetLTISummaryRequest request)
        {
            var url = "http://localhost:54309/api/vehicledetails/lti/summary";
            string magCookie = HttpContext.Request.Cookies["magAuthenticationCookie"];

            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new System.Uri(url),
                    Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"),                    
                };

                req.Headers.Add("Cookie", String.Format("magAuthenticationCookie={0}", magCookie));

                HttpResponseMessage result = await client.SendAsync(req);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }

            return new LTISummary();
        }
    }
}
