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
					if (i != photos.Count() - 1)
					{
						dataBaseFileName += fileName+",";
					}
					else
					{
						dataBaseFileName += fileName;

                    }
                }
			}
			return dataBaseFileName;
		}
	}
}

