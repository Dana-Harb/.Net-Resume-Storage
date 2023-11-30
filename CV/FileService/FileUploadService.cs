namespace CV.FileService
{
    public class FileUploadService : IFileUploadService
    {
        public readonly IHostEnvironment e;

        public FileUploadService( IHostEnvironment e)
        {
            this.e = e;
        }

        public async Task<string> UploadPhoto(IFormFile file)
        {
            var filePath = Path.Combine(e.ContentRootPath,@"wwwroot/images",file.FileName);
            var returnFile = Path.Combine("images", file.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return returnFile;
        }

    }
}
