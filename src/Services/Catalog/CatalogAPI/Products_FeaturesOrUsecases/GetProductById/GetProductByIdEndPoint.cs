
using CatalogAPI.Products_FeaturesOrUsecases.CreateProduct;

namespace CatalogAPI.Products_FeaturesOrUsecases.GetProductById
{
    //public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var query = new GetProductByIdQuery(id);

                var results = await sender.Send(query);

                return Results.Ok(results.Adapt<GetProductByIdResponse>());

            })
                 .WithName("GetProductById")
                .WithSummary("Gets the specific Product by Id param")
                .ProducesProblem(StatusCodes.Status400BadRequest) //lets say when we always want to return one status on failures
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)//KS - we can override status codes if we want to else defaults will be used.
                .WithDescription("Endpoint setup for getting specific product based on its Id");
        }
    }
}
