using System;
using Domain.Command.Person;

namespace Domain.Command.CAT
{
   public class UpdateCATCommand:UpdatePersonCommand
   {
       public UpdateCATCommand(){}
       
       public UpdateCATCommand(Guid id,string companyName, string fantasyName, string cnpj, bool active)
       :base(id,companyName, fantasyName, cnpj, active){}
       
   }
}