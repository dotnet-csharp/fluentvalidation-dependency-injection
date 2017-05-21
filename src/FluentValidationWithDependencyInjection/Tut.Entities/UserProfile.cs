using System.Collections.Generic;

namespace Tut.Entities
{
    public class UserProfile : AuditableEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Blog> Blog { get; set; }
    }
}