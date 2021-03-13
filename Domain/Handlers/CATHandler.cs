using System.Linq;
using Domain.Command;
using Domain.Command.CAT;
using Domain.Command.Contract;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Handlers
{
    public class CATHandler :
        IHandler<CreateCATCommand>,
        IHandler<UpdateCATCommand>
    {
        
        private readonly ICATRepository _repository;
        public CATHandler(ICATRepository repository)
        {
            _repository = repository;
        }
        
        public ICommandResult Handler(CreateCATCommand command)
        {
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false,"Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);
            
            //Validar se cnpj esta vinculado a outro CAT
            if(_repository.Search(x => x.CNPJ == command.CNPJ).Any()) return new GenericCommandResult(false, "Já existe um CAT com este CNPJ",null);

            var cat = new CAT(command.CompanyName, command.FantasyName, command.CNPJ);
            _repository.Create(cat);

            return new GenericCommandResult(true, "CAT cadastrado!", cat);
        }

        public ICommandResult Handler(UpdateCATCommand command)
        {
            //Validar dados de entrada - fail fast validation
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false,"Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);
                
            //Validar se cnpj esta vinculado a outro CAT
            if(_repository.Search(x => x.CNPJ == command.CNPJ && x.Id != command.Id).Any()) return new GenericCommandResult(false, "Já existe um CAT com este CNPJ",null);                
            
            var cat = _repository.GetById(command.Id);
            
            //Validar se pode desativar
            if(command.Active == false && cat.Active == true) cat.MarkInactive();                
            if(!cat.IsValid) return new GenericCommandResult(false, "Ops! Operação não pode ser realizada. Cheque as informações retornadas.", cat.Notifications);
            
            if(command.Active == true && cat.Active == false) cat.MarkActive();                

            cat.UpdateCNPJ(command.CNPJ);
            cat.UpdateCompanyName(command.CompanyName);
            cat.UpdateFantasyName(command.FantasyName);

            _repository.Update(cat);

            return new GenericCommandResult(true, "CAT atualizado!", cat);
        }
    }
}