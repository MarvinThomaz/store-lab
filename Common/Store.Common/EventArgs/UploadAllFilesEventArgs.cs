using System;
using System.Collections.Generic;

namespace Store.Common.EventArgs
{
    public class UploadAllFilesEventArgs
    {
        public IEnumerable<Uri> Uris { get; set; }
    }
}
