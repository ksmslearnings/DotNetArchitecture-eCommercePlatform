var builder = WebApplication.CreateBuilder(args);

//KS - Add services here

var app = builder.Build();

//KS - Configure http request pipeline here

app.Run();
