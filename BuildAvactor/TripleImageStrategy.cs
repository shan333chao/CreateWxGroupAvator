using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
    /// <summary>
    /// 三张图
    /// </summary>
    public class TripleImageStrategy : IimageResizeStrategy
    {


        public TripleImageStrategy(IEnumerable<String> files,String imageTemplate)
        {
            this.TempImage = imageTemplate;
            this.ImagePaths = files;

        }

        public TripleImageStrategy()
        {
    

        }

        public List<List<AvactorInfo>> GetImageSize()
        {
            List<List<AvactorInfo>> list = new List<List<AvactorInfo>>();


            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor1 = new List<AvactorInfo>();
            AvactorInfo width = new AvactorInfo { FilePath = TempImage, Width = 41, Heigh = 75, IsResize = false };
            floor1.Add(width);
            floor1.Add(new AvactorInfo { FilePath = ImagePaths.First(), Width = 75, Heigh = 75, IsResize = false });
            floor1.Add(width);
            list.Add(floor1); 

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });

            List<AvactorInfo> floor2 = new List<AvactorInfo>();
            AvactorInfo width2 = new AvactorInfo { FilePath = TempImage, Width = 2, Heigh = 75, IsResize = true };
            floor2.Add(width2);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(1), Width = 75, Heigh = 75, IsResize = false });
            floor2.Add(width2);
            floor2.Add(new AvactorInfo { FilePath = ImagePaths.ElementAt(2), Width = 75, Heigh = 75, IsResize = false });
            floor2.Add(width2);
            list.Add(floor2);

            list.Add(new List<AvactorInfo>() { new AvactorInfo { FilePath = TempImage, Width = 158, Heigh = 2, IsResize = true } });
            return list;
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
    }
}
