using Domain.Command.Contract;

namespace Domain.Handlers
{
    public interface IHandler<T> where T: ICommand
    {
        ICommandResult Handler(T command);
    }    
}