using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//KS - Add services here
//IMP - KS - Carter doesnt provide a way to tell which assembly we need to scan to read our endpoint setups. If Carter library is moved to Building blocks, endpoints are not
//registered and app will not work with this version of Carter. it only works when library itself is installed in the same project where we are configuring it up.
//So , author removed Carter from building blocks and moved it directly into main API project. Other libraries are not impacted and they work even when they are installed in
// separate project for easier management.
builder.Services.AddCarter();//KS - will add necessary services to asp.net core DI
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);// KS - this will tell mediatR where and which assembly has Command and Query Handler classes are available.
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("database")!);
});

var app = builder.Build();

//KS - Configure http request pipeline here
app.MapCarter();//this will map the routes defined in ICarterModule implementation.
                //So in our case it will map the routes present in CreateProductEndpoint class since it implement ICarterModule

app.Run();
