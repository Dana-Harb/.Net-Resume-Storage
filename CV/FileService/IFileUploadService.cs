namespace CV.FileService
{
   
    public interface IFileUploadService
    {
        Task<string> UploadPhoto(IFormFile image);

    }
}
