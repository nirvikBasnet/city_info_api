using Microsoft.AspNetCore.StaticFiles;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>{
    options.ReturnHttpNotAcceptable = true; //if other than json data format is requested
}).AddXmlDataContractSerializerFormatters(); //support to xml

//addcontrollersview (for razer views) or addmvc (more unecessacy services)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//to support files
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Routing : Matches a request URI to an action on a controller
//ASP.NET core 6 : The prefered way to set it up is EndPoint Routing


//To setup Routing we need 
//app.UseRouting(): marks the position in the middleware pipeline where
//a routing decision is made, where a endpoint is selected.
//app.UseEndpoints(): where selected endpoint is executed.
//Allows to enject middleware between > 1 & 2.

//mapping endpoints - convention based & attribute based routing(API) [Route],[HttpGet]



//Enabling endpoint routing [NO ATTRIBUTE ROUTE ERROR]
app.UseRouting();

app.UseAuthorization();

//To use [HttpGet],[HttpPost] etc.. in the controllers [NO ATTRIBUTE ROUTE ERROR]
app.UseEndpoints(endpoints =>{
    endpoints.MapControllers();
});

app.Run();
//Important reading materials
//Routing : docs.microsoft.com/aspnet/core/fundamentals/routing
//Format response & content negotiation :docs.microsoft.com/aspnet/core/advance/formatting