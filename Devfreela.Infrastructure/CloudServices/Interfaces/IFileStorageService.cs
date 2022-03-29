namespace Devfreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);

    }
}
