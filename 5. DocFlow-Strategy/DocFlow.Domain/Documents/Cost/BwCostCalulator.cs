using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class BwCostCalulator : ICostCalculator
  {
    public Money Calculate()
    {
      return new Money(12d);
    }
  }
}