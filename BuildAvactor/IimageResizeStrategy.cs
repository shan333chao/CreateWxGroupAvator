using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
   public interface IimageResizeStrategy
   {
 
       List<List<AvactorInfo>> GetImageSize();

        String TempImage{get;set;}

        IEnumerable<String> ImagePaths { get; set; }
       


   }
}
