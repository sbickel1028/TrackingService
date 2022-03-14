using Alachisoft.NCache.Web.Caching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Logging;

namespace Tracking.Caching
{
    public class Cache : ICache, IDisposable
    {
        #region Private Variables
        public static Alachisoft.NCache.Web.Caching.Cache cache;
        private static bool isReported = false;
        public static bool isFailed = false;
        private static DateTime? lastCheckTime = null;
        private string eventSource = "DMXncache";
        private string eventApp = "ServicePackage";
        public static ILog _log;
        #endregion

        #region Constructors
        public Cache()
        {
            try
            {
                cache = null;
                cache = cacheConnection();
            }
            catch { }
        }

        ~Cache()
        {
            //Issue with Ninject trying to dispose common calls everytime.
            if (cache != null)
            {
                cache.Dispose();
                cache = null;
            }
            //isFailed = false;
            //lastCheckTime = null;
        }

        public void OnCacheStopped(string cacheId)
        {
            createEventLogEntry("Cache Stopped " + cacheId);
            Dispose();
        }
        #endregion

        #region ICache Members

        public object Get(string cacheKey)
        {
            object result = null;

            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                try
                {
                    result = cache.Get(cacheKey);
                }
                catch { }
            }

            return result;
        }

        public void Add(string cacheKey, string group, string subGroup, object cacheObject, DateTime expires)
        {
            if (string.IsNullOrEmpty(cacheKey)) return;
            if (cacheObject == null) return;
            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                try
                {
                    CacheItem cacheItem = new CacheItem(cacheObject);
                    if (!string.IsNullOrEmpty(group)) cacheItem.Group = group;
                    if (!string.IsNullOrEmpty(subGroup)) cacheItem.SubGroup = subGroup;
                    cacheItem.AbsoluteExpiration = expires;

                    if (!cache.Contains(cacheKey))
                    {
                        cache.Add(cacheKey, cacheItem);
                    }
                    else
                    {
                        cache.Remove(cacheKey);
                        cache.Add(cacheKey, cacheItem);
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("Cache Info in Core under Add", ex);
                }
            }
        }

        public object Remove(string cacheKey)
        {
            object result = null;

            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                try
                {
                    LockHandle lockHandle = new LockHandle();
                    result = cache.Remove(cacheKey, lockHandle);
                    cache.Unlock(cacheKey, lockHandle);
                }
                catch
                {
                    isFailed = true;
                    lastCheckTime = DateTime.Now;
                    Dispose();
                }
            }
            return result;
        }

        public void RemoveGroupData(string group, string subGroup)
        {
            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                try
                {
                    cache.RemoveGroupData(group, subGroup);
                }
                catch
                {
                    isFailed = true;
                    lastCheckTime = DateTime.Now;
                    Dispose();
                }
            }
        }

        public void RemoveAll()
        {
            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                try
                {
                    cache.Clear();
                }
                catch
                {
                    isFailed = true;
                    lastCheckTime = DateTime.Now;
                    Dispose();
                }
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (cache != null)
            {
                cache.Dispose();
                cache = null;
            }
        }

        private void createEventLogEntry(string logEvent)
        {
            try
            {
                if (!EventLog.SourceExists(eventSource))
                    EventLog.CreateEventSource(eventSource, eventApp);

                EventLog _eventLog = new System.Diagnostics.EventLog() { Source = eventSource, Log = eventApp };
                _eventLog.WriteEntry(logEvent, EventLogEntryType.Warning);
            }
            catch { }
        }

        public bool CachePing()
        {
            bool result = false;

            if (cache == null) cache = cacheConnection();

            if (cache != null)
            {
                result = true;
            }

            return result;
        }

        private Alachisoft.NCache.Web.Caching.Cache cacheConnection()
        {
            Alachisoft.NCache.Web.Caching.Cache _CacheNode = null;
            string _cacheName = ConfigurationManager.AppSettings["CacheName"];
            bool useNCache = string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseNCache"]) ? false : ConfigurationManager.AppSettings["UseNCache"].ToUpper() == "TRUE";

            if (useNCache)
            {
                if (isFailed && lastCheckTime.HasValue && lastCheckTime.Value.AddMinutes(5) > DateTime.Now)
                {
                    return _CacheNode;
                }
                else
                {
                    lastCheckTime = null;
                    isFailed = false;
                }

                try
                {
                    var initParam = new CacheInitParams();

                    initParam.RetryInterval = 1;
                    initParam.ConnectionRetries = 5;
                    initParam.ConnectionTimeout = 5;
                    initParam.ClientCacheSyncMode = ClientCacheSyncMode.Optimistic;
                    initParam.LoadBalance = true;
                    initParam.RetryConnectionDelay = 0;
                    initParam.ClientRequestTimeOut = 60;

                    _CacheNode = NCache.InitializeCache(_cacheName, initParam);
                    _CacheNode.ExceptionsEnabled = true;

                    if (!isReported && cache != null)
                    {
                        createEventLogEntry("NCACHE is on using " + _cacheName);
                        isReported = true;
                    }
                }
                catch (Exception ex)
                {
                    if (!isReported)
                    {
                        LogMessage("Cache Failure in Core connection " + _cacheName, ex);
                        createEventLogEntry("Cache Failure in Core with " + _cacheName);
                    }
                    isFailed = true;
                    lastCheckTime = DateTime.Now;
                    Dispose();
                }
            }

            if (_CacheNode == null)
            {
                isFailed = true;
                lastCheckTime = DateTime.Now;
            }
            return _CacheNode;
        }

        private Alachisoft.NCache.Web.Caching.Cache cacheConnection_long()
        {
            Alachisoft.NCache.Web.Caching.Cache _CacheNode = null;
            bool useNCache = string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseNCache"]) ? false : ConfigurationManager.AppSettings["UseNCache"].ToUpper() == "TRUE";

            if (useNCache)
            {
                try
                {
                    var initParam = new CacheInitParams();
                    string _cacheName = ConfigurationManager.AppSettings["CacheName"];


                    initParam.RetryInterval = 1;
                    initParam.ConnectionRetries = 5;
                    initParam.ConnectionTimeout = 60000;
                    initParam.ClientCacheSyncMode = ClientCacheSyncMode.Optimistic;
                    initParam.LoadBalance = true;
                    initParam.RetryConnectionDelay = 0;
                    initParam.ClientRequestTimeOut = 60000;

                    _CacheNode = NCache.InitializeCache(_cacheName, initParam);
                }
                catch { }
            }

            if (_CacheNode == null)
            {
                isFailed = true;
                lastCheckTime = DateTime.Now;
            }

            return _CacheNode;
        }

        public List<processedItemCache> GetCacheKeys()
        {
            List<processedItemCache> EntireCache_Keys = new List<processedItemCache>();
            try
            {
                CacheItem cItem = null;
                Alachisoft.NCache.Web.Caching.Cache _CacheNode = cacheConnection_long();

                if (_CacheNode != null)
                {
                    foreach (System.Collections.DictionaryEntry key in _CacheNode)
                    {
                        var _ItemCache = new processedItemCache();

                        _ItemCache.Key = key.Key.ToString();
                        _ItemCache.sizeOfData = 0;
                        try
                        {
                            IEnumerable en = (IEnumerable)key.Value;
                            byte[] myBytes = en.OfType<byte>().ToArray();
                            _ItemCache.sizeOfData = myBytes.Length;
                        }
                        catch { }

                        cItem = _CacheNode.GetCacheItem(key.Key.ToString());

                        _ItemCache.CreationDate = cItem.CreationTime;
                        _ItemCache.ExpirationDate = cItem.AbsoluteExpiration;
                        _ItemCache.Group = cItem.Group;
                        _ItemCache.SubGroup = cItem.SubGroup;

                        EntireCache_Keys.Add(_ItemCache);
                    }
                }
                _CacheNode.Dispose();
            }
            catch { }
            return EntireCache_Keys;
        }

        protected void LogMessage(string message, Exception exception)
        {
            try
            {
                
                if (_log == null) _log = new Tracking.Logging.Log();

                if (_log != null)
                {
                    _log.Debug(message, exception);
                }
            }
            catch { }
        }
        #endregion
    }
}
