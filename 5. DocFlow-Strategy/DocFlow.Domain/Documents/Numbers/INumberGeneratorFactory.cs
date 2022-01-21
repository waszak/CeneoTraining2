using System;
using System.Collections.Generic;
using System.Text;
using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
    public interface INumberGeneratorFactory
    {
        INumberGenerator Create();
    }
}
