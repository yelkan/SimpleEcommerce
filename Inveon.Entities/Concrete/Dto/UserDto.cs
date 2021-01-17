using System.Collections.Generic;

namespace Inveon.Entities.Concrete.Dto
{
    public class UserDto
    {
        private List<RoleDto> _roles = new List<RoleDto>();
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<RoleDto> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
    }

}
