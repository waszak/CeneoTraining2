using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public interface ICostCalculator
  {
    Money Calculate();
  }
}