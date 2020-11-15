﻿using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroRabbit.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;

        private readonly Dictionary<string, List<Type>> _handler;

        private readonly List<Type> _eventType;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handler = new Dictionary<string, List<Type>>();
            _eventType = new List<Type>();
        }


        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Publis<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}