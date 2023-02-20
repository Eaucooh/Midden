using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace 停车场项目
{
   public class Magager
    {
       public static ParkingMagager Park = new ParkingMagager();
       /// <summary>
       /// 保存
       /// </summary>
       public static void OnLoad()
       {
           string path = Application.StartupPath + @"\data";
           if (Directory.Exists(path) == false)
           {
               Directory.CreateDirectory(path);
           }
           FileStream fs = new FileStream(path + @"\data2.dat", FileMode.Create, FileAccess.Write);
           BinaryFormatter bw = new BinaryFormatter();
           bw.Serialize(fs, Park);
           fs.Close();
       }
       /// <summary>
       /// 读取
       /// </summary>
       public static void Load()
       {
           string path = Application.StartupPath + @"\data\data2.dat";
           if (File.Exists(path))
           {
               FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
               BinaryFormatter bw = new BinaryFormatter();
               Park = bw.Deserialize(fs) as ParkingMagager;
               fs.Close();
           }
       }
    }
}
