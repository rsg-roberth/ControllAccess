using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class CAT: Person
    {
       
       private readonly IList<Customer> _listCustomer;
       public CAT(string companyName, string fantasyName, string CNPJ):base(companyName, fantasyName, CNPJ)
       {
           _listCustomer = new List<Customer>();
       }

       public IReadOnlyCollection<Customer> ListCustomer => _listCustomer.ToArray();

       public void AddCustomer(Customer customer)
       {
           _listCustomer.Add(customer);
       }

        public override void MarkInactive()
        {
            if(_listCustomer.Count > 0) AddNotification("Customers", "CAT não pode ser desativado, pois, tem clientes vinculados.");
            base.MarkInactive();
        }
    }
}