using Inveon.Entities.DbObjects;
using System.Collections.Generic;

namespace Inveon.Entities.Concrete
{
    public class User : DbObjectAudit<long>
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
