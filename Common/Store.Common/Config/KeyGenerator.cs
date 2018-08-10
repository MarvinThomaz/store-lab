using System;
namespace Store.Common.Config
{
    public static class KeyGenerator
    {
        public static string New()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
