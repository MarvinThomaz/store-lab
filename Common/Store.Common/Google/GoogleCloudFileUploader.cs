using Google.Cloud.Storage.V1;
using Store.Common.Delegates;
using Store.Common.EventArgs;
using Store.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Store.Common.Google
{
    public class GoogleCloudFileUploader : IFileUploader
    {
        private readonly StorageClient _client;

        public GoogleCloudFileUploader(StorageClient client)
        {
            _client = client;
        }

        public event UploadFileEventHandler FileUploaded;

        public async Task UploadAllAsync(IEnumerable<Entities.File> files)
        {
            var tasks = new List<Task>();

            foreach (var file in files)
            {
                tasks.Add(UploadAsync(file));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        public async Task UploadAsync(Entities.File file)
        {
            var imageObject = await _client.UploadObjectAsync(
                bucket: file.Bucket,
                objectName: file.Name,
                contentType: file.ContentType,
                source: new MemoryStream(file.Data)
            );

            var args = new UploadFileEventArgs { Uri = new Uri(imageObject.MediaLink), File = file };

            FileUploaded?.Invoke(this, args);
        }
    }
}
