using Microsoft.AspNetCore.Mvc;
using WebApp.Attributes;

using Services;
using Api;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/test")]
    [ApiKey]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IDbService _service; // DB access
        private readonly IApiService _apiService; // webhook

        public TestController(ILogger<TestController> logger, IDbService service, IApiService apiService)
        {
            _logger = logger;
            _service = service; 
            _apiService = apiService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Users()
        {
            //TODO: use _service to DB access  
            await _apiService.SendUser();
            return Ok(true);
        }

        [HttpGet("posts")]
        public async Task<IActionResult> Posts()
        {
            //TODO: use _service to DB access 
            await _apiService.SendPost();
            return Ok(true);
        }

        [HttpGet("comments")]
        public async Task<IActionResult> Comments()
        {
            //TODO: use _service to DB access 
            await _apiService.SendComment();
            return Ok(true);
        }

    }
}