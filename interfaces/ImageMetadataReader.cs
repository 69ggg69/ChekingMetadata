using System.Collections.Generic;
using MetadataExtractor;

namespace ChekingMetadata
{
    public interface ImageMetadataReader
    {
        IEnumerable<Directory> ReadMetadata(string imagePath);
    }

}

