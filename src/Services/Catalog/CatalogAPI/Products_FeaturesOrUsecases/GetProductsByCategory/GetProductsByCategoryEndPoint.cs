
namespace CatalogAPI.Products_FeaturesOrUsecases.GetProductsByCategory
{
    //Define UI Layer with request and response objects

    //public record GetProductsByCategoryRequest(); --Not needed for this usecase/feature
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsByCategoryQuery(category));

                var response = result.Adapt<GetProductsByCategoryResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProductsByCategory")
                .WithSummary("Get Products By Category")
                .WithDescription("Filter All Products based on passed category")
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK);
        }
    }
}
