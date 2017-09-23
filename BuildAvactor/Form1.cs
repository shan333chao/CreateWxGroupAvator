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
        private static String workFolder =ConfigurationManager.AppSettings["workFolder"];
        public Form1()
        {
            InitializeComponent();

            MagickNET.SetTempDirectory(TempFolder);
        }

        private void btnBuildAvator_Click(object sender, EventArgs e)
        {

            int count = int.Parse(tbImgCount.Text);
            var files = Directory.GetFiles(workFolder).Take(count);
            if (files != null && files.Any())
            {
                Thread t = new Thread(() =>
                {
                    List<List<AvactorInfo>> imggroup = GroupImage(files);
                    BuildSquareImg(imggroup);
                });
                t.Start();
            }
            else
            {
                MessageBox.Show("no images");
            }


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


        private static readonly AvactorInfo height17 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\height17.png"), Heigh = 50, Width = 25, IsResize = false };
        private static readonly AvactorInfo height25 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\height25.png"), Heigh = 25, Width = 50, IsResize = false };
        private static readonly AvactorInfo height37 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\height37.png"), Heigh = 50, Width = 50, IsResize = false };
        private static readonly AvactorInfo width25 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\width25.png"), Heigh = 17, Width = 50, IsResize = false };
        private static readonly AvactorInfo width37 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\width37.png"), Heigh = 17, Width = 50, IsResize = false };
        private static readonly AvactorInfo width50 = new AvactorInfo { FilePath = Path.Combine(TempFolder + @"\templateFolder\width50.png"), Heigh = 17, Width = 50, IsResize = false };
        private static readonly List<AvactorInfo> Width25 = new List<AvactorInfo>() { width25 };
        private static readonly List<AvactorInfo> Height25 = new List<AvactorInfo>() { height25 };
        private static readonly List<AvactorInfo> Trible50x17 = new List<AvactorInfo>() { height17 };
        private static readonly List<AvactorInfo> Heigh37 = new List<AvactorInfo>() { height37 };
        private static readonly List<AvactorInfo> Trible50x25 = new List<AvactorInfo>() { height25 };
        public List<List<AvactorInfo>> GroupImage(IEnumerable<String> files)
        {
            List<List<AvactorInfo>> listImg = new List<List<AvactorInfo>>();
            if (files == null)
            {
                return listImg;
            }
            int count = files.Count();
            switch (count)
            {
                case 1:
                    listImg.Add(CreateListMagick(files, 0, 1, count));
                    break;
                case 2:
                    listImg.Add(Heigh37);
                    listImg.Add(CreateListMagick(files, 0, 2, count));
                    listImg.Add(Heigh37);
                    break;
                case 3:
                    var list = new List<AvactorInfo>();
                    list.Add(width37);
                    list.AddRange(CreateListMagick(files, 0, 1, count));
                    listImg.Add(list);

                    var list3 = new List<AvactorInfo>();
                    list3.AddRange(CreateListMagick(files, 1, 2, count));
                    listImg.Add(list3);


                    break;
                case 4:
                    listImg.Add(CreateListMagick(files, 0, 2, count));
                    listImg.Add(CreateListMagick(files, 2, 2, count));
                    break;
                case 5:
                    listImg.Add(Height25);
                    var list5 = new List<AvactorInfo>();
                    list5.Add(width25);
                    list5.AddRange(CreateListMagick(files, 0, 2, count));
                    listImg.Add(list5);


                    listImg.Add(CreateListMagick(files, 2,5, count));
                    listImg.Add(Height25);
                    break;
                case 6:
                    listImg.Add(Height25);
                    listImg.Add(CreateListMagick(files, 0, 3, count));
                    listImg.Add(CreateListMagick(files, 3, 3, count));
                    listImg.Add(Height25);
                    break;
                case 7:
                    var list7 = new List<AvactorInfo>();
                    list7.Add(width50);
                    list7.AddRange(CreateListMagick(files, 0, 1, count));
                    listImg.Add(list7);
                    listImg.Add(CreateListMagick(files, 1, 3));
                    listImg.Add(CreateListMagick(files, 4, 3));
                    break;
                case 8:
                    var list8 = new List<AvactorInfo>();
                    list8.Add(width25);
                    list8.AddRange(CreateListMagick(files, 0, 2));
                    listImg.Add(list8);
                    listImg.Add(CreateListMagick(files, 2, 3));
                    listImg.Add(CreateListMagick(files, 5, 3));
                    break;
                case 9:
                    listImg.Add(CreateListMagick(files, 0, 3));
                    listImg.Add(CreateListMagick(files, 3, 3));
                    listImg.Add(CreateListMagick(files, 6, 3));
                    break;

                default:
                    break;
            }

            return listImg;
        }

        private static List<AvactorInfo> CreateListMagick(IEnumerable<String> files, int skip, int take, int type = 0)
        {
            int width = 50;
            int height = 50;

            switch (type)
            {
                case 1:
                    width = 150;
                    height = 150;
                    break;
                case 2:
                case 3:
                case 4:
                    width = 75;
                    height = 75;
                    break;
                case 0:

                    break;
                default:
                    break;
            }
            var result = files.Skip(skip).Take(take).Select(p => new AvactorInfo { FilePath = p, Heigh = height, Width = width, IsResize = true });
            return result.ToList();
        }

        public static String BuildSquareImg(List<List<AvactorInfo>> imggroup)
        {
            String result = String.Empty;
            using (MagickImageCollection verticallyImages = new MagickImageCollection())
            {
                foreach (var item in imggroup)
                {
                    using (MagickImageCollection images = new MagickImageCollection())
                    {
                        foreach (var hitem in item)
                        {


                            MagickImage second = new MagickImage(hitem.FilePath);
                            if (hitem.IsResize)
                            {
                                second.Resize(hitem.Width, hitem.Heigh);
                            }
                            images.Add(second);

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
