using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Logic
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks a argument for being null.
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <param name="argName">The name of the object.</param>
        public static void CheckArgument(this object source, string argName)
        {
            if (source == null)
                throw new ArgumentNullException(argName);
        }
    }
}
