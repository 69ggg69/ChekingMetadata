using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MetadataExtractor;

namespace ChekingMetadata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\066gg\source\repos\ChekingMetadata\src\";

            if (!System.IO.Directory.Exists(folderPath))
            {
                Console.WriteLine("Указанная папка не существует");
                return;
            }

            string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var imageFiles = System.IO.Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
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

                    IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(imagePath);

                    bool isPhotoshopped = false;

                    foreach (var directory in directories)
                    {
                        foreach (var tag in directory.Tags)
                        {

                            if (tag.Name.ToLower().Contains("software") && tag.Description.ToLower().Contains("photoshop"))
                            {
                                isPhotoshopped = true;
                            }

                            if (tag.Name.ToLower().Contains("photoshop"))
                            {
                                isPhotoshopped = true;
                            }
                        }
                    }

                    if (isPhotoshopped)
                    {
                        Console.WriteLine(imagePath + " " + "Изображение было редактировано с помощью Photoshop.");
                    }
                    else
                    {
                        Console.WriteLine(imagePath + " " + "Признаков редактирования с помощью Photoshop не обнаружено.");
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