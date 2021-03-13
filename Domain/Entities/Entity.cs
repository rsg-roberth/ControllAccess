using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public abstract class Entity:Notifiable<Notification>, IEquatable<Entity>     
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}