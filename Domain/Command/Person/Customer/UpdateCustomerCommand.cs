using System;
using Domain.Command.Person;

namespace Domain.Command.Customer
{
   public class UpdateCustomerCommand:UpdatePersonCommand
   {
       public UpdateCustomerCommand(){}
       
       public UpdateCustomerCommand(Guid id, string companyName, string fantasyName, string cnpj, Guid idCAT, bool active)
       :base(id, companyName, fantasyName, cnpj, active)
       {
          Id = id;
          IdCAT = idCAT;
       }        
       public Guid IdCAT { get; set; }

        public override void Validate()
        {
            Requires()
               .IsNotNullOrEmpty(IdCAT.ToString(), "IdCAT", "O CAT deve ser informado")
               .IsTrue(IdCAT != Guid.Empty,"IdCAT", "O CAT deve ser informado")
               .IsGreaterOrEqualsThan(IdCAT.ToString(),36, "IdCAT","O Id do CAT deve ter 36 caracteres")
               .IsLowerOrEqualsThan(IdCAT.ToString(),36, "IdCAT","O Id do CAT deve ter 36 caracteres");

            base.Validate();
        }

 

   } 
}