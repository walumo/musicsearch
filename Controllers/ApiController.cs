﻿using Microsoft.AspNetCore.Mvc;
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

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("songs")]
        public async Task<string> GetGeniusData(string q)
        {
            return await GeniusDataModel.GetAllDataAsStrincAsync(q);
        }

        private readonly ICosmosDbService _cosmosDbService;
        public ApiController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }



        // POST api/items
        //[HttpPost]
        //[Route("logger")]
        //public async Task Create([FromBody] DBmodel item)
        //{
        //    item.Id = Guid.NewGuid().ToString();
        //    await _cosmosDbService.AddAsync(item);
        //}

        [HttpPost]
        [Route("loggertest")]
        public async Task<string> Test([FromBody] DBmodel item)
        {
            //DBmodel item = new DBmodel();
            //item.Id = Guid.NewGuid().ToString();
            //item.Artist = "Test-artist";
            //item.Song = "Test-Song";
            //item.Latitude = "123";
            //item.Longitude = "456";
            //await _cosmosDbService.AddAsync(item);

            return item.Artist + item.Song;
        }


    }
}