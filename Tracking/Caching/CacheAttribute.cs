using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using Ninject.Parameters;

namespace Tracking.Caching
{
    public class CacheAttribute : InterceptAttribute
    {
        #region Public Variables
        public string cacheKey = "";
        public int minutesToCache = 1440;
        public string group = "";
        public string subGroup = "";
        #endregion


        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<ICacheInterceptor>(
                new ConstructorArgument("cacheKey", cacheKey),
                new ConstructorArgument("minutesToCache", minutesToCache),
                new ConstructorArgument("group", group),
                new ConstructorArgument("subGroup", subGroup)
            );
        }
    }
}
