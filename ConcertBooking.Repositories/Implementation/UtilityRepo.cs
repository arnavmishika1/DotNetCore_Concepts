using ConcertBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConcertBooking.Repositories.Implementation
{
    public class UtilityRepo : IUtilityRepo
    {
        // for IWebHostEnvironment interface
        // will not pick this and also we will not be able to install it from here,
        // because we are using Class Liberary project
        // Solution: Go to .csproj file of this project and add FrameworkReference
        /*
         <ItemGroup>
		    <FrameworkReference Include="Microsoft.AspNetCore.App" />
	    </ItemGroup>
         */
        private IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _contextAccessor;

        public UtilityRepo(IWebHostEnvironment env, 
            IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if(string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath, ContainerName, fileName);
            if(File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        // Easy way is to delete exited and store refreshed file
        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, file);
        }

        // Guid.NewGuid()// a random Processor based string generated, so that same image name can be different
        // Ex: yuiso-duy90-jik23-opik
        // base path:https://localhost:7164/ContainerName/yuiso-duy90-jik23-opik.jpg
        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
            // get extension first:
            var extension = Path.GetExtension(file.FileName); // .jpg
            // will become "yuiso-duy90-jik23-opik.jpg"
            var fileName = $"{Guid.NewGuid()}{extension}";
            // We need to create a folder in wwwroot folder(WebRootPath)
            // For this we need to IWebHostEnvironment interface
            string folder = Path.Combine(_env.WebRootPath, ContainerName);
            // check if folder exists
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, fileName);

            // In this path we need to store image 
            using(var memoryStream = new MemoryStream())
            {
                // converted to byte
                await file.CopyToAsync(memoryStream);
                // now need to convert into array
                var content = memoryStream.ToArray();

                await File.WriteAllBytesAsync(filePath, content);
            }
            // Now need to get scheme(https) and host(localhost:5000)
            // (Get through IHttpContextAccessor) 
            var basePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";

            // "\\" (Backward slash) will be replaced with forward slash(/)
            var completePath = Path.Combine(basePath, ContainerName, fileName).Replace("\\", "/");

            return completePath;
        }
    }
}
