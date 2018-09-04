using Store.Common.Delegates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Common.Interfaces
{
    public interface IFileUploader
    {
        event UploadFileEventHandler FileUploaded;
        event UploadAllFilesEventHandler FilesUploadeds;

        Task UploadAsync(byte[] file);
        Task UploadAllAsync(IEnumerable<byte[]> file);
    }
}