using System;
using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class CostCalculatorFactory : ICostCalculatorFactory
  {
    private readonly IConfigurationData _configurationData;

    public CostCalculatorFactory(IConfigurationData configurationData)
    {
      _configurationData = configurationData;
    }

    public ICostCalculator Create()
    {
      if (!_configurationData.ColorPrintingEnabled)
      {
        return new BwCostCalulator();
      }
      
      return new ColorCalculator();      
    }
  }
}