using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.Ninject
{
    public static class BindingExtensions
    {
        public static void BindToMethod<T>(this IKernel kernel, Func<T> method)
        {
            kernel.Bind<T>().ToMethod(c => method());
        }
    }
}
