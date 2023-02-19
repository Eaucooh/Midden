using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace Library.XAMLHelper
{
    public class XAMLHelper
    {
        public static Window LoadFromXAML(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (Window)XamlReader.Load(fs);
            }
        }
    }
}
