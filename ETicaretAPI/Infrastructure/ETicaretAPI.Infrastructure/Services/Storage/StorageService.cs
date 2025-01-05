using ETicaretAPI.Application.Abstraction.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class StorageService :IStorageService
    {
        public string StorageName
        {
            get => this.GetType().Name;
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            //Silme prosesi,meselen bir fayli mueyyen bir yol ve ya conatinerden silmek sekilinde gerceklesdirile biler
            
            string filePath = Path.Combine(pathOrContainerName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"File {fileName} deleted from {pathOrContainerName}");
            }
            else
            {
                Console.WriteLine($"File {fileName} not found in {pathOrContainerName}");
            }

            await Task.CompletedTask;
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            //Mueyyen edilmis qovlugdan butun fayllari listeleme prosesi
          
            if (Directory.Exists(pathOrContainerName))
            {
                var files = Directory.GetFiles(pathOrContainerName).Select(Path.GetFileName).ToList();
                Console.WriteLine($"Listing files in {pathOrContainerName}");
                return files;
            }
            else
            {
                Console.WriteLine($"Directory {pathOrContainerName} not found.");
                return new List<string>();
            }
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            //Muyyen edilmis faylin var olub olmadigi kontrol etmek
            string filePath = Path.Combine(pathOrContainerName, fileName);

            bool exists = File.Exists(filePath);
            Console.WriteLine($"Checking if {fileName} exists in {pathOrContainerName}: {exists}");

            return exists;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            //faylin mueyyen qovluga yuklenmesi prosesi
            var result = new List<(string fileName, string pathOrContainerName)>();

            if (!Directory.Exists(pathOrContainerName))
            {
                Directory.CreateDirectory(pathOrContainerName); // Klasör yoksa oluştur
            }

            foreach (var file in files)
            {
                var filePath = Path.Combine(pathOrContainerName, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream); // Dosyayı kopyala
                }

                result.Add((file.FileName, pathOrContainerName));
                Console.WriteLine($"Uploaded file {file.FileName} to {pathOrContainerName}");
            }

            return await Task.FromResult(result);
        }

    }
}
