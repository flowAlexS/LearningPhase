using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
// Handles different formats
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})  
.AddNewtonsoftJson() // Use for Patching a resource
.AddXmlDataContractSerializerFormatters(); // Add XML support to the API

builder.Services.AddProblemDetails(); // Using exception and logger..
// Manipulate errors..
//builder.Services.AddProblemDetails(options =>
//{
//    options.CustomizeProblemDetails = ctx => ctx.ProblemDetails.Extensions.Add("additionalInfo", "Additional info ex");
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
