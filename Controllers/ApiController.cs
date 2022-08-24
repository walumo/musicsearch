using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using musicsearch.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using musicsearch.Models;

namespace musicsearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("genius")]
        public async Task<string> GetGeniusData()
        {
            //var data = await api.GetGeniusAsync();
            var data = await GeniusDataModel.setNewObj();
            return data;
        }
        
    }
}
