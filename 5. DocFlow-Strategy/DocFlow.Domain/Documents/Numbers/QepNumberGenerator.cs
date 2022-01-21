namespace DocFlow.Domain.Documents.Numbers
{
  public class QepNumberGenerator : INumberGenerator
  {
    private static int _internalCounter = 1;

    public DocumentNumber Generate()
    {
      return new DocumentNumber("QEP/"+_internalCounter++);
    }
  }
}