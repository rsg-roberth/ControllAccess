using System;
using Domain.Command.Contract;
using Flunt.Validations;

namespace Domain.Command.Access
{
    public class UpdateAccessCommand : Contract<UpdateAccessCommand>,ICommand
    {
        public UpdateAccessCommand(Guid id, string title, string description, Guid idCustomer)
        {
            
            Id = id;
            Title = title;
            Description = description;
            IdCustomer = idCustomer;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid IdCustomer { get; private set; }
        
        public void Validate()
        {
            Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id", "O Id do acesso deve ser informado")
                .IsTrue(Id != Guid.Empty, "Id", "O Id do acesso deve ser informado")
                .IsGreaterOrEqualsThan(Id.ToString(),36, "Id","O Id do acesso deve ter 36 caracteres")
                .IsLowerOrEqualsThan(Id.ToString(),36, "Id","O Id do acesso deve ter 36 caracteres")
                .IsNotNullOrEmpty(Title, "Title", "O titulo deve ser informado")
                .IsGreaterThan(Title,3, "Title","O titulo deve ter mais que 3 caracteres")
                .IsLowerOrEqualsThan(Title,45, "Title","O titulo deve ter menos que 45 caracteres")
                .IsNotNullOrEmpty(Description, "Description", "A descrição deve ser informada")
                .IsGreaterThan(Description,3, "Description","A descrição deve ter mais que 3 caracteres")
                .IsNotNullOrEmpty(IdCustomer.ToString(), "IdCustomer", "O cliente deve ser informado")
                .IsTrue(IdCustomer != Guid.Empty, "IdCustomer", "O cliente deve ser informado")
                .IsGreaterOrEqualsThan(IdCustomer.ToString(),36, "IdCustomer","O Id do cliente deve ter 36 caracteres")
                .IsLowerOrEqualsThan(IdCustomer.ToString(),36, "IdCustomer","O Id do cliente deve ter 36 caracteres");
        }
    }

}