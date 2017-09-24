using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    /// <summary>
    /// 两张图
    /// </summary>
    public class DoubleImageStrategy : IimageResizeStrategy
    {

        public DoubleImageStrategy(IEnumerable<String> files, String imageTemplate)
        {
            this.TempImage = imageTemplate;
            this.ImagePaths = files;

        }
        public DoubleImageStrategy()
        {
  

        }
        public string TempImage
        {
            get;
            set;
        }


        public IEnumerable<string> ImagePaths
        {
            get;
            set;
        }
        public List<List<AvactorInfo>> GetImageSize()
        {
            List<List<AvactorInfo>> list = new List<List<AvactorInfo>>();


            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 41, IsResize = true } });

            List<AvactorInfo> avators = new List<AvactorInfo>();
            AvactorInfo width = new AvactorInfo { FilePath = TempImage, Width = 2, Heigh = 75, IsResize = true };
            avators.Add(width);
            avators.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(0), Width = 75, Heigh = 75, IsResize = false });
            avators.Add(width);
            avators.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(1), Width = 75, Heigh = 75, IsResize = false });
            avators.Add(width);
            list.Add(avators);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 41, IsResize = true } });
            return list;
        }


    }
}
