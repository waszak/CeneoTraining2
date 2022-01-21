using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentAssembler
  {
    private DocumentType type = DocumentType.PROCEDURE;
    private User author = new User(Guid.NewGuid());

    public Document Build()
    {
      return new Document(type, author, new DocumentNumber("1"));
    }

    public DocumentAssembler Published()
    {
      //TODO
      return this;
    }
  }
}