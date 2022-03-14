using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.ErrorHandler;

namespace Tracking.Caching
{
    public class CacheInterceptor : ICacheInterceptor
    {
        #region Private Variables

        private string cacheKey = "";
        private int minutesToCache = 1440;
        private string group = "";
        private string subGroup = "";
        private ICache cache = null;

        #endregion

        #region Constructors

        public CacheInterceptor(ICache cache, string cacheKey, int minutesToCache, string group, string subGroup)
        {
            this.cache = cache;
            this.cacheKey = cacheKey;
            this.minutesToCache = minutesToCache;
            this.group = group;
            this.subGroup = subGroup;
        }

        #endregion

        #region IInterceptor Members

        [ErrorHandler(rethrowError = true)]
        public void Intercept(IInvocation invocation)
        {
            object cachedValue = null;
            string prefixcacheKey = null;

            if (string.IsNullOrEmpty(cacheKey))
            {
                try
                {
                    prefixcacheKey = invocation.Request.Method.DeclaringType.GenericTypeArguments[0].Name;
                }
                catch { }

                if (prefixcacheKey == null)
                    prefixcacheKey = invocation.Request.Method.DeclaringType.FullName;

                cacheKey = prefixcacheKey + "|" + invocation.Request.Method.Name;
            }

            if (string.IsNullOrEmpty(cacheKey))
                cacheKey = invocation.Request.Method.DeclaringType.GenericTypeArguments[0].Name + "|" + invocation.Request.Method.Name;   //invocation.Request.Method.DeclaringType.Name + "|" + 

            // Add arguments to the cacheKey
            if (invocation.Request.Arguments.Length > 0)
                cacheKey += "_" + Newtonsoft.Json.JsonConvert.SerializeObject(invocation.Request.Arguments);

            if (!Cache.isFailed && Cache.cache != null)
            {
                // Attempt to retrieve it from the cache
                cachedValue = cache.Get(cacheKey);
            }

            // Cache Miss
            if (cachedValue == null)
            {
                // Call the underlying function to get the cached value
                invocation.Proceed();

                // Store the result in the cache                
                if (invocation.ReturnValue != null && !Cache.isFailed && Cache.cache != null)
                    cache.Add(cacheKey, group, subGroup, invocation.ReturnValue, DateTime.Now.AddMinutes(this.minutesToCache));
            }
            // Cache Hit
            else
            {
                invocation.ReturnValue = cachedValue;
            }
        }

        #endregion
    }
}
