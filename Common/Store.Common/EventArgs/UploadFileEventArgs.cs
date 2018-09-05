using Store.Common.Entities;
using System;

namespace Store.Common.EventArgs
{
    public class UploadFileEventArgs
    {
        public Uri Uri { get; set; }
        public File File { get; set; }
    }
}
