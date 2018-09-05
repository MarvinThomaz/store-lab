using Store.Common.Delegates;
using Store.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Common.Interfaces
{
    public interface IFileUploader
    {
        event UploadFileEventHandler FileUploaded;

        Task UploadAsync(File file);
        Task UploadAllAsync(IEnumerable<File> file);
    }
}