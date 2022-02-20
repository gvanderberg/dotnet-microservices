using System;

using NServiceBus;

namespace Demo.Events.Products
{
    public class ProductUpdatedEvent : IEvent
    {
        public Guid ProductId { get; set; }
    }
}