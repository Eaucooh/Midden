using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace Library.FileHelper
{
    /// <summary>
    /// 使用SharpCompress
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// 解药Zip压缩包到指定目录
        /// </summary>
        /// <param name="src">压缩包</param>
        /// <param name="tar">目标路径</param>
        /// <returns>Exp异常信息</returns>
        public static Exp.Exception_Simple.Returning Uncompression(string src, string tar)
        {
            if (TextHelper.Text.ToCapital(Path.GetExtension(src)).Equals(".ZIP"))
            {
                var archive = ArchiveFactory.Open(src);
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        entry.WriteToDirectory(tar);
                    }
                }
                return new Exp.Exception_Simple.Returning
                {
                    SoF = true, Ex = null
                };
            }
            else
            {
                return new Exp.Exception_Simple.Returning
                {
                    SoF = false,
                    Ex = new Exception("This format isn't surported with this func.")
                };
            }
        }

        /// <summary>
        /// 简单的压缩文件夹内文件到指定压缩包
        /// </summary>
        /// <param name="src">文件夹</param>
        /// <param name="tar">目标压缩包</param>
        /// <returns>Exp异常信息</returns>
        public static Exp.Exception_Simple.Returning Compression(string src, string tar)
        {
            try
            {
                using (var archive = SharpCompress.Archives.Zip.ZipArchive.Create())
                {
                    archive.AddAllFromDirectory(src);
                    archive.SaveTo(tar, new SharpCompress.Writers.WriterOptions(CompressionType.GZip)
                    {
                        ArchiveEncoding = new ArchiveEncoding(Encoding.Unicode, Encoding.Unicode)
                    });
                    return new Exp.Exception_Simple.Returning
                    {
                        SoF = true,
                        Ex = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new Exp.Exception_Simple.Returning
                {
                    SoF = false,
                    Ex = ex
                };
            }
        }
    }

    /// <summary>
    /// GZip的压缩方式
    /// </summary>
    public class GZipCompress
    {

        /// <summary>
        /// 压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] Compress(byte[] inputBytes)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                    zipStream.Close(); //很重要，必须关闭，否则无法正确解压
                    return outStream.ToArray();
                }
            }
        }

        /// <summary>
        /// 解压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] Decompress(byte[] inputBytes)
        {

            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zipStream.CopyTo(outStream);
                        zipStream.Close();
                        return outStream.ToArray();
                    }
                }

            }
        }

        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Compress(string input)
        {
            byte[] inputBytes = Encoding.Default.GetBytes(input);
            byte[] result = Compress(inputBytes);
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// 解压缩字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Decompress(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] depressBytes = Decompress(inputBytes);
            return Encoding.Default.GetString(depressBytes);
        }

        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="dir"></param>
        public static void Compress(DirectoryInfo dir)
        {
            foreach (FileInfo fileToCompress in dir.GetFiles())
            {
                Compress(fileToCompress);
            }
        }

        /// <summary>
        /// 解压缩目录
        /// </summary>
        /// <param name="dir"></param>
        public static void Decompress(DirectoryInfo dir)
        {
            foreach (FileInfo fileToCompress in dir.GetFiles())
            {
                Decompress(fileToCompress);
            }
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileToCompress"></param>
        public static void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="fileToDecompress"></param>
        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        /// <summary>
        /// 压缩目录下所有文件到一个压缩包
        /// </summary>
        /// <param name="src">目录</param>
        /// <param name="to">压缩包</param>
        public static void Compress(string src, string to) => ZipFile.CreateFromDirectory(src, to);

        /// <summary>
        /// 解压缩一个压缩包到指定目录下
        /// </summary>
        /// <param name="src">压缩包</param>
        /// <param name="to">指定目录</param>
        public static void Decompress(string src, string to) => ZipFile.ExtractToDirectory(src, to);

        /// <summary>
        /// 向指定压缩包追加问价
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="zip">压缩包</param>
        public static void AppendFile(string file, string zip)
        {
            using (FileStream zipToOpen = new FileStream(zip, FileMode.Open))
            {
                using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    System.IO.Compression.ZipArchiveEntry readmeEntry = archive.CreateEntry(Path.GetFileName(file));
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.Write(FileHelper.ReadAll(file));
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }
    }
}
