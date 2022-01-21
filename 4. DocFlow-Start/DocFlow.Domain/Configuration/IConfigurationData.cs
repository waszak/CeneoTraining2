namespace DocFlow.Domain.Documents.Configuration
{
  public interface IConfigurationData
  {
    QualitySystemType QualitySystem { get; }
    EnvironmentType EnvType { get; }
    bool ColorPrintingEnabled { get; }
  }
}