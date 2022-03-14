using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Logging;

namespace Tracking.ErrorHandler
{
    public class ErrorHandlerInterceptor : IErrorHandlerInterceptor
    {
        #region Private Variables
        private bool rethrowError = false;
        private ILog log = null;
        #endregion

        #region Constructors

        public ErrorHandlerInterceptor(ILog log, bool rethrowError)
        {
            this.log = log;
            this.rethrowError = rethrowError;
        }

        #endregion

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                // Send default return value for value types so it doesn't puke.
                Type t = invocation.Request.Method.ReturnType;
                if (t.IsValueType && t.Name != "Void") invocation.ReturnValue = Activator.CreateInstance(t);

                log.Error(ex.GetType().Name, ex);
                if (rethrowError) throw;
            }
        }

        #endregion
    }
}
