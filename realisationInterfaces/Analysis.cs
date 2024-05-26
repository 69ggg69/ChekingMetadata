using System.Collections.Generic;
using ChekingMetadata.interfaces;
using MetadataExtractor;

namespace ChekingMetadata.realisationInterfaces
{
    public class Analysis : ImageAnalyzer
    {
        public bool IsPhotoshopped(IEnumerable<Directory> directories)
        {
            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name.ToLower().Contains("software") && tag.Description.ToLower().Contains("photoshop"))
                    {
                        return true;
                    }

                    if (tag.Name.ToLower().Contains("photoshop"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
    
