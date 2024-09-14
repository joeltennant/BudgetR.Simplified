namespace BudgetR.Simplified.Infrastructure.Data.Configurations;
public class BudgetMonthsConfiguration : IEntityTypeConfiguration<BudgetMonth>
{
    public void Configure(EntityTypeBuilder<BudgetMonth> builder)
    {
        builder.ToTable("BudgetMonths",
                       a => a.IsTemporal
                                  (
                                          a =>
                                          {
                                              a.UseHistoryTable("BudgetMonthHistory");
                                              a.HasPeriodStart(DomainConstants.Started);
                                              a.HasPeriodEnd(DomainConstants.Ended);
                                          }));
    }
}