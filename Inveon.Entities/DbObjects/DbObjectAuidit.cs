using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inveon.Entities.DbObjects
{
    public abstract class DbObjectAudit<T> : DbObject<T>
    {
        public DateTimeOffset CreatedDate { get; set; }
        [NotMapped]
        public DateTimeOffset? ModifiedDate { get; set; }
        public int Creator { get; set; }
        [NotMapped]
        public int? Modifier { get; set; }
    }
}
