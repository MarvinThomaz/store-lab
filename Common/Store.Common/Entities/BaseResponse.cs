using System.Collections.Generic;

namespace Store.Common.Entities
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public List<Info> Errors { get; set; }
    }
}
