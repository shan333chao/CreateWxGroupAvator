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
namespace BuildAvactor
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// 拼接后的存放的目录
        /// </summary>
        private static String TempFolder = System.IO.Directory.GetCurrentDirectory();
        /// <summary>
        /// 需要拼接的图片文件目录
        /// </summary>
        private static String workFolder = @"D:\headers";
        public Form1()
        {
            InitializeComponent();

            MagickNET.SetTempDirectory(TempFolder);
        }

        private void btnBuildAvator_Click(object sender, EventArgs e)
        {

            int count = int.Parse(tbImgCount.Text);
            var files = Directory.GetFiles(workFolder).Take(count);
            if (files!=null&&files.Any())
            {
                Thread t = new Thread(() =>
                {
                    List<List<AvactorInfo>> imggroup = GroupImage(files);
                    BuildGroupAvator(imggroup);
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


        private static readonly AvactorInfo blank25x50 = new AvactorInfo { FilePath = Path.Combine(TempFolder, @"\templateFolder\25x50.png"), Heigh = 50, Width = 25, IsResize = false };
        private static readonly AvactorInfo blank50x25 = new AvactorInfo { FilePath = Path.Combine(TempFolder, @"\templateFolder\50x25.png"), Heigh = 25, Width = 50, IsResize = false };
        private static readonly AvactorInfo blank50x50 = new AvactorInfo { FilePath = Path.Combine(TempFolder, @"\templateFolder\50x50.png"), Heigh = 50, Width = 50, IsResize = false };
        private static readonly AvactorInfo blank50x17 = new AvactorInfo { FilePath = Path.Combine(TempFolder, @"\templateFolder\50x17.png"), Heigh = 17, Width = 50, IsResize = false };
        private static readonly List<AvactorInfo> Double50x25 = new List<AvactorInfo>() { blank50x25, blank50x25 };
        private static readonly List<AvactorInfo> Trible50x17 = new List<AvactorInfo>() { blank50x17, blank50x17, blank50x17 };


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
                    listImg.Add(CreateListMagick(files, 0, 1));
                    break;
                case 2:
                    listImg.Add(Double50x25);
                    listImg.Add(CreateListMagick(files, 0, 2));
                    listImg.Add(Double50x25);
                    break;
                case 3:
                    var list = new List<AvactorInfo>();
                    list.Add(blank25x50);
                    list.AddRange(CreateListMagick(files, 0, 1));
                    list.Add(blank25x50);
                    listImg.Add(list);

                    var list3 = new List<AvactorInfo>();
                    list3.AddRange(CreateListMagick(files, 1, 2));
                    listImg.Add(list3);


                    break;
                case 4:
                    listImg.Add(CreateListMagick(files, 0, 2));
                    listImg.Add(CreateListMagick(files, 2, 2));
                    break;
                case 5:
                    listImg.Add(Trible50x17);
                    listImg.Add(CreateListMagick(files, 0, 3));
                    var list5 = new List<AvactorInfo>();
                    list5.Add(blank25x50);
                    list5.AddRange(CreateListMagick(files, 2, 2));
                    listImg.Add(list5);
                    listImg.Add(Trible50x17);
                    break;
                case 6:
                    listImg.Add(Trible50x17);
                    listImg.Add(CreateListMagick(files, 0, 3));
                    listImg.Add(CreateListMagick(files, 0, 3));
                    listImg.Add(Trible50x17);
                    break;
                case 7:
                    var list7 = new List<AvactorInfo>();
                    list7.Add(blank50x50);
                    list7.AddRange(CreateListMagick(files, 0, 1));
                    list7.Add(blank50x50);
                    listImg.Add(list7);
                    listImg.Add(CreateListMagick(files, 1, 3));
                    listImg.Add(CreateListMagick(files, 4, 3));
                    break;
                case 8:
                    var list8 = new List<AvactorInfo>();
                    list8.Add(blank25x50);
                    list8.AddRange(CreateListMagick(files, 0, 2));
                    list8.Add(blank25x50);
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

        private static List<AvactorInfo> CreateListMagick(IEnumerable<String> files, int skip, int take)
        {

            var result = files.Skip(skip).Take(take).Select(p => new AvactorInfo { FilePath = p, Heigh = 50, Width = 50, IsResize = true });


            return result.ToList();
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
