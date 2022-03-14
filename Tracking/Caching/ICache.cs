using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Caching
{
    public interface ICache
    {
        /// <summary>
        /// Get an object from the cache
        /// </summary>
        /// <param name="cacheKey">The key of the cached item</param>
        /// <returns>A cached object, or null if not found</returns>
        object Get(string cacheKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="group"></param>
        /// <param name="subGroup"></param>
        /// <param name="cacheObject"></param>
        /// <param name="expires"></param>
        void Add(string cacheKey, string group, string subGroup, object cacheObject, DateTime expires);

        /// <summary>
        /// Remove a single key from the cache
        /// </summary>
        /// <param name="cacheKey">Key of the object to remove</param>
        /// <returns>The object it just removed</returns>
        object Remove(string cacheKey);

        /// <summary>
        /// Remove all matching objects from the cache
        /// </summary>
        /// <param name="group">Group to remove</param>
        /// <param name="subGroup">Subgroup to Remove</param>
        void RemoveGroupData(string group, string subGroup);

        /// <summary>
        /// Remove all objects from the cache
        /// </summary>
        void RemoveAll();

        List<processedItemCache> GetCacheKeys();

        bool CachePing();
    }

    public class processedItemCache
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string Key { get; set; }
        public long sizeOfData { get; set; }
    }
}
