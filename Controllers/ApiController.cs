using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using musicsearch.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using musicsearch.Models;
using musicsearch.DBinterface;

namespace musicsearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly ICosmosDbService _cosmosDbService;


        public ApiController(ILogger<ApiController> logger, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }

        [HttpGet]
        [Route("songs")]
        public async Task<string> Get(string q)
        {
            return await GeniusDataModel.GetAllDataAsStrincAsync(q);
        }

        //POST Api/logger for logging user searches into CosmosDB
       [HttpPost]
       [Route("logger")]
        public async Task Create([FromBody] DBmodel item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsync(item);
        }

        //POST test-endpoint for frontend testing
        [HttpPost]
        [Route("loggertest")]
        public async Task<string> Test([FromBody] DBmodel item)
        {
            return String.Format("Post request body data: {0}, {1}, {2}, {3} ", item.Artist, item.Song, item.Latitude, item.Longitude);
        }
    }
}