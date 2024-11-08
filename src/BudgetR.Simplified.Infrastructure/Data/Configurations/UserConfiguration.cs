﻿namespace BudgetR.Simplified.Server.Infrastructure.Data.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users",
                        a => a.IsTemporal(
                                  a =>
                                  {
                                      a.HasPeriodStart(DomainConstants.Started);
                                      a.HasPeriodEnd(DomainConstants.Ended);
                                      a.UseHistoryTable("UserHistory");
                                  }));

        builder.HasData
            (
                new User//system user
                {
                    UserId = 1,
                    AuthenticationId = string.Empty,
                    FirstName = "System",
                    UserType = UserType.System,
                    BusinessTransactionActivityId = 1
                }
            );
    }
}