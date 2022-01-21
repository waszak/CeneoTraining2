using System;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentAssembler
  {
    private DocumentType type = DocumentType.PROCEDURE;
    private User author = new User(Guid.NewGuid());
    private DocumentStatus _status;
    public Document Build()
    {
      if (_status == DocumentStatus.PUBLISHED)
      {
        var result = new Document(type, author);
        result.Verify(new User(Guid.NewGuid()));
        result.Publish();
        return result;
      }

      throw new NotSupportedException();
    }

    public DocumentAssembler Published()
    {
      _status = DocumentStatus.PUBLISHED;
      return this;
    }

    public DocumentAssembler Verified()
    {
      _status = DocumentStatus.VERIFIED;
      return this;
    }
  }
}