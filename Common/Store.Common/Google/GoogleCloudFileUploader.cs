using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Delegates;
using Store.Common.Interfaces;

namespace Store.Common.Google
{
    public class GoogleCloudFileUploader : IFileUploader
    {
        public event UploadFileEventHandler FileUploaded;
        public event UploadAllFilesEventHandler FilesUploadeds;

        public Task UploadAllAsync(IEnumerable<byte[]> file)
        {
            throw new System.NotImplementedException();
        }

        public Task UploadAsync(byte[] file)
        {
            throw new System.NotImplementedException();
        }
    }
}
