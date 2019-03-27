using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Infrastructure
{
    public static class Utilities
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}
