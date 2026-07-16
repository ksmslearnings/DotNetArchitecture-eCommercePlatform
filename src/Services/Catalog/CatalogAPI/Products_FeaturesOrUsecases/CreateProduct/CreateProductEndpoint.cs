namespace CatalogAPI.Products_FeaturesOrUsecases.CreateProduct
{
    /// <summary>
    /// KS - Kind of UI layer in Vertical slice Arch.
    /// </summary>
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //KS - will need conversion of Request to Command Object
            app.MapPost("/products", async (CreateProductRequest request, ISender mediatrSender) =>
            {
                var command = request.Adapt<CreateProductCommand>(); // Using Mapster library mapping request to command. This library will add Adapt method on all types.

                var result = await mediatrSender.Send(command); //call MediatR to call appropriate handler

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);//We are padding URL of next possible action to consumers so that they can call it if needed.
            })
                .WithName("CreateProduct") //KS - Carter library extension methods to add more details and functions
                .WithSummary("Creates the Product by accepting the request")
                .ProducesProblem(StatusCodes.Status400BadRequest) //lets say when we always want to return one status on failures
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)//KS - we can override status codes if we want to else defaults will be used.
                .WithDescription("Endpoint setup for creating products using Maspter, MediatR, Carter Libraries");
        }
    }

}
