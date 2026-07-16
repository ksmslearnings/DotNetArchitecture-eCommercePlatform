using MediatR;

namespace BuildingBlocks.CQRSAbstractions
{
    public interface IQuery : IRequest<Unit>
    {
    }

    public interface IQuery<out TResponse>: IRequest<TResponse> where TResponse: notnull  // added generic filter in case of IQuery since it should return something
    {
    }
}
