using Inveon.Entities.DbObjects;
using System.Collections.Generic;

namespace Inveon.Entities.Concrete
{
    public class Role : DbObjectAudit<short>
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
