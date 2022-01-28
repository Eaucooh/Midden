using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_file
{
    public class Config
    {
        /// <summary>
        /// 静态方法：读取指定路径config(配置文件)的指定键的值
        /// </summary>
        /// <param name="path">配置文件路径</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
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
    }
}
