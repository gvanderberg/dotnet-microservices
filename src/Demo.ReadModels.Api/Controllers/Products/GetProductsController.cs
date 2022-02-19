using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.ReadModels.Api.Controllers.Products
{
    public class GetProductsController : AbstractController
    {
        private readonly ILogger<GetProductsController> _logger;

        public GetProductsController(ILogger<GetProductsController> logger)
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