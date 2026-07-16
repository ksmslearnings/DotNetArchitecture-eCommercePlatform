using MediatR;

namespace BuildingBlocks.CQRSAbstractions
{
    //KS - why I cant do this . It is same thing as below isn't it? Exactly the same meaning.
    //public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit> where TCommand : IRequest<Unit>
    //{
    //}

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}
