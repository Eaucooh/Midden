using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace KitX.Helper
{
    public class Program
    {

        public const string 陈启月 = "我爱你" + "一辈子";

        static void Main(string[] args)
        {
            string filePath = "";
            if ((args != null) && (args.Length > 0))
            {
                for (int i = 0; i < args.Length; i++)
                {
                    // 对于路径中间带空格的会自动分割成多个参数传入
                    filePath += " " + args[i];
                }

                filePath.Trim();
                if (filePath.Contains("-r"))
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                    Process.Start($"{Environment.CurrentDirectory}\\KitX.exe");
                }
                if (filePath.Contains("-h"))
                {
                    MessageBox.Show("Commands List:\r\n" +
                        "\r\n   -r  -  Restart the KitX.exe;" +
                        "\r\n   -h  -  Show the help pane;" +
                        "\r\n   -f  -  Refist kxt file type;" +
                        "\r\n   -s[true] - Set it run with OS;" +
                        "\r\n   -s[false] - Set it do not run with OS;" +
                        "\r\n   -u  -  Update KitX Software." +
                        "\r\n\r\n" +
                        "No more.", "Commands for KitX.Helper.exe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (filePath.Contains("-f"))
                {
                    FileTypeRegist();
                }
                if (filePath.Contains("-s[true]"))
                {
                    Library.Windows.SetStart.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "KitX.lnk"), $"{Environment.CurrentDirectory}\\KitX.exe", null);
                    Library.FileHelper.Config.WriteValue($"{Environment.CurrentDirectory}\\App.config", "IsStartWithOS", "true");
                }
                if (filePath.Contains("-s[false]"))
                {
                    FileInfo fi = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "KitX.lnk"));
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    Library.FileHelper.Config.WriteValue($"{Environment.CurrentDirectory}\\App.config", "IsStartWithOS", "false");
                }
                if (filePath.Contains("-u"))
                {
                    Update();
                }
                if (filePath.Contains(":") && filePath.Contains("\\"))
                {
                    Process.Start($"{Environment.CurrentDirectory}\\KitX.exe");
                }
            }
        }

        private static void Update()
        {
            try
            {
                MySQLConnection msc = new MySQLConnection();
                byte[] myInstaller = msc.GetKitXInstaller();
                msc.Dispose();
                if (!Directory.Exists($"{Environment.CurrentDirectory}\\Update"))
                {
                    Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Update");
                }
                string fp = $"{Environment.CurrentDirectory}\\Update\\KitX.Installer.msi";
                if (File.Exists(fp))
                {
                    File.Delete(fp);
                }
                Library.FileHelper.FileHelper.ByteToFile(myInstaller, fp);
                Process.Start(fp);
                //if (Library.NetHelper.NetHelper.IsWebConected("42.193.5.54", 3 * 1000))
                //{
                //}
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        public static void FileTypeRegist()
        {
            FileTypeRegister.RegisterFileType(new FileTypeRegInfo(".kxt")
            {
                IconPath = $"{Environment.CurrentDirectory}\\kxt.ico",
                ExePath = $"{Environment.CurrentDirectory}\\KitX.Helper.exe",
                Description = "KitX专用插件安装格式"
            });
        }

        public static void RestartMainDomain(string workBase) => System.Diagnostics.Process.Start($"{Environment.CurrentDirectory}\\KitX.Helper.exe", "-r");

        public static string InstallKxtFile(string src, string ToolsBase, string ToolsPath)
        {
            string kxt = $"{Path.GetDirectoryName(src)}\\{Path.GetFileNameWithoutExtension(src)}.zip";
            string working = $"{ToolsBase}\\Installing\\{Path.GetFileNameWithoutExtension(kxt)}\\";
            if (!Directory.Exists(working))
            {
                Directory.CreateDirectory(working);
            }
            else
            {
                Library.FileHelper.FileHelper.DeleteSrcFolder(working);
                if (Directory.Exists(working))
                {
                    Directory.Delete(working);
                }
                Directory.CreateDirectory(working);
            }
            if (File.Exists(kxt))
            {
                File.Delete(kxt);
            }
            File.Move(src, kxt); //重命名
            Library.FileHelper.GZipCompress.Decompress(kxt, working);//解压到working
            File.Move(kxt, src);//还原原来的安装包
            string author = null, name = null;//提前变量准备
            DirectoryInfo dirInfo = new DirectoryInfo(working);//准备文件夹内容
            foreach (FileInfo file in dirInfo.GetFiles())//遍历文件夹内容
            {
                if (Library.TextHelper.Text.ToCapital(file.Extension).Equals(".DLL"))
                {
                    if (!File.Exists($"{ToolsPath}\\{file.Name}"))
                    {
                        file.MoveTo($"{ToolsPath}\\{file.Name}");
                    }
                }
                if (file.Name.Equals("inf_name.txt"))
                {
                    name = Library.FileHelper.FileHelper.ReadAll(file.FullName);//读插件名
                    file.Delete();
                }
                if (file.Name.Equals("inf_author.txt"))
                {
                    author = Library.FileHelper.FileHelper.ReadAll(file.FullName);//读作者名
                    file.Delete();
                }
            }

            string tar = $"{ToolsBase}\\{author}\\{name}\\";//准备工作空间的文件复制
            DirectoryInfo tarInfo = new DirectoryInfo(tar);
            if (!Directory.Exists(tar))
            {
                Directory.CreateDirectory(tar);
            }
            else if (tarInfo.GetFiles().Length >= 0)
            {
                Library.FileHelper.FileHelper.DeleteSrcFolder(working);
                Directory.Delete(working);
                return "HadInstalled";
            }
            foreach (FileInfo file in dirInfo.GetFiles())//复制剩余文件
            {
                file.MoveTo($"{tar}{file.Name}");
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())//复制剩余文件夹
            {
                Directory.Move(dir.FullName, $"{tar}{dir.Name}");
            }
            //Directory.Delete(working);//删除安装临时文件夹
            Library.FileHelper.FileHelper.DeleteSrcFolder(working);
            Directory.Delete(working);
            return "Success";
        }

        public static string GetGUID() => "v1.2.7.2081";
    }

    /// <summary>
    /// 文件类型注册信息
    /// </summary>
    public class FileTypeRegInfo
    {
        /// <summary>  
        /// 扩展名  
        /// </summary>  
        public string ExtendName;  //".osf"  
        /// <summary>  
        /// 说明  
        /// </summary>  
        public string Description; //"OpenSelfFile项目文件"  
        /// <summary>  
        /// 关联的图标  
        /// </summary>  
        public string IconPath;
        /// <summary>  
        /// 应用程序  
        /// </summary>  
        public string ExePath;

        public FileTypeRegInfo(string extendName) => ExtendName = extendName;
    }

    /// <summary>  
    /// 注册自定义的文件类型。  
    /// </summary>  
    public class FileTypeRegister
    {
        /// <summary>  
        /// 使文件类型与对应的图标及应用程序关联起来
        /// </summary>          
        public static void RegisterFileType(FileTypeRegInfo regInfo)
        {
            if (FileTypeRegistered(regInfo.ExtendName))
            {
                return;
            }

            //HKEY_CLASSES_ROOT/.osf
            RegistryKey fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
            string relationName = regInfo.ExtendName.Substring(1,
                                                               regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
            fileTypeKey.SetValue("", relationName);
            fileTypeKey.Close();

            //HKEY_CLASSES_ROOT/OSF_FileType
            RegistryKey relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
            relationKey.SetValue("", regInfo.Description);

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/DefaultIcon
            RegistryKey iconKey = relationKey.CreateSubKey("DefaultIcon");
            iconKey.SetValue("", regInfo.IconPath);

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell
            RegistryKey shellKey = relationKey.CreateSubKey("Shell");

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/Open
            RegistryKey openKey = shellKey.CreateSubKey("Open");

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/Open/Command
            RegistryKey commandKey = openKey.CreateSubKey("Command");
            commandKey.SetValue("", regInfo.ExePath + " %1"); // " %1"表示将被双击的文件的路径传给目标应用程序
            relationKey.Close();
        }

        /// <summary>  
        /// 更新指定文件类型关联信息  
        /// </summary>      
        public static bool UpdateFileTypeRegInfo(FileTypeRegInfo regInfo)
        {
            if (!FileTypeRegistered(regInfo.ExtendName))
            {
                return false;
            }

            string extendName = regInfo.ExtendName;
            string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
            RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName, true);
            relationKey.SetValue("", regInfo.Description);
            RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon", true);
            iconKey.SetValue("", regInfo.IconPath);
            RegistryKey shellKey = relationKey.OpenSubKey("Shell", true);
            RegistryKey openKey = shellKey.OpenSubKey("Open", true);
            RegistryKey commandKey = openKey.OpenSubKey("Command", true);
            commandKey.SetValue("", regInfo.ExePath + " %1");
            relationKey.Close();
            return true;
        }

        /// <summary>  
        /// 获取指定文件类型关联信息  
        /// </summary>          
        public static FileTypeRegInfo GetFileTypeRegInfo(string extendName)
        {
            if (!FileTypeRegistered(extendName))
            {
                return null;
            }
            FileTypeRegInfo regInfo = new FileTypeRegInfo(extendName);

            string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
            RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName);
            regInfo.Description = relationKey.GetValue("").ToString();
            RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon");
            regInfo.IconPath = iconKey.GetValue("").ToString();
            RegistryKey shellKey = relationKey.OpenSubKey("Shell");
            RegistryKey openKey = shellKey.OpenSubKey("Open");
            RegistryKey commandKey = openKey.OpenSubKey("Command");
            string temp = commandKey.GetValue("").ToString();
            regInfo.ExePath = temp.Substring(0, temp.Length - 3);
            return regInfo;
        }

        /// <summary>  
        /// 指定文件类型是否已经注册  
        /// </summary>          
        public static bool FileTypeRegistered(string extendName)
        {
            RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(extendName);
            if (softwareKey != null)
            {
                return true;
            }
            return false;
        }
    }
}
