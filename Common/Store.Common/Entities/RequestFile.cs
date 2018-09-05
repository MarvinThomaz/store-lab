using Store.Common.Attributes;
using System.Collections.Generic;

namespace Store.Common.Entities
{
    public class RequestFile
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Bucket { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public IDictionary<string, string> Metadata { get; set; }
    }
}