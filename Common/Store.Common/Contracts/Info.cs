using System;
using Store.Common.Enums;
using Store.Common.Utils;

namespace Store.Common.Contracts
{
    public class Info
    {
        public Info() { }

        public Info(InfoType type, string property)
        {
            Property = property;
            Code = (int) type;
            Message = InfoTypeUtils.GetMessage(type);
        }

        public string Property { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
