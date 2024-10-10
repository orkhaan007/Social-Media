using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using SocialMedia.Business.Abstrats;
using Microsoft.AspNetCore.Http;

namespace SocialMedia.Business.Concretes
{
    public class ImagesService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImagesService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> SaveFile(IFormFile file, string folderName)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Folder = folderName,
                    PublicId = fileName
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                return uploadResult.Uri.ToString();
            }

            return null;
        }
    }
}
