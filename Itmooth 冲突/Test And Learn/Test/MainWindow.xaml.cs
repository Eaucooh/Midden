using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Aesthetic_Standard.MessageBox messageBox1 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Light, Aesthetic_Standard.Buttons.Cancel_OK);
            Aesthetic_Standard.MessageBox messageBox2 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Dark, Aesthetic_Standard.Buttons.Cancel_OK);
            Aesthetic_Standard.MessageBox messageBox3 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Light, Aesthetic_Standard.Buttons.Cancel_Stop_Retry);
            Aesthetic_Standard.MessageBox messageBox4 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Dark, Aesthetic_Standard.Buttons.Cancel_Stop_Retry);
            Aesthetic_Standard.MessageBox messageBox5 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Light, Aesthetic_Standard.Buttons.OK);
            Aesthetic_Standard.MessageBox messageBox6 = new Aesthetic_Standard.MessageBox("你好", Aesthetic_Standard.Theme.Dark, Aesthetic_Standard.Buttons.OK);
            messageBox1.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox2.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox3.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox4.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox5.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox6.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
            messageBox1.Show(Aesthetic_Standard.Animation.MiddleLine_To_TopAndBottom, WindowStartupLocation.CenterScreen);
            messageBox2.Show(Aesthetic_Standard.Animation.MiddleLine_To_TopAndBottom_With_Fade, WindowStartupLocation.CenterScreen);
            messageBox3.Show(Aesthetic_Standard.Animation.Center_To_Four_Corners, WindowStartupLocation.CenterScreen);
            messageBox4.Show(Aesthetic_Standard.Animation.Center_To_Four_Corners_With_Fade, WindowStartupLocation.CenterScreen);
            messageBox5.Show(Aesthetic_Standard.Animation.Fade, WindowStartupLocation.CenterScreen);
            messageBox6.Show(Aesthetic_Standard.Animation.Null, WindowStartupLocation.CenterScreen);
        }
    }
}
