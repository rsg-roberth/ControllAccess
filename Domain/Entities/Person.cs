namespace Domain.Entities
{
    public abstract class Person: Entity
    {
        protected Person(string companyName, string fantasyName, string CNPJ)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            this.CNPJ = CNPJ;
            Active = true;
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public string CNPJ { get; private set; }
        public bool Active { get; private set; }

        public void MarkActive()
        {
            Active = true;
        }

        public virtual void MarkInactive()
        {                        
            Active = false;
        }

        public void UpdateCNPJ(string cnpj)
        {                                                      
            CNPJ = cnpj;
        }

        public void UpdateCompanyName(string companyName)
        {
            CompanyName = companyName;
        }

        public void UpdateFantasyName(string fantasyName)
        {
            FantasyName = fantasyName;
        }    
    }
}