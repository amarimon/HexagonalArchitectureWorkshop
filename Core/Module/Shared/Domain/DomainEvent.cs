using System;
using System.Collections.Generic;

namespace Core.Module.Shared.Domain
{
    public abstract class DomainEvent
    {
        protected string aggregateId { get; set; }
        protected string eventId { get; set; }
        protected long ocurredOn { get; set; }

        public DomainEvent(string aggregateId, string eventId = null, long? occurredOn = null)
        {
            this.aggregateId = aggregateId;
            this.eventId = eventId ?? Guid.NewGuid().ToString();
            this.ocurredOn = occurredOn?? DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        abstract public DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string ocurredOn);

        abstract public string EventName();

        abstract public Dictionary<string, string> ToPrimitives();
    }
}