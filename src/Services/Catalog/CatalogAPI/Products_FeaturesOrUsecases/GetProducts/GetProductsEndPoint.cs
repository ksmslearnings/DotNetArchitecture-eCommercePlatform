
namespace CatalogAPI.Products_FeaturesOrUsecases.GetProducts
{
    //GetProductsRequest - We dont need any request here but added for completion
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var results = await sender.Send(new GetProductsQuery());
                var response = results.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .WithSummary("Get All Products")
                .WithDescription("Get All Products without using any parameter")
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .Produces<GetProductsResponse>(StatusCodes.Status200OK);
        }
    }
}
