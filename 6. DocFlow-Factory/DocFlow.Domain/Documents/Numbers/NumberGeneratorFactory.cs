using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;
using System.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
  internal class NumberGeneratorFactory : INumberGeneratorFactory
  {
    IConfigurationData _configurationData;

    public NumberGeneratorFactory(IConfigurationData configurationData)
    {
      _configurationData = configurationData;
    }
    public INumberGenerator Create()
    {
      switch (_configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          return new IsoNumberGenerator();

        case QualitySystemType.QEP:
          return new QepNumberGenerator();

        default:
          throw new ConfigurationException("Invalid quality system in configuration");
      }
    }
  }
}