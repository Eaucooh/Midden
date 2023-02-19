using System.Configuration;

namespace Library.FileHelper
{
    public class Config
    {
        /// <summary>
        /// 静态方法：读取指定路径config(配置文件)的指定键的值
        /// </summary>
        /// <param name="path">配置文件路径</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string ReadValue(string path, string key)
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap
            {
                ExeConfigFilename = path
            };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            //string connstr = config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// 静态方法：写入指定路径config(配置文件)一个键值对
        /// </summary>
        /// <param name="path">配置文件路径</param>
        /// <param name="key">键</param>
        /// <param name="content">值</param>
        /// <returns>返回写入是否成功</returns>
        public static bool WriteValue(string path, string key, string content)
        {
            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = path
                };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = content;
                config.Save(ConfigurationSaveMode.Minimal, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
