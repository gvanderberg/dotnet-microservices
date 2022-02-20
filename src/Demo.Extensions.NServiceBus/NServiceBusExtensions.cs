using Microsoft.Extensions.DependencyInjection;

using NServiceBus;

namespace Demo.Extensions.NServiceBus
{
    public static class NServiceBusExtensions
    {
        public static void AddNServiceBus(this IServiceCollection services, string endpointName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);

            endpointConfiguration.EnableInstallers();

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=localhost");

            transport.UseConventionalRoutingTopology();

            endpointConfiguration.UseContainer<ServicesBuilder>(customizations: customizations => { customizations.ExistingServices(services); });

            var routing = transport.Routing();

            DoCustomRouting(routing);

            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

            services.AddSingleton(sp => endpoint);
        }

        private static void DoCustomRouting(RoutingSettings<RabbitMQTransport> routing)
        {
            //routing.RouteToEndpoint(typeof(PlaceOrder), "MicroservicesMessagingDemo.Sales");
        }
    }
}