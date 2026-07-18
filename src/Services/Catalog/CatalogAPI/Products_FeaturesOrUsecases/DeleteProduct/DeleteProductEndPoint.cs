namespace CatalogAPI.Products_FeaturesOrUsecases.DeleteProduct
{
   // public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool status);

    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender mediatrSender) =>
            {
                var result = await mediatrSender.Send(new DeleteProductCommand(Id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteProduct") //KS - Carter library extension methods to add more details and functions
            .WithSummary("Deletes the Product by accepting the request")
            .ProducesProblem(StatusCodes.Status400BadRequest) //lets say when we always want to return one status on failures
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)//KS - we can override status codes if we want to else defaults will be used.
            .WithDescription("Delete the Product by accepting product Id");
        }
    }
}
