using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using System;

namespace DocFlow.Domain.Documents
{
  public interface INumberGeneratorFactory
  {
    INumberGenerator Create();
  }
}