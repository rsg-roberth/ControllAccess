using System.Linq;
using Domain.Command;
using Domain.Command.Contract;
using Domain.Command.Customer;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Handlers
{
    public class CustomerHandler :
        IHandler<CreateCustomerCommand>,
        IHandler<UpdateCustomerCommand>
    {
        
        private readonly ICustomerRepository _repository;
        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
                
        public ICommandResult Handler(CreateCustomerCommand command)
        {
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false,"Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);

            if(_repository.Search(x=>x.CNPJ == command.CNPJ).Any()) return new GenericCommandResult(false, "Já existe um cliente com este CNPJ",null);               

            var customer = new Customer(command.CompanyName, command.FantasyName, command.CNPJ, command.IdCAT);
            _repository.Create(customer);

            return new GenericCommandResult(true, "Cliente cadastrado!", customer);
        }

        
        public ICommandResult Handler(UpdateCustomerCommand command)
        {
            command.Validate();
            if(!command.IsValid) return new GenericCommandResult(false, "Ops! Operação não pode ser realizada. Cheque as informações retornadas.", command.Notifications);

            if(_repository.Search(x => x.CNPJ == command.CNPJ && x.Id != command.Id).Any()) return new GenericCommandResult(false, "CNPJ pertence a outro cliente", null);

            var customer = _repository.GetById(command.Id);
            if(customer == null) return new GenericCommandResult(false, "Cliente não encontrado", null);

            if(customer.Active == true && command.Active == false) customer.MarkInactive();
            if(!customer.IsValid) return new GenericCommandResult(false, "Ops! Operação não pode ser realizada. Cheque as informações retornadas.", customer.Notifications);

            if(customer.Active == false && command.Active == true) customer.MarkActive();

            _repository.Update(customer);

            return new GenericCommandResult(true, "Cliente atualizado com sucesso", customer);
        }

    }
}