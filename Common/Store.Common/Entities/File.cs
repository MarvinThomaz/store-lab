using System.Collections.Generic;

namespace Store.Common.Entities
{
    public class File
    {
        public string Name { get; set; }
        public string Bucket { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
    }
}