namespace DocFlow.Domain.Documents.Numbers
{
  internal class IsoNumberGenerator : INumberGenerator
  {
    private static int _internalCounter = 1;

    public DocumentNumber Generate()
    {
      return new DocumentNumber(_internalCounter++.ToString());
    }
  }
}