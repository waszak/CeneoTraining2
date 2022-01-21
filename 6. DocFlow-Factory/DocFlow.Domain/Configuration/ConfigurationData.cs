using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents
{
  public class ConfigurationData : IConfigurationData
  {
    public QualitySystemType QualitySystem { get; private set; }

    public EnvironmentType EnvType { get; private set; }

    public bool ColorPrintingEnabled { get; private set; }
  }
}