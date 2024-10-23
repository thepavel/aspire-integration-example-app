

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
                    .AddPostgres("postgres")
                    .WithPgAdmin();
                    
var postgresdb = postgres.AddDatabase("postgresdb");

var products = builder
                .AddProject<Projects.Products>("products")
                .WithReference(postgresdb);

builder.AddProject<Projects.Store>("store")
    .WithReference(products);

builder.Build().Run();
