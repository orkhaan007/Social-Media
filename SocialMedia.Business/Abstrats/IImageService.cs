using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Abstrats
{
    public interface IImageService
    {
        Task<string> SaveFile(IFormFile file, string folderName);
    }
}
