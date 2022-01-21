using System;
using System.Collections.Generic;
using System.Text;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents
{
    internal class DocumentFactory : IDocumentFactory
    {
        private readonly INumberGeneratorFactory _factory;
        public DocumentFactory(INumberGeneratorFactory factory)
        {
            _factory = factory;
        }
        public Document Create(DocumentType type, User creator)
        {
            return new Document(type, creator, CreateNumber());
        }
        private DocumentNumber CreateNumber()
        {
            return GetNumberGenerator().Generate();
        }

        private INumberGenerator GetNumberGenerator()
        {
            return _factory.Create();
        }
    }
}
