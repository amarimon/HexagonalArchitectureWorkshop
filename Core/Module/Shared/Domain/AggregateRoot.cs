using System.Collections.Generic;

namespace Core.Module.Shared.Domain
{
    public abstract class AggregateRoot
    {
        private List<DomainEvent> recordedDomainEvents = new List<DomainEvent>();

        public List<DomainEvent> PullDomainEvents()
        {
            List<DomainEvent> currentDomainEvents = this.recordedDomainEvents;
            this.recordedDomainEvents = new List<DomainEvent>();

            return currentDomainEvents;
        }

        protected void AddDomainEvent(DomainEvent domainEvent) {
            recordedDomainEvents.Add(domainEvent);
        }
    }
}
