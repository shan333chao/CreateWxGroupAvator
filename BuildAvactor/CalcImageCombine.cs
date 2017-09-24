using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    public class CalcImageCombine
    {
 

        public IimageResizeStrategy imageStrategy { get; set; }

        private IEnumerable<String> fileUrl { get; set; }

        private String templateImg { get; set; }

        public CalcImageCombine(IimageResizeStrategy strategy,IEnumerable<String> fileUrl,String templateImg)
        {

      
            this.imageStrategy = strategy;
            this.fileUrl = fileUrl; 
            this.templateImg = templateImg;

        }
        public CalcImageCombine(IEnumerable<String> fileUrl, String templateImg)
        {


 
            this.fileUrl = fileUrl;
            this.templateImg = templateImg;

        }

        public List<List<AvactorInfo>> getImages() {
            try
            {
                imageStrategy.ImagePaths = fileUrl;
                imageStrategy.TempImage = templateImg;
              return  imageStrategy.GetImageSize();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        
        }

    }
}
