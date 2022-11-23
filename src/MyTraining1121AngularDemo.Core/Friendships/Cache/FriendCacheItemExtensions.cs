using System.Collections.Generic;
using System.Linq;

namespace MyTraining1121AngularDemo.Friendships.Cache
{
    public static class FriendCacheItemExtensions
    {
        public static bool ContainsFriend(this List<FriendCacheItem> items, FriendCacheItem item)
        {
            return items.Any(f => f.FriendTenantId == item.FriendTenantId && f.FriendUserId == item.FriendUserId);
        }
    }
}
