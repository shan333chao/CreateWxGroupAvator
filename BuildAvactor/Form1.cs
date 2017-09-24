using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using System.IO;
using System.Threading;
using System.Configuration;
namespace BuildAvactor
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// 拼接后的存放的目录
        /// 编译后运行时 需要将templateFolder  复制到bin中
        /// </summary>
        private static String TempFolder = System.IO.Directory.GetCurrentDirectory();
        /// <summary>
        /// 需要拼接的图片文件目录 在appconfig中配置 自己需要拼接的图片目录
        /// </summary>
        private static String workFolder = ConfigurationManager.AppSettings["workFolder"];
        public Form1()
        {
            InitializeComponent();

            MagickNET.SetTempDirectory(TempFolder);
        }

        private void btnBuildAvator_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMaxThreads(20, 10);
            ThreadPool.SetMinThreads(10, 4);
            int count = int.Parse(tbImgCount.Text);
            for (int i = 1; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(BuildGroupImage), i);

            } 
        }

        private static void BuildGroupImage(Object i)
        {

            var files = Directory.GetFiles(workFolder).Take(int.Parse(i.ToString()));
            List<List<AvactorInfo>> imggroup = GroupImage(files);
            BuildSquareImg(imggroup);
        }

        public string BuildGroupAvator(List<List<AvactorInfo>> imggroup)
        {
            string result = string.Empty;
            List<String> list = new List<String>();
            foreach (var item in imggroup)
            {

                list.Add(BuildAppendHorizontally(item));

            }
            result = BuildAppendVertically(list);

            return result;

        }
        private static readonly String TemplateURI = Path.Combine(TempFolder + @"\templateFolder\1.png");

 
        public static List<List<AvactorInfo>> GroupImage(IEnumerable<String> files)
        {
            List<List<AvactorInfo>> listImg = new List<List<AvactorInfo>>();
            if (files == null || !files.Any())
            {
                return listImg;
            }
            int count = files.Count();
            CalcImageCombine calc = new CalcImageCombine(files, TemplateURI);
            switch (count)
            {
                case 1:
                    calc.imageStrategy = new SingleImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 2:

                    calc.imageStrategy = new DoubleImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 3:
                    calc.imageStrategy = new TripleImageStrategy();
                    listImg = calc.getImages();

                    break;
                case 4:
                    calc.imageStrategy = new QuadrupleImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 5:
                    calc.imageStrategy = new PentaImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 6:
                    calc.imageStrategy = new HexImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 7:
                    calc.imageStrategy = new HexImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 8:
                    calc.imageStrategy = new NonaImageStrategy();
                    listImg = calc.getImages();
                    break;
                case 9:
                    calc.imageStrategy = new OctoImageStrategy();
                    listImg = calc.getImages();
                    break;

                default:
                    break;
            }

            return listImg;
        }

 

        public static String BuildSquareImg(List<List<AvactorInfo>> imggroup)
        {

            String result = String.Empty;
            if (imggroup == null || !imggroup.Any())
            {
                return result;
            }
            using (MagickImageCollection verticallyImages = new MagickImageCollection())
            {
                foreach (var item in imggroup)
                {
                    using (MagickImageCollection images = new MagickImageCollection())
                    {
                        foreach (var hitem in item)
                        {
                            MagickImage first = new MagickImage(hitem.FilePath); 
                            first.Resize(hitem.Width, hitem.Heigh);
                            if (hitem.IsResize)
                            {
                                first.BackgroundColor = new MagickColor(Color.Gray);
                            }
                            images.Add(first);

                        } 
                        verticallyImages.Add(images.AppendHorizontally()); 
                    }
                }
                using (IMagickImage vresult = verticallyImages.AppendVertically())
                {
                    // Save the result
                    result = Path.Combine(TempFolder, DateTime.Now.ToFileTime() + ".png");
                    vresult.Write(result);
                }
            }


            return result;

        }

        public static String BuildAppendHorizontally(List<AvactorInfo> imgs)
        {

            String filepath = String.Empty;
            using (MagickImageCollection images = new MagickImageCollection())
            {
                foreach (var item in imgs)
                {
                    MagickImage second = new MagickImage(item.FilePath);
                    if (item.IsResize)
                    {
                        second.Resize(50, 50);
                    }

                    images.Add(second);
                }

                using (IMagickImage result = images.AppendHorizontally())
                {
                    // Save the result
                    filepath = Path.Combine(TempFolder, DateTime.Now.ToFileTime() + "Horizontally.png");
                    result.Write(filepath);

                }
            }
            return filepath;
        }


        public static String BuildAppendVertically(List<String> imgs)
        {

            String filepath = String.Empty;
            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add the first image 

                foreach (var item in imgs)
                {
                    MagickImage second = new MagickImage(item);

                    images.Add(second);
                }
                using (IMagickImage result = images.AppendVertically())
                {
                    // Save the result
                    filepath = Path.Combine(TempFolder, DateTime.Now.ToFileTime() + "Vertically.png");
                    result.Write(filepath);

                }
            }
            return filepath;
        }


    }
}
