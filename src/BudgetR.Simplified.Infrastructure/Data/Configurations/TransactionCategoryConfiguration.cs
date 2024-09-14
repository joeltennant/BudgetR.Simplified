namespace BudgetR.Simplified.Infrastructure.Data.Configurations;
public class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
{
    public void Configure(EntityTypeBuilder<TransactionCategory> builder)
    {
        builder.ToTable("TransactionCategories",
                       a => a.IsTemporal
                                  (
                                          a =>
                                          {
                                              a.UseHistoryTable("TransactionCategoryHistory");
                                              a.HasPeriodStart(DomainConstants.Started);
                                              a.HasPeriodEnd(DomainConstants.Ended);
                                          }));
    }
}
