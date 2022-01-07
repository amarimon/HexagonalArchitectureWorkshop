using System;
using System.Collections.Generic;

namespace Core.Module.Shared.Domain
{
    public abstract class DomainEvent
    {
        private string aggregateId { get; set; }
        private string eventId { get; set; }
        private string ocurredOn { get; set; }

        public DomainEvent(string aggregateId, string eventId = null, string occurredOn = null)
        {
            this.aggregateId = aggregateId;
            this.eventId = eventId ?? Guid.NewGuid().ToString();
            this.ocurredOn = occurredOn;// ?? Utils::dateToString(new DateTime());
        }

        abstract public DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string ocurredOn);

        abstract public string EventName();

        abstract public Dictionary<string, string> ToPrimitives();
    }
}