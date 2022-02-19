using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.WriteModels.Api.Controllers.Products
{
    public class UpdateProductController : AbstractController
    {
        private readonly ILogger<UpdateProductController> _logger;

        public UpdateProductController(ILogger<UpdateProductController> logger)
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