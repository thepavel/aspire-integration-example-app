var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Store>("store");
builder.AddProject<Projects.Products>("products")
    .WithHttpEndpoint(port: 5200, name: "products");

builder.Build().Run();
