using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer: Person
    {
        private readonly IList<Access> _listAccess;
        public Customer(string companyName, string fantasyName,string CNPJ, Guid IdCAT):base(companyName, fantasyName, CNPJ)
        {
            _listAccess = new List<Access>();
            this.IdCAT = IdCAT;
        }

        public Guid IdCAT { get; private set; }
        public CAT CAT { get; private set; }
        public IReadOnlyCollection<Access> ListAccess { get; private set; }
        public void AddAccess(Access access)
        {
            _listAccess.Add(access);
        }

        public override void MarkInactive()
        {
            if(_listAccess.Count > 0) AddNotification("Access", "Cliente não pode ser desativado, pois, tem acessos vinculados.");
            base.MarkInactive();
        }

    }
}