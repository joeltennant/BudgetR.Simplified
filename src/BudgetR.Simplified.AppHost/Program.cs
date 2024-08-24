var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BudgetR_Simplified>("budgetR-simplified");

builder.Build().Run();
