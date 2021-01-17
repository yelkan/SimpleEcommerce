using System.Collections.Generic;
using System.Linq;

namespace Inveon.Core.Common.Extensions
{
    public static class Extension
    {
        public static bool IsNotNullAndAny<T>(this IList<T> source)
        {
            if (source != null && source.FirstOrDefault() != null && source.Any())
                return true;

            return false;
        }
    }
}
