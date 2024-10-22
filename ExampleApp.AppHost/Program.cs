

var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

var products = builder.AddProject<Projects.Products>("products");

builder.AddProject<Projects.Store>("store")
    .WithReference(products);

builder.Build().Run();
