using Core.Module.Shared.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Module.Shared.Domain
{
    public class DummyEventBus : IEventBus
    {
        Task IEventBus.Publish(List<DomainEvent> domainEvents)
        {
            return Task.CompletedTask;
        }
    }
}
