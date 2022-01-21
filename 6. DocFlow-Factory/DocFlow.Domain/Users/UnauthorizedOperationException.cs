using System;
using System.Security;

namespace DocFlow.Domain.Users
{
  public class UnauthorizedOperationException : SecurityException
  {
    public Guid User { get; private set; }

    public UnauthorizedOperationException(Guid user, string message) : base(message)
    {
      User = user;
    }    
  }
}