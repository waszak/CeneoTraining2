using System;
using System.Collections.Generic;
using System.Text;
using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents.Cost
{
    internal class CostCalculationFactory : ICostCalculationFactory
    {
        private IConfigurationData _configurationData;
        public CostCalculationFactory(IConfigurationData configurationData)
        {
            _configurationData = configurationData;
        }
        public ICostCalculator Create()
        {
            if (_configurationData.ColorPrintingEnabled)
            {
                return new ColorCalculator();
            }
            else
            {
                return new BwCostCalulator();
            }
        }
    }
}
