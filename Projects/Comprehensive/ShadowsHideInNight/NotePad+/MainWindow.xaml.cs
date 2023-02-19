using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace ELMTP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string mypath = Environment.CurrentDirectory + @"\elmtp.exe";
        string username = Environment.UserName;
        string savepath = null;
        bool isTxtChanged = false;
        RoutedEventArgs o = new RoutedEventArgs();
        #region 界面交互
        public MainWindow()
        {
            InitializeComponent();
            hidemenu();
            seawin.Visibility = Visibility.Hidden;
            taplwin.Visibility = Visibility.Hidden;
            txt.TextChanged += (x, y) =>
            {
                isTxtChanged = true;
                title.Text = title.Text.Replace('*', '\0');
                title.Text = title.Text + "*";
                Row_Update();
            };
            sitruationBar.Checked += (x, y) =>
            {
                sitBar.Visibility = Visibility.Visible;
                txtDocker.Margin = new Thickness(0, 75, 0, 25);
            };
            sitruationBar.Unchecked += (x, y) =>
            {
                sitBar.Visibility = Visibility.Hidden;
                txtDocker.Margin = new Thickness(0, 75, 0, 0);
            };
            rowNum.Checked += (x, y) =>
            {
                row.Visibility = Visibility.Visible;
                if (sitBar.Visibility == Visibility.Visible)
                {
                    row.Margin = new Thickness(0, 0, 0, 0);
                    txt.Margin = new Thickness(80, 0, 0, 0);
                }
                else
                {
                    row.Margin = new Thickness(0, 0, 0, 0);
                    txt.Margin = new Thickness(80, 0, 0, 0);
                }
            };
            rowNum.Unchecked += (x, y) =>
            {
                row.Visibility = Visibility.Hidden;
                if (sitBar.Visibility == Visibility.Visible)
                {
                    txt.Margin = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    txt.Margin = new Thickness(0, 0, 0, 0);
                }
            };
        }

        private void Row_Update()
        {
            row.Document.Blocks.Clear();
            row.FontSize = txt.FontSize;
            row.FontFamily = txt.FontFamily;
            row.FontStretch = txt.FontStretch;
            row.FontWeight = txt.FontWeight;
            row.Document.LineHeight = txt.Document.LineHeight;
            row.Document.LineStackingStrategy = txt.Document.LineStackingStrategy;
            int rn = txt.Document.Blocks.Count;
            for (int i = 0; i < rn; i++)
            {
                row.Document.Blocks.Add(new Paragraph(new Run((i + 1).ToString())));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception o)
            {

                throw o;
            }
        }

        private void mini_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void resize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                resize.Content = "";
                WindowState = WindowState.Normal;
            }
            else
            {
                resize.Content = "";
                WindowState = WindowState.Maximized;
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            exit_Click(sender, e);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                resize.Content = "";
            }
            else
            {
                resize.Content = "";
            }
        }

        private void showMainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (mainMenu.Visibility == Visibility.Hidden)
            {
                mainMenu.Visibility = Visibility.Visible;
            }
            else
            {
                mainMenu.Visibility = Visibility.Hidden;
            }
        }

        private void mainMenu_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (mainMenu.Visibility == Visibility.Visible)
            {
                showMainMenu.Content = "";
            }
            else
            {
                showMainMenu.Content = "";
            }
        }

        private void showFileMenu_Click(object sender, RoutedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (fileMenu.Visibility == Visibility.Visible)
            {
                fileMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                fileMenu.Visibility = Visibility.Visible;
            }
        }

        private void showEditMenu_Click(object sender, RoutedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (editMenu.Visibility == Visibility.Visible)
            {
                editMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                editMenu.Visibility = Visibility.Visible;
            }
        }

        private void showFormatMenu_Click(object sender, RoutedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (formatMenu.Visibility == Visibility.Visible)
            {
                formatMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                formatMenu.Visibility = Visibility.Visible;
            }
        }

        private void showViewMenu_Click(object sender, RoutedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (viewMenu.Visibility == Visibility.Visible)
            {
                viewMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                viewMenu.Visibility = Visibility.Visible;
            }
        }

        private void showAboutMenu_Click(object sender, RoutedEventArgs e)
        {
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
            if (aboutMenu.Visibility == Visibility.Visible)
            {
                aboutMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                aboutMenu.Visibility = Visibility.Visible;
            }
        }

        private void toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainMenu.Visibility = Visibility.Hidden;
        }

        private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            mainMenu.Visibility = Visibility.Hidden;
        }
        #endregion

        #region 事件
        void text(string target)
        {
            try
            {
                txt.Document.Blocks.Clear();
                FileStream fs = new FileStream(target, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                txt.AppendText(sr.ReadToEnd());
                sr.Close();
                fs.Close();
                title.Text = target;
            }
            catch
            {

            }
        }

        void hidemenu()
        {
            mainMenu.Visibility = Visibility.Hidden;
            fileMenu.Visibility = Visibility.Hidden;
            editMenu.Visibility = Visibility.Hidden;
            formatMenu.Visibility = Visibility.Hidden;
            viewMenu.Visibility = Visibility.Hidden;
            aboutMenu.Visibility = Visibility.Hidden;
        }
        #region 文件菜单
        private void crenew_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(mypath);
            hidemenu();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "文本文档|*.txt|所有文件|*.*",
                    Title = "打开文件",
                    InitialDirectory = @"C:\Users\" + username + @"\Desktop\",
                    Multiselect = false
                };
                ofd.ShowDialog();
                savepath = ofd.FileName;
                text(savepath);
            }
            catch
            {
                //MessageBox.Show("尝试打开文档失败！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            hidemenu();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (savepath != null)
                {
                    FileStream fs = new FileStream(savepath, FileMode.Open);
                    StreamWriter sw = new StreamWriter(fs);
                    TextRange tr = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                    sw.Write(tr.Text.ToString());
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog()
                    {
                        Filter = "文本文档|*.txt|所有文件|*.*",
                        Title = "保存到",
                        InitialDirectory = @"C:\Users\" + username + @"\Desktop\",
                        AddExtension = true,
                        OverwritePrompt = true
                    };
                    sfd.ShowDialog();
                    savepath = sfd.FileName;
                    FileStream fs = new FileStream(savepath, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    TextRange tr = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                    sw.Write(tr.Text.ToString());
                    sw.Close();
                    fs.Close();
                }
                isTxtChanged = false;
                title.Text = title.Text.Replace('*', '\0');
            }
            catch
            {

            }
            hidemenu();
        }

        private void savnew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "文本文档|*.txt|所有文件|*.*",
                    Title = "另存为",
                    InitialDirectory = @"C:\Users\" + username + @"\Desktop\",
                    AddExtension = true,
                    OverwritePrompt = true
                };
                sfd.ShowDialog();
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                TextRange tr = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                sw.Write(tr.Text.ToString());
                sw.Close();
                fs.Close();
            }
            catch
            {

            }
            hidemenu();
        }

        private void pagset_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog()
            {
                
            };
            pd.ShowDialog();
            hidemenu();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (isTxtChanged == false)
            {
                Close();
            }
            else
            {
                MessageBoxResult msg = MessageBox.Show("您的文档已被修改\n是否保存未保存的文档?\n若不保存将会丢失必要的工作进度", "警告", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (msg == MessageBoxResult.No)
                {
                    Environment.Exit(1);
                }
                else if (msg == MessageBoxResult.Yes)
                {
                    save_Click(sender, e);
                }
            }
            hidemenu();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            text(savepath);
            hidemenu();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt.Undo();
            }
            catch
            {

            }
            hidemenu();
        }

        private void redo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt.Redo();
            }
            catch
            {

            }
            hidemenu();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (seawin.Visibility == Visibility.Visible)
            {
                seawin.Visibility = Visibility.Hidden;
            }
            else
            {
                seawin.Visibility = Visibility.Visible;
            }
            hidemenu();
        }

        private void tapl_Click(object sender, RoutedEventArgs e)
        {
            if (taplwin.Visibility == Visibility.Visible)
            {
                taplwin.Visibility = Visibility.Hidden;
            }
            else
            {
                taplwin.Visibility = Visibility.Visible;
            }
            hidemenu();
        }

        private void clone_Click(object sender, RoutedEventArgs e)
        {
            //clone txt.Selection.ToString()
            hidemenu();
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void goto_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void selall_Click(object sender, RoutedEventArgs e)
        {
            txt.SelectAll();
            hidemenu();
        }
        #endregion

        #endregion

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftCtrl))
            {
                if (e.KeyStates == Keyboard.GetKeyStates(Key.S))
                {
                    save_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.O))
                {
                    open_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.P))
                {
                    print_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.N))
                {
                    crenew_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftShift) && e.KeyStates == Keyboard.GetKeyStates(Key.S))
                {
                    savnew_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.Z))
                {
                    undo_Click(search, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.Y))
                {
                    redo_Click(search, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.A))
                {
                    selall_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.F))
                {
                    search_Click(sender, o);
                }
                if (e.KeyStates == Keyboard.GetKeyStates(Key.H))
                {
                    tapl_Click(sender, o);
                }
            }
        }

        private void closeawin_Click(object sender, RoutedEventArgs e)
        {
            seawin.Visibility = Visibility.Hidden;
        }

        private void clotaplwin_Click(object sender, RoutedEventArgs e)
        {
            taplwin.Visibility = Visibility.Hidden;
        }

        private void taplwin_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            seawin.Visibility = Visibility.Hidden;
        }

        private void seawin_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            taplwin.Visibility = Visibility.Hidden;
        }        

        private void takeplace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string taken = taplnow.Text.ToString();
                string target = tapltar.Text.ToString();
                TextRange doccon = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                string doc = doccon.Text.ToString();
                txt.Document.Blocks.Clear();
                string newdoc = doc.Replace(taken, target);
                txt.AppendText(newdoc);
            }
            catch (Exception)
            {
                
            }
        }

        int[] seaind = { -1 };

        private void seatar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string target = seatar.Text.ToString();
            string doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd).ToString();
            
        }

        private void txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void gohome_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://productions.InkShadow.com/elmtp/");
            hidemenu();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            hidemenu();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://support.InkShadow.com/elmtp/");
            hidemenu();
        }

        private void fontSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
