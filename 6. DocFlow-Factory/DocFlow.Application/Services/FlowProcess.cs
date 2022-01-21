using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;
using System;
using DocFlow.Domain.Users.Roles;

namespace DocFlow.Application.Services
{
  public class FlowProcess
  {
    private IDocumentRepository documentRepo = new FakeDocumentRepository();

    private IUserRepository userRepo = new FakeUserRepository();
    private readonly ICostCalculatorFactory _costCalculatorFactory;
    private IDocumentFactory _documentFactory;

    public FlowProcess(ICostCalculatorFactory costCalculatorFactory, IDocumentFactory documentFactory)
    {
      _costCalculatorFactory = costCalculatorFactory;
      _documentFactory = documentFactory;
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Load(creatorId);

      Document document = _documentFactory.Create(type, creator);
      document.changeTitle(title);

      documentRepo.Save(document);
      return document.Number;
    }

    public void VerifyDocument(Guid verifierId, DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);
      User verifier = userRepo.Load(verifierId);
            
      document.Verify(verifier);

      documentRepo.Save(document);
    }

    public void PublishDocument(DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);

      document.Publish(_costCalculatorFactory.Create());

      documentRepo.Save(document);

      //print
      //notify
      //...
    }
  }
}