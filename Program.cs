using ChekingMetadata.realisationInterfaces;
using ChekingMetadata.interfaces;

namespace ChekingMetadata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\066gg\source\repos\ChekingMetadata\src\";

            ImageMetadataReader metadataReader = new Reading();
            ImageAnalyzer imageAnalyzer = new Analysis();
            ImageProcessor imageProcessor = new Processing(metadataReader, imageAnalyzer);

            imageProcessor.ProcessImages(folderPath);
        }
    }
}