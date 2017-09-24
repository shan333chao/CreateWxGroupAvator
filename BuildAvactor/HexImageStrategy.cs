using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    /// <summary>
    /// 六张图
    /// </summary>
    public class HexImageStrategy : IimageResizeStrategy
    {
        public HexImageStrategy()
        {
        }
        public HexImageStrategy(IEnumerable<String> files, String imageTemplate)
        {
            this.TempImage = imageTemplate;
            this.ImagePaths = files;

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


            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 28, IsResize = true } });

            List<AvactorInfo> floor1 = new List<AvactorInfo>();

            AvactorInfo commonwidth = new AvactorInfo { FilePath = TempImage, Width = 2, Heigh = 50, IsResize = true };
            floor1.Add(commonwidth);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.First(), Width = 50, Heigh = 50, IsResize = false });
            floor1.Add(commonwidth);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(1), Width = 50, Heigh = 50, IsResize = false });
            floor1.Add(commonwidth);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(2), Width = 50, Heigh = 50, IsResize = false });
            floor1.Add(commonwidth);
            list.Add(floor1);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor2 = new List<AvactorInfo>();
            floor2.Add(commonwidth);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(3), Width = 50, Heigh = 50, IsResize = false });
            floor2.Add(commonwidth);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(4), Width = 50, Heigh = 50, IsResize = false });
            floor2.Add(commonwidth);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(5), Width = 50, Heigh = 50, IsResize = false });
            floor2.Add(commonwidth);
            list.Add(floor2);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 28, IsResize = true } });
            return list;
        }




     
    }
}
