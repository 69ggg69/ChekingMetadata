using ChekingMetadata.interfaces;
using System;
using System.IO;
using System.Linq;

namespace ChekingMetadata.realisationInterfaces
{
    public class Processing : ImageProcessor
    {
        private readonly ImageMetadataReader _metadataReader;
        private readonly ImageAnalyzer _imageAnalyzer;

        public Processing(ImageMetadataReader metadataReader, ImageAnalyzer imageAnalyzer)
        {
            _metadataReader = metadataReader;
            _imageAnalyzer = imageAnalyzer;
        }

        public void ProcessImages(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Указанная папка не существует");
                return;
            }

            string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                                      .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                                      .ToArray();

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("В указанной папке нет изображений");
                return;
            }

            foreach (var imagePath in imageFiles)
            {
                try
                {
                    var directories = _metadataReader.ReadMetadata(imagePath);
                    bool isPhotoshopped = _imageAnalyzer.IsPhotoshopped(directories);

                    if (isPhotoshopped)
                    {
                        Console.WriteLine($"{imagePath} Изображение было редактировано с помощью Photoshop.");
                    }
                    else
                    {
                        Console.WriteLine($"{imagePath} Признаков редактирования с помощью Photoshop не обнаружено.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при анализе изображения {imagePath}: {ex.Message}");
                }
            }
        }
    }
}
