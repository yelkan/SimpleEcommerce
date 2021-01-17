using Inveon.DataAccess.Abstract;
using Inveon.Entities.Concrete;
using Inveon.Services.Abstract;
using System.Collections.Generic;
using Inveon.Entities.Concrete.Dto;

namespace Inveon.Services.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountRepository _accountRepo;
        public AccountManager(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public bool Login(LoginDto user)
        {
            return _accountRepo.Login(user);
        }

        public bool Register(RegisterDto user)
        {
            return _accountRepo.Register(user);
        }
        public UserDto GetUser(string username)
        {
            return _accountRepo.GetUser(username);
        }
        public ICollection<Role> Roles(long userId)
        {
            return _accountRepo.Roles(userId);
        }
    }
}
