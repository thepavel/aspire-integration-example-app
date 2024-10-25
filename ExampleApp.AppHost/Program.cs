

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
                    .AddPostgres("postgres")
                    .WithPgAdmin();

var mongo = builder.AddMongoDB("mongo")
        .WithMongoExpress();
var mongodb = mongo.AddDatabase("BasketDB");
                    
var postgresdb = postgres.AddDatabase("postgresdb");

var products = builder
                .AddProject<Projects.Products>("products")
                .WithReference(postgresdb);

builder.AddProject<Projects.Store>("store")
    .WithReference(products)
    .WithReference(mongodb);

builder.Build().Run();
