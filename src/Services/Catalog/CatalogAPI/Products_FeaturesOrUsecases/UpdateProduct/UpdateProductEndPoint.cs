namespace CatalogAPI.Products_FeaturesOrUsecases.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool status);

    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender mediatrSender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await mediatrSender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct") //KS - Carter library extension methods to add more details and functions
            .WithSummary("Updates the Product by accepting the request")
            .ProducesProblem(StatusCodes.Status400BadRequest) //lets say when we always want to return one status on failures
            .Produces<UpdateProductResponse>(StatusCodes.Status201Created)//KS - we can override status codes if we want to else defaults will be used.
            .WithDescription("Update the Product by accepting full product update request");
        }
    }
}
