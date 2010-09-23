using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Data.Locks.Example
{
    public static class LockManager
    {
        private static List<LockItem> _lockedItems;

        static LockManager()
        {
            _lockedItems = new List<LockItem>();
        }

        public static bool IsLocked(BusinessBase obj)
        {
            var locksQuery = from l in _lockedItems
                             where l.ObjectType == obj.GetType()
                                   && l.ObjectId == obj.Id
                             select l;

            return (locksQuery.Count() > 0);
        }

        public static bool Lock(BusinessBase obj, string sessionId)
        {
            if (IsLocked(obj))
                return false;

            lock (_lockedItems) 
            {
                var lockItem = new LockItem 
                { 
                    ObjectType = obj.GetType(), 
                    ObjectId = obj.Id,
                    LockedAt = DateTime.Now,
                    SessionId = sessionId
                };

                _lockedItems.Add(lockItem);
                return true;
            }
        }

        public static void ReleaseLock(BusinessBase obj, string sessionId)
        {
            lock (_lockedItems)
            {
                var locksQuery = from l in _lockedItems
                                 where obj.GetType() == obj.GetType()
                                       && obj.Id == l.ObjectId
                                       && sessionId == l.SessionId
                                 select l;

                ReleaseLocks(_lockedItems);
            }
        }

        public static void ReleaseSessionLocks(string sessionId)
        {
            lock (_lockedItems)
            {
                var locksQuery = from l in _lockedItems
                                 where sessionId == l.SessionId
                                 select l;

                ReleaseLocks(locksQuery);
            }
        }

        public static void ReleaseExpiredLocks()
        {
            lock (_lockedItems)
            {
                var locksQuery = from l in _lockedItems
                                 where (DateTime.Now - l.LockedAt).TotalMinutes > 20
                                 select l;

                ReleaseLocks(locksQuery);
            }
        }

        public static void ReleaseAllLocks()
        {
            lock (_lockedItems)
            {
                _lockedItems.Clear();
            }
        }

        private static void ReleaseLocks(IEnumerable<LockItem> lockItems)
        {
            if (lockItems.Count() == 0)
                return;

            foreach (var lockItem in lockItems.ToList())
                _lockedItems.Remove(lockItem);
        }
    }
}