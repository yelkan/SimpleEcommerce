using Inveon.Entities.Concrete;
using Inveon.Entities.Concrete.Dto;
using System.Collections.Generic;

namespace Inveon.Services.Abstract
{
    public interface IAccountService
    {
        bool Login(LoginDto user);
        bool Register(RegisterDto user);
        UserDto GetUser(string username);
        ICollection<Role> Roles(long userId);
    }
}
