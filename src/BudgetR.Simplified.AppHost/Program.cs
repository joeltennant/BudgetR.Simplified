var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BudgetR_Simplified>("budgetr_simplified");

builder.Build().Run();
