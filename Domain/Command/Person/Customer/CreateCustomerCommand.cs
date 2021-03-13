using System;
using Domain.Command.Person;

namespace Domain.Command.Customer
{
   public class CreateCustomerCommand:CreatePersonCommand
   {
       public CreateCustomerCommand(){}
       
       public CreateCustomerCommand(string companyName, string fantasyName, string cnpj, Guid idCAT)
       :base(companyName, fantasyName, cnpj)
       {
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