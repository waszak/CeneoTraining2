namespace DocFlow.Domain.Documents.Configuration
{
  public interface IConfigurationProvider
  {
    QualitySystemType QualitySystem { get; }
    string EnvName { get; }
    bool ColorPrintingEnabled { get; }
  }
}