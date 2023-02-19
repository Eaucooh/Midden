using System.Collections.Generic;
using System.Windows;

namespace KitX
{

    /// <summary>
    /// 命令处理类
    /// </summary>
    public class Command
    {
        /// <summary>
        /// 命令数量
        /// </summary>
        private const int cmd_num = 16;

        public static string[] cmds = new string[cmd_num]
        {
            "MAINWINDOW","WORKBASE","HELP","AB_LOCK","AB_UNLOCK","GB_INFO","GB_WARNING","GB_ERROR","GB_SUCCESS","GB_FATAL","GB_CLEAR",
            "CP_TEACHER", "CP_HELPER_GUID", "CP_POPEYE_VERSION", "CP_RESOURCES", "MARKET"
        };

        private static string[] cmds_explains = new string[cmd_num]
        {
            "打开主窗口","打开工作目录","帮助","锁定工具栏","解锁工具栏","【全局】信息","【全局】警告","【全局】错误","【全局】成功","【全局】崩溃","【全局】清空",
            "【组件】启动指引", "【组件】帮助程序——版本", "【组件】PopEye——版本", "【组件】App.资源", "市场调试工具"
        };

        /// <summary>
        /// 处理通用命令
        /// </summary>
        /// <param name="cmd">命令</param>
        public static void NormalCommand(string cmd, MainWindow father)
        {
            for (int i = 0; i < cmds.Length; i++)
            {
                if (Library.TextHelper.Text.ToCapital(cmd).Equals(cmds[i]))
                {
                    switch (i)
                    {
                        case 0: //新建主窗体 - MainWindow
                            MainWindow mw = new MainWindow();
                            mw.Show();
                            break;
                        case 1: //工作空间 - WorkBase
                            System.Diagnostics.Process.Start(App.WorkBase);
                            break;
                        case 2: //帮助 - Help
                            string info = "Commands - Explanations:\r\n";
                            for (int p = 0; p < cmd_num; p++)
                            {
                                info += $"    {cmds[p]} - {cmds_explains[p]}\r\n";
                            }
                            MessageBox.Show(info, "KitX - Help", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        //AB_XXX - AppsBar の 通用命令
                        case 3: //锁定AppsBar
                            father.abc.Lock();
                            break;
                        case 4: //解锁AppsBar
                            father.abc.UnLock();
                            break;
                        //GB_XXX - Global 全局命令
                        case 5: //提示
                            HandyControl.Controls.Growl.Info(App.Input_Normal("Info", "Input your content"));
                            break;
                        case 6: //警告
                            HandyControl.Controls.Growl.Warning(App.Input_Normal("Info", "Input your content"));
                            break;
                        case 7: //错误
                            HandyControl.Controls.Growl.Error(App.Input_Normal("Info", "Input your content"));
                            break;
                        case 8: //成功
                            HandyControl.Controls.Growl.Success(App.Input_Normal("Info", "Input your content"));
                            break;
                        case 9: //崩溃
                            HandyControl.Controls.Growl.Fatal(App.Input_Normal("Info", "Input your content"));
                            break;
                        case 10: //清除
                            HandyControl.Controls.Growl.Clear();
                            break;
                        //CP_XXX Componet 组件命令
                        case 11: //Teacher
                            FirstStartTeacher fst = new FirstStartTeacher();
                            fst.Show();
                            break;
                        case 12: //KitX.Helper.GUID
                            MessageBox.Show($"KitX.Helper.exe - GUID:\r\n{Helper.Program.GetGUID()}");
                            break;
                        case 13: //PopEye.WPF.Version
                            MessageBox.Show($"PopEye.WPF.dll - Version:\r\n{PopEye.WPF.Info.Info.GetVersion()}");
                            break;
                        case 14: //List App.Resources Items
                            ResourceDictionary rd = Application.Current.Resources;
                            string Out = "";
                            foreach (ResourceDictionary item in rd.MergedDictionaries)
                            {
                                Out += $"{item.Source}\r\n";
                            }
                            MessageBox.Show(Out);
                            break;
                        case 15:
                            List<string> ids = null;
                            switch (App.Input_Normal("Type", "Input the target type").ToLower())
                            {
                                case "process":
                                    ids = new Helper.MySQLConnection().GetIDs(Helper.MySQLConnection.toolType.process);
                                    break;
                                case "program":
                                    ids = new Helper.MySQLConnection().GetIDs(Helper.MySQLConnection.toolType.program);
                                    break;
                                case "normal":
                                    ids = new Helper.MySQLConnection().GetIDs(Helper.MySQLConnection.toolType.normal);
                                    break;
                                case "design":
                                    ids = new Helper.MySQLConnection().GetIDs(Helper.MySQLConnection.toolType.design);
                                    break;
                                case "system":
                                    ids = new Helper.MySQLConnection().GetIDs(Helper.MySQLConnection.toolType.system);
                                    break;
                                default:
                                    MessageBox.Show("Only 5 types are allowed:\r\n\tprocess;\r\n\tprogram;\r\n\tnormal;\r\n\tdesign;\r\n\tsystem;");
                                    break;
                            }
                            string op = "";
                            foreach (string item in ids)
                            {
                                op += item + "\r\n";
                            }
                            MessageBox.Show(op);
                            break;
                    }
                }
            }            
        }
    }
}
