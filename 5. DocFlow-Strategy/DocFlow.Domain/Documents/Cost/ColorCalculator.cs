using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class ColorCalculator : ICostCalculator
  {
    public Money Calculate()
    {
      return new Money(20d);
    }
  }
}