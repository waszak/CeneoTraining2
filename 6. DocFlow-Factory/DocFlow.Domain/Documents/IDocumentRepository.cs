using System;

namespace DocFlow.Domain.Documents
{
  public interface IDocumentRepository
  {
    void Save(Document document);

    Document Load(DocumentNumber number);

    Document Load(Guid id);
  }
}