using MediatR;

namespace CatalogAPI.Products_FeaturesOrUsecases.CreateProduct
{
    //business logic and layers of vertical slice are going to be here.

    public record CreateProductCommand(string Name, string description, List<string> categories, string ImageFile,decimal price): IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);


    public class CreateProductCommandHandlerHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Business logic to create a product
            throw new NotImplementedException();
        }
    }
}
