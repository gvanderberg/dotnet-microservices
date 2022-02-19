using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.ReadModels.Api.Controllers.Products
{
    public class GetProductController : AbstractController
    {
        private readonly ILogger<GetProductController> _logger;

        public GetProductController(ILogger<GetProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await Task.FromResult(1).ConfigureAwait(false));
        }
    }
}