using System;
using System.Collections.Generic;
using System.Text;

namespace DocFlow.Domain.Documents.Cost
{
    public interface ICostCalculationFactory
    {
        ICostCalculator Create();
    }
}
