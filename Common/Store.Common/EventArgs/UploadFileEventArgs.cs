using Store.Common.Entities;

namespace Store.Common.EventArgs
{
    public class UploadFileEventArgs
    {
        public ResponseFile Response { get; set; }
        public RequestFile Request { get; set; }
    }
}
