using Microsoft.Win32;
using System.Collections.Generic;

namespace Library.Windows
{
    public class GetApps
    {
        /// 获取所有已经安装的程序
        /// </summary>
        /// <param name="reg"></param>
        /// <returns>程序名称,安装路径</returns> 
        public static List<NameAndPath> GetProgramAndPath()
        {
            List<NameAndPath> nameAndPaths = new List<NameAndPath>();
            var reg = new string[] {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
            };
            string tempType = null;
            int softNum = 0;//所有已经安装的程序数量
            RegistryKey currentKey = null;

            foreach (var item222 in reg)
            {
                object displayName = null, uninstallString = null, installLocation = null, releaseType = null;
                RegistryKey pregkey = Registry.LocalMachine.OpenSubKey(item222);//获取指定路径下的键 
                foreach (string item in pregkey.GetSubKeyNames())               //循环所有子键
                {
                    NameAndPath ls = new NameAndPath();

                    currentKey = pregkey.OpenSubKey(item);
                    displayName = currentKey.GetValue("DisplayName");           //获取显示名称
                    installLocation = currentKey.GetValue("InstallLocation");   //获取安装路径
                    uninstallString = currentKey.GetValue("UninstallString");   //获取卸载字符串路径
                    releaseType = currentKey.GetValue("ReleaseType");           //发行类型,值是Security Update为安全更新,Update为更新

                    bool isSecurityUpdate = false;
                    if (releaseType != null)
                    {
                        tempType = releaseType.ToString();
                        if (tempType == "Security Update" || tempType == "Update")
                        {
                            isSecurityUpdate = true;
                        }
                    }
                    if (!isSecurityUpdate && displayName != null && uninstallString != null)
                    {
                        softNum++;
                        if (installLocation == null)
                        {
                            ls.name = displayName.ToString();
                            ls.path = "";
                        }
                        else
                        {
                            ls.name = displayName.ToString();
                            ls.path = installLocation.ToString();
                        }
                    }

                    nameAndPaths.Add(ls);
                }
            }
            return nameAndPaths;
        }

        public class NameAndPath
        {
            public string name { get; set; }
            public string path { get; set; }
        }
    }
}
