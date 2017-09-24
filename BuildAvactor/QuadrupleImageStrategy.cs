using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    public class QuadrupleImageStrategy : IimageResizeStrategy
    {


        public QuadrupleImageStrategy(IEnumerable<String> files, String imageTemplate)
        {
            this.TempImage = imageTemplate;
            this.ImagePaths = files;

        }

        public QuadrupleImageStrategy()
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


            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 156, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor1 = new List<AvactorInfo>();
            AvactorInfo width = new AvactorInfo { FilePath = TempImage, Width = 2, Heigh = 75, IsResize = true };
            floor1.Add(width);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.First(), Width = 75, Heigh = 75, IsResize = false });
            floor1.Add(width);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(1), Width = 75, Heigh = 75, IsResize = false });
            floor1.Add(width);
            list.Add(floor1);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 156, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor2 = new List<AvactorInfo>();
            floor2.Add(width);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(2), Width = 75, Heigh = 75, IsResize = false });
            floor2.Add(width);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(3), Width = 75, Heigh = 75, IsResize = false });
            floor2.Add(width);
            list.Add(floor2);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 156, Heigh = 2, IsResize = true } });
            return list;
        }


    }
}
