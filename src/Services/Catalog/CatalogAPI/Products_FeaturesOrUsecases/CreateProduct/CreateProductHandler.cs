namespace CatalogAPI.Products_FeaturesOrUsecases.CreateProduct
{
    //KS - business logic and layers of vertical slice are going to be here.

    //KS - Kind of Domain layer
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile,decimal Price): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    /// <summary>
    /// KS - Kind of Application later
    /// KS - Inject Marten Library's IDocumentSession
    /// </summary>
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //business logic goes here

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //Infrastructure layer..
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
