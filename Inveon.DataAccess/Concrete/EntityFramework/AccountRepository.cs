using Inveon.Core.Common;
using Inveon.DataAccess.Abstract;
using Inveon.DataAccess.Concrete.EntityFramework.Context;
using Inveon.Entities.Concrete;
using Inveon.Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Inveon.DataAccess.Concrete.EntityFramework
{
    public class AccountRepository : IAccountRepository
    {
        public bool Login(LoginDto user)
        {
            using (var context = new AuthenticationDbContext())
            {
                return context.Users.Any(x => x.Username == user.Username && x.Password == user.Password);
            }
        }
                
        public bool Register(RegisterDto user)
        {
            using (var context = new AuthenticationDbContext())
            {
                if (context.Users.Any(x => x.Username == user.Username))
                    return false;

                var role=context.Roles.FirstOrDefault(x => x.Id == 1);

                var newUser = new User()
                {
                    Username = user.Username,
                    EmailAddress = user.Email,
                    NameSurname = user.NameSurname,
                    Password = user.Password,
                    CreatedDate = DateTimeOffset.Now,
                    Creator = 0,
                    Roles= new List<Role>() { role }
                };

                try
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }

                
                return true;
            }
        }

        public UserDto GetUser(string username) 
        {
            using (var context = new AuthenticationDbContext())
            {
                var exist =  context.Users.Where(x => x.Username == username).Include(x => x.Roles).FirstOrDefault();
                var dto = new UserDto();
                Mapper.PropertyMap(exist, dto);

                if(exist.Roles != null)
                    foreach(var role in exist.Roles)
                    {
                        var roleDto = new RoleDto();
                        Mapper.PropertyMap(role, roleDto);
                        dto.Roles.Add(roleDto);
                    }

                return dto;
            }
        }
        public ICollection<Role> Roles(long userId)
        {
            using (var context = new AuthenticationDbContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == userId).Roles;
            }
        }
    }
}
