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
using System.Windows.Shapes;

namespace client_student
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            KeyDown += LoginWindow_KeyDown;
        }

        private Queue<Key> key_queue_colorful_egg = new();

        private void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            key_queue_colorful_egg.Enqueue(e.Key);
            if (key_queue_colorful_egg.Count > 4)
                key_queue_colorful_egg.Dequeue();
            if (key_queue_colorful_egg.Count == 4)
            {
                var arr = key_queue_colorful_egg.ToArray();
                if (arr[0].Equals(Key.F) && arr[1].Equals(Key.G) &&
                    arr[2].Equals(Key.C) && arr[3].Equals(Key.S))
                {
                    MessageBox.Show("这是彩蛋");
                }
            }
        }
    }
}
