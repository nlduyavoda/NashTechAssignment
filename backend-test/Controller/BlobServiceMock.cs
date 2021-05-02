using backend.Services;
using Moq;

namespace backend_test.Controller
{
    public static class BlobServiceMock
    {

        public static IBlobService FilesService()
        {
            var filesService = Mock.Of<IBlobService>();

            return filesService;
        }
    }
}