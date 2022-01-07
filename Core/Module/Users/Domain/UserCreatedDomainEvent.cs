using Core.Module.Shared.Domain;
using System.Collections.Generic;

namespace Core.Module.Users.Domain
{
    sealed class UserCreatedDomainEvent : DomainEvent
    {
        private string userName { get; }
        private string email { get; }

        public UserCreatedDomainEvent(string userId, string userName, string email, string eventId = null, string occurredOn = null) : base(userId, eventId = null, occurredOn)
        {
            this.userName = userName;
            this.email = email;
        }

        public override string EventName()
        {
            return "user.created";
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            Dictionary<string, string> primitives = new Dictionary<string, string>();

            primitives.Add("username", this.userName);
            primitives.Add("email", this.email);

            return primitives;
        }

        public override UserCreatedDomainEvent FromPrimitives(
            string aggregateId,
            Dictionary<string, string> body,
            string eventId,
            string occurredOn)
        {

            return new UserCreatedDomainEvent(aggregateId, body.GetValueOrDefault("username"), body.GetValueOrDefault("email"),eventId, occurredOn);
        }
    }
}
