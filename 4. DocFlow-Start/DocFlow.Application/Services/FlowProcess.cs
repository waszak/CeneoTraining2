using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;
using System;
using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Application.Services
{
  public class FlowProcess
  {
    private readonly IConfigurationData _configurationData;
    private IDocumentRepository documentRepo = new FakeDocumentRepository();

    private IUserRepository userRepo = new FakeUserRepository();

    public FlowProcess(IConfigurationData configurstionData)
    {
      _configurationData = configurstionData;
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Load(creatorId);

      //if(_configurationData.QualitySystem == QualitySystemType.ISO)

      Document document = new Document(type, creator); //TODO factory
      document.ChangeTitle(title);

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

      document.Publish(); //TODO walidacja i liczenie cen

      documentRepo.Save(document);

      //print
      //notify
      //...
    }
  }
}