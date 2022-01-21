using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  internal class ColorCalculator : ICostCalculator
  {
    public Money Calculate()
    {
      return new Money(10d);
    }
  }
}