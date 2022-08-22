using Inventario.Domain.Events;
using MassTransit;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.UseCases.DomainEventHandler.Arituculo
{
    public class PublishIntegrationEventWhenArticuloCreadoHandler : INotificationHandler<ConfirmedDomainEvent<ArticuloCreado>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenArticuloCreadoHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<ArticuloCreado> notification, CancellationToken cancellationToken)
        {
            SharedKernel.IntegrationEvents.ArticuloCreado evento = new SharedKernel.IntegrationEvents.ArticuloCreado()
            {
                ArticuloId = notification.DomainEvent.ArticuloId,
                Nombre = notification.DomainEvent.Nombre,
                PrecioVenta = notification.DomainEvent.PrecioVenta
            };
            await _publishEndpoint.Publish<SharedKernel.IntegrationEvents.ArticuloCreado>(evento);


        }
    }
}
