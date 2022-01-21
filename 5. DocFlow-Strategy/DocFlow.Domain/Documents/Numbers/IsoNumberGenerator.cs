namespace DocFlow.Domain.Documents.Numbers
{
  public class IsoNumberGenerator : INumberGenerator
  {
    private static int _internalCounter = 1;

    public DocumentNumber Generate()
    {
      return new DocumentNumber("ISO/"+_internalCounter++);
    }
  }
}