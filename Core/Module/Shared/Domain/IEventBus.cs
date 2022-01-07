using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Module.Shared.Domain
{
    public interface IEventBus
    {
        Task Publish(List<DomainEvent> domainEvents);
    }
}
