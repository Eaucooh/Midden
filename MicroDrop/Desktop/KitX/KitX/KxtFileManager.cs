namespace KitX
{
    public class KxtFileManager
    {
        public static void InstallKxt(string src)
        {
            Helper.Program.InstallKxtFile(src, App.ToolsBase, App.ToolsPath);
        }
    }
}
