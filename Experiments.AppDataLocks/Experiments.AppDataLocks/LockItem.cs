using System;

namespace Application.Data.Locks.Example
{
    public class LockItem
    {
        public Type ObjectType { get; set; }
        public int ObjectId { get; set; }
        public string SessionId { get; set; }
        public DateTime LockedAt { get; set; }
    }
}