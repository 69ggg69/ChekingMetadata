using System;
using System.Collections.Generic;
using MetadataExtractor;

namespace ChekingMetadata.realisationInterfaces
{
    public class Reading : ImageMetadataReader
    {
        ImageMetadataReader reader;
        public IEnumerable<Directory> ReadMetadata(string imagePath)
        {
            try
            {
                return reader.ReadMetadata(imagePath);
            }
            catch (ImageProcessingException ex)
            {
                Console.WriteLine($"Ошибка при чтении метаданных из {imagePath}: {ex.Message}");
                return null;
            }
        }
    }
}