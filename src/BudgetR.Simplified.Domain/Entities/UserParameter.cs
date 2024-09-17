namespace BudgetR.Simplified.Server.Domain.Entities;
public class UserParameter
{
    [Key]
    public long UserParameterId { get; set; }
    public ParameterType? ParameterType { get; set; }
    public string? Value { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}

public enum ParameterType
{
    DownloadPath,
    IncomingPath,
    ArchivePath,
    FailedPath
}