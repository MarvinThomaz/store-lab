using Google.Cloud.Storage.V1;
using Store.Common.Delegates;
using Store.Common.Entities;
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

        //public GoogleCloudFileUploader(StorageClient client)
        //{
        //    _client = client;
        //}

        public event UploadFileEventHandler FileUploaded;

        public async Task UploadAllAsync(IEnumerable<Entities.RequestFile> files)
        {
            if (files == null)
                return;

            var tasks = new List<Task>();

            foreach (var file in files)
            {
                tasks.Add(UploadAsync(file));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        public async Task UploadAsync(Entities.RequestFile file)
        {
            //var imageObject = await _client.UploadObjectAsync(
            //    bucket: file.Bucket,
            //    objectName: file.Name,
            //    contentType: file.ContentType,
            //    source: new MemoryStream(file.Data)
            //);

            var response = new ResponseFile { Name = file.Name/*, Uri = new Uri(imageObject.MediaLink)*/ };
            var args = new UploadFileEventArgs { Response = response, Request = file };

            FileUploaded?.Invoke(this, args);
        }
    }
}
