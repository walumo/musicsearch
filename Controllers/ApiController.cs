﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using musicsearch.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("spotify")]
        public async Task<string> Get()
        {
            var data = await api.GetSpotifyAsync("https://api.spotify.com/v1/search?q=thriller&type=track");
            return data;
        }
    }
}
