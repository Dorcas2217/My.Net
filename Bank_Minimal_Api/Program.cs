var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/tva", (double prix, string code ) =>

{
   if(code.Equals("FR"))
    {
        return (prix * 21) / 100;

    }
    else if(code.Equals("BE"))
    {
        return (prix * 20) / 100;
    }
   else
    {
        return 0;
    }

})
.WithName("GetTVA")
.WithOpenApi();

app.Run();

