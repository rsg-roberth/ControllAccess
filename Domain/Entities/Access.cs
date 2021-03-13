using System;

namespace Domain.Entities
{
    public class Access: Entity
    {
        public Access(string title, string description, Guid idCustomer)
        {
            Title = title;
            Description = description;
            IdCustomer = idCustomer;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid IdCustomer { get; private set; }
        public Customer Customer { get; private set; }
        public bool Active { get; set; }

        public void UpdateTitle(string title)
        {
            Title = title;            
        }

        public void UpdateDescription(string description)
        {
            Description = description;            
        }
       
        public void MarkActive()
        {
            Active = true;
        }

        public virtual void MarkInactive()
        {                        
            Active = false;
        }    
    }
}