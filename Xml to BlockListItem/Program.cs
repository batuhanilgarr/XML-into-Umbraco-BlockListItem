using Xml_to_BlockListItem.Services;
using Xml_to_BlockListItem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()  
    .AddWebsite()     
    .AddDeliveryApi() 
    .AddComposers()
    .Build();

builder.Services.AddTransient<XmlImportService>(); 

var app = builder.Build();

await app.BootUmbracoAsync();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();  
        u.UseWebsite();     
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();  
        u.UseBackOfficeEndpoints(); 
        u.UseWebsiteEndpoints();    
    });

await app.RunAsync();
