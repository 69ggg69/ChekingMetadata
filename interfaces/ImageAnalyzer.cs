using System.Collections.Generic;
using MetadataExtractor;

namespace ChekingMetadata.interfaces
{
    public interface ImageAnalyzer
    {
        bool IsPhotoshopped(IEnumerable<Directory> directories);

    }
}
