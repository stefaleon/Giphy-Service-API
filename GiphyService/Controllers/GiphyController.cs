using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiphyService.Controllers
{
    [Produces("application/json")]
    [Route("api/Giphy")]
    public class GiphyController : Controller
    {
    }
}