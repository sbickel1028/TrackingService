using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.ErrorHandler
{
    public class ErrorHandlerAttribute : InterceptAttribute
    {
        #region Public Variables
        public bool rethrowError = false;
        #endregion

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<IErrorHandlerInterceptor>(new ConstructorArgument("rethrowError", rethrowError));
        }
    }
}
