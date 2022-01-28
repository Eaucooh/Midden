namespace KitX
{

    /// <summary>
    /// 命令处理类
    /// </summary>
    public class Command
    {
        public static string[] cmds = new string[12]
        {
            "MAINWINDOW","WORKBASE","HELP","AB_LOCK","AB_UNLOCK","GB_INFO","GB_WARNING","GB_ERROR","GB_SUCCESS","GB_FATAL","GB_CLEAR", "CP_TEACHER"
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
                    }
                }
            }            
        }
    }
}
