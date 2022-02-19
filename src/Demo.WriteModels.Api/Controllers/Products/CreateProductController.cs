using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.WriteModels.Api.Controllers.Products
{
    public class CreateProductController : AbstractController
    {
        private readonly ILogger<CreateProductController> _logger;

        public CreateProductController(ILogger<CreateProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            return Created("", await Task.FromResult(1).ConfigureAwait(false));
        }
    }
}