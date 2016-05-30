using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace MaxiKioscos.Mobile.Api
{
    public class NinjectServiceHelper
    {
        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get { return _kernel; }
            set { _kernel = value; }
        }
    }
}