using MediatR;

namespace BuildingBlocks.CQRSAbstractions
{
    public interface ICommand: IRequest<Unit> //KS - Unit comes from MediatR and it represents a void type. C# void is not a valid return type and thats why this is used.
    {
    }
    public interface ICommand<out TResponse>: IRequest<TResponse>
    {
    }

}
