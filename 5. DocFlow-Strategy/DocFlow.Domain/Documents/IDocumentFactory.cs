using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents
{
  public interface IDocumentFactory
  {
    Document Create(DocumentType type, User creator);
  }
}