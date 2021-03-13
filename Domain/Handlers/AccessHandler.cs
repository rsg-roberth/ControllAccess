using Domain.Command;
using Domain.Command.Access;
using Domain.Command.Contract;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Handlers
{
    public class AccessHandler :
        IHandler<CreateAccessCommand>,
        IHandler<UpdateAccessCommand>
    {
        
        private readonly IAccessRepository _repository;
        public AccessHandler(IAccessRepository repository)
        {
            _repository = repository;
        }
        
        public ICommandResult Handler(CreateAccessCommand command)
        {
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false,"Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);
                      
            var access = new Access(command.Title, command.Description, command.IdCustomer);
            _repository.Create(access);

            return new GenericCommandResult(true, "Acesso cadastrado!", access);
        }

        public ICommandResult Handler(UpdateAccessCommand command)
        {
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false,"Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);
                      
            var access = new Access(command.Title, command.Description, command.IdCustomer);
            _repository.Create(access);

            return new GenericCommandResult(true, "Acesso atualizado!", access);            
        }
    }
}