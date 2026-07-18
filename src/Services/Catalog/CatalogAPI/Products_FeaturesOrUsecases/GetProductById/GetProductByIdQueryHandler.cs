namespace CatalogAPI.Products_FeaturesOrUsecases.GetProductById
{
    public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);


    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get specific product based on passed Id as {Id}", query.Id);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
                throw new ProductNotFoundException();

            return new GetProductByIdResult(product);
        }
    }
}
