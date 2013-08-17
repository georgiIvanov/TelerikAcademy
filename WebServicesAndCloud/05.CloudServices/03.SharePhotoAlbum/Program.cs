using DropNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03.SharePhotoAlbum
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("You must first login in your dropbox account.");

            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(currentDir).Parent.Parent;

            FileInfo[] pictures = info.GetFiles("*.jpg");

            List<int> indexesOfChosen = new List<int>();

            PrintAndChoosePictures(pictures, indexesOfChosen);

            DropNetClient client = new DropNetClient("8lc93q5ybq85syv", "nt6wrs7m0maixnl");

            var token = client.GetToken();
            var url = client.BuildAuthorizeUrl();

            Clipboard.SetText(url);

            Console.WriteLine("\n\nUrl copied to clipboard. Paste in browser and allow.\nPress any key to continue", url);
            Console.ReadKey(true);

            var accessToken = client.GetAccessToken();

            client.UserLogin.Secret = accessToken.Secret;
            client.UserLogin.Token = accessToken.Token;

            client.UseSandbox = true;


            Console.Write("Enter album name: ");
            var albumName = Console.ReadLine();

            var folder = client.CreateFolder(albumName);

            Console.WriteLine("\nUploading...\n");

            foreach (var i in indexesOfChosen)
            {
                MemoryStream sr = new MemoryStream((int)pictures[i].Length);
                FileStream fs = File.Open(pictures[i].FullName, FileMode.Open);
                
                var bytes = new byte[fs.Length];

                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                client.UploadFile(folder.Path, pictures[i].Name, bytes);

                fs.Close();
            }

            var shareUrl = client.GetShare(folder.Path);

            Clipboard.SetText(shareUrl.Url);

            Console.WriteLine(shareUrl.Url);
            Console.WriteLine("Share Url is also in clipboard");
        }

        static void PrintAndChoosePictures(FileInfo[] pictures, List<int> indexes)
        {
            int index = 0;
            foreach (var item in pictures)
            {
                Console.WriteLine("{1}.{0}", item.Name, index);
                index++;
            }

            Console.Write("Write indexes of chosen, on one line: ");

            string[] chosen = Console.ReadLine().Trim().Split();

            foreach (var item in chosen)
            {
                indexes.Add(int.Parse(item));
            }
        }
    }
}
