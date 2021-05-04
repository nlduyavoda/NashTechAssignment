using backend.Services;
using Moq;

namespace backend_test.Controller
{
    public static class BlobServiceMock
    {

        public static IBlobService BlobService()
        {
            var BlobService = Mock.Of<IBlobService>();

            return BlobService;
        }
    }
}