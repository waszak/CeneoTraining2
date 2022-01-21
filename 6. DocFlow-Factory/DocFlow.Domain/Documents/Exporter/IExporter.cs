using System.IO;

namespace DocFlow.Domain.Documents
{
  public interface IExporter
  {
    void Build(DocumentNumber number);
    void Build(DocumentStatus status);
    void Build(string title);

    Stream GetResult();
  }
}