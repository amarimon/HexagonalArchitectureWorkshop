using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Module.Shared.Domain
{
    interface IEventDispatcher
    {
        Task Dispatch(DomainEvent domainEvent);
    }
}
