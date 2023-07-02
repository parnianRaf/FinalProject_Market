using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Service
{
	public class ImageService: IImageService
    {
		private readonly IHostingEnvironment _hostingEnviroment;

        public ImageService(IHostingEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;
        }


        public string GetFilePath(string name,List<IFormFile>? photos)
		{
			string dataBaseFileName = "";
			if(photos!=null && photos.Count()>1)
			{
				for(int i=0;i<photos.Count();i++)
				{
                    string uploadDir = Path.Combine(_hostingEnviroment.WebRootPath, "images");
                    string fileName = name + "_" + i.ToString() + photos[i].FileName;
					string filePath = Path.Combine(uploadDir, fileName);
					photos[i].CopyTo(new FileStream(filePath, FileMode.Create));
                    dataBaseFileName+= i != photos.Count() - 1 ? fileName +"," : fileName; 
                }
			}
			return dataBaseFileName;
		}

        public string GetFilePath(string name, IFormFile? photo)
        {

            string fileName = "";
            if (photo != null && photo.Length> 0)
            {
                string uploadDir = Path.Combine(_hostingEnviroment.WebRootPath, "images", "UserImages");
                fileName = name + Path.GetExtension(photo.FileName);
                string dataBaseFileName = Path.Combine(uploadDir, fileName);
                if (File.Exists(dataBaseFileName))
                {
                    File.Delete(dataBaseFileName);
                }
                photo.CopyTo(new FileStream(dataBaseFileName, FileMode.Create));
            }
            return fileName;
        }
    }
}

