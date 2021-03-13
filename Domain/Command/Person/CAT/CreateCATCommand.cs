using Domain.Command.Person;

namespace Domain.Command.CAT
{
   public class CreateCATCommand:CreatePersonCommand
   {
       public CreateCATCommand(){}
       
       public CreateCATCommand(string companyName, string fantasyName, string cnpj)
            :base(companyName, fantasyName, cnpj){}       

   } 
}