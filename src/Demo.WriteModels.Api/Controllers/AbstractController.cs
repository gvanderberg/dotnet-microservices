using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WriteModels.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbstractController : ControllerBase
    {

    }
}