using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    public class OctoImageStrategy : IimageResizeStrategy
    {
        public OctoImageStrategy()
        {
 

        }

        public OctoImageStrategy(IEnumerable<String> ImagePaths, String imageTemplate)
        {
            this.TempImage = imageTemplate;
            this.ImagePaths = ImagePaths;

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


            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

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



            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor3 = new List<AvactorInfo>();
            floor3.Add(commonwidth);
            floor3.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(6), Width = 50, Heigh = 50, IsResize = false });
            floor3.Add(commonwidth);
            floor3.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(7), Width = 50, Heigh = 50, IsResize = false });
            floor3.Add(commonwidth);
            floor3.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(8), Width = 50, Heigh = 50, IsResize = false });
            floor3.Add(commonwidth);
            list.Add(floor3);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

            return list;
        }


    }
}
