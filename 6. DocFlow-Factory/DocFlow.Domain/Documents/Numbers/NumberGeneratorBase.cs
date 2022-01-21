namespace DocFlow.Domain.Documents.Numbers
{
  internal abstract class NumberGeneratorBase : INumberGenerator
  {
    protected readonly INumberGenerator _numberGenerator;

    public NumberGeneratorBase(INumberGenerator numberGenerator)
    {
      _numberGenerator = numberGenerator;
    }

    public abstract DocumentNumber Generate();
  }
}