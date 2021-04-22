using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace backend.Services
{
    public interface IBlobService
    {
        Task<Uri> UploadFileBlobAsync(Stream content, string contentType);
    }
}