using System;

namespace DocFlow.Domain.Users
{
  public interface IUserRepository
  {
    User Load(Guid creatorId);
  }
}
