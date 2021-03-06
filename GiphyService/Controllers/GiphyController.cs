﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giphy.Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiphyService.Controllers
{
    
    public class GiphyController : Controller
    {
        private readonly IGiphyService _giphyService;

        public GiphyController(IGiphyService giphyService)
        {
            _giphyService = giphyService;                
        }

        [HttpGet]
        [Route("random/{searchCriteria}")]
        public async Task<IActionResult> GetRandomGif(string searchCriteria)
        {
            var result = await _giphyService.GetRandomGifBasedOnSearchCriteria(searchCriteria);

            return Ok(result);
        }
    }
}