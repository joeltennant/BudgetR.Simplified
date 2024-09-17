namespace BudgetR.Simplified.Server.Infrastructure.Data.Configurations;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts",
            a => a.IsTemporal
            (
                a =>
                {
                    a.UseHistoryTable("AccountHistory");
                    a.HasPeriodStart(DomainConstants.Started);
                    a.HasPeriodEnd(DomainConstants.Ended);
                })
            .HasCheckConstraint("CK_Account_Balance", "[Balance] >= 0"));
    }
}
