using System;
using System.Threading.Tasks;

using Demo.Events.Products;

using Microsoft.Extensions.Logging;

using NServiceBus;

namespace Demo.ReadModels.Api.Integrations.EventHandlers
{
    public class ProductUpdatedEventHandler : IHandleMessages<ProductUpdatedEvent>
    {
        private readonly ILogger<ProductUpdatedEventHandler> _logger;

        public ProductUpdatedEventHandler(ILogger<ProductUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductUpdatedEvent message, IMessageHandlerContext context)
        {
            _logger.LogInformation("Handle ProductUpdatedEvent");

            throw new NotImplementedException();
        }
    }
}