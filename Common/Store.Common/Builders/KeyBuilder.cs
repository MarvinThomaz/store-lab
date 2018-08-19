using System;
namespace Store.Common.Builders
{
    public static class KeyBuilder
    {
        public static string Build()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
