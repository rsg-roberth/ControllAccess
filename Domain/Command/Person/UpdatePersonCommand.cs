using System;
using Domain.Command.Contract;
using Domain.Entities;
using Flunt.Validations;

namespace Domain.Command.Person
{
    public abstract class UpdatePersonCommand : Contract<UpdatePersonCommand>, ICommand
    {
        
        public UpdatePersonCommand(){}
        
        public UpdatePersonCommand(Guid id, string companyName, string fantasyName, string cnpj, bool active)
        {
            Id = id;
            CompanyName = companyName;
            FantasyName = fantasyName;
            CNPJ = cnpj; 
            Active = active;           
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get;  set; }
        public string CNPJ { get; set; }
        public bool Active { get; set; }
                        
        public virtual void Validate()
        {
            Requires()                
                .IsNotNullOrEmpty(Id.ToString(), "Id", "O Id deve ser informado")
                .IsTrue(Id != Guid.Empty,"Id", "O Id deve ser informado")
                .IsGreaterOrEqualsThan(Id.ToString(),36, "Id","O Id deve ter 36 caracteres")
                .IsLowerOrEqualsThan(Id.ToString(),36, "Id","O Id deve ter 36 caracteres")
                .IsNotNullOrEmpty(CompanyName,"CompanyName","A razão social deve ser informada")               
                .IsGreaterThan(CompanyName,3,"CompanyName","A razão social deve ter mais que 3 digitos")
                .IsLowerOrEqualsThan(CompanyName,45,"CompanyName","A razão social deve ter no máximo 45 digitos")
                .IsNotNullOrEmpty(FantasyName,"FantasyName","O nome fantasia não pode ser nulo")               
                .IsGreaterThan(FantasyName,3,"FantasyName","O nome fantasia deve ter mais que 3 digitos")
                .IsLowerOrEqualsThan(FantasyName,45,"FantasyName","O nome fantasia deve ter no máximo 45 digitos")
                .IsTrue(ValidateCNPJ.Validate(CNPJ),"CNPJ", "CNPJ inválido");
        }
    }
}