namespace Tut.Entities
{
    public class Blog : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Owner { get; set; }
        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}