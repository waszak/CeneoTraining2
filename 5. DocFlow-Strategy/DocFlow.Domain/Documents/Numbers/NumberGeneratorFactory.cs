using System;
using System.Collections.Generic;
using System.Text;
using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
    internal class NumberGeneratorFactory : INumberGeneratorFactory
    {
        private IConfigurationData _configurationData;
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
                default: throw new NotImplementedException();
            }
        }
    }
}
