using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APoffice
{
    internal static class SequentialGuidGenerator
    {
        public static Guid CreateGuid()
        {
            Guid guid;
            int result = NativeMethods.UuidCreateSequential(out guid);
            if (result == 0)
            {
                var bytes = guid.ToByteArray();
                var  indexes = new int[] { 3, 2, 1, 0, 5, 4, 7, 6, 8, 9, 10, 11, 12, 13, 14, 15 };
                return new Guid(indexes.Select(x=>bytes[x]).ToArray());
            }
            throw new Exception("Error of generation sequential GUID (on client side)");

        }
    }

    internal static class NativeMethods
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        public static extern int UuidCreateSequential(out Guid guid);
    }
}
