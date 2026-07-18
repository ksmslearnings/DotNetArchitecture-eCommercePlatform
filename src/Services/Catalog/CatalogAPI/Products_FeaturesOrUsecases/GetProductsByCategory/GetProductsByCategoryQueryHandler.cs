namespace CatalogAPI.Products_FeaturesOrUsecases.GetProductsByCategory
{
    //query and result types
    public record GetProductsByCategoryQuery(string category): IQuery<GetProductsByCategoyResult>;

    public record GetProductsByCategoyResult(IEnumerable<Product> Products);
    public class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoyResult>
    {
        public async Task<GetProductsByCategoyResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all products based onn category as {category}", query.category);

            var results = await session.Query<Product>().Where(x=> x.Category.Contains(query.category)).ToListAsync(cancellationToken);

            return new GetProductsByCategoyResult(results);
        }
    }
}
