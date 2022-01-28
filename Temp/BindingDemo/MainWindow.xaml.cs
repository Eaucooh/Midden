using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using KitX.Core;

namespace BindingDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IContract))]
    public partial class MainWindow : Window, IContract
    {
        Student stu;

        public MainWindow()
        {
            InitializeComponent();

            stu = new Student();

            Binding binding = new Binding();
            binding.Source = stu;
            binding.Path = new PropertyPath("Name");

            BindingOperations.SetBinding(textBoxName, TextBox.TextProperty, binding);

            win = this;

            Closed += (x, y) =>
            {
                started = false;
            };
        }

        #region 接口实现
        public void End() => Close();

        public string GetDescribe_Complex() => "复杂描述";

        public string GetDescribe_Simple() => "简单描述";

        public string GetFileName() => "BindingDemo.dll";

        public string GetHelpLink() => "http://www.baidu.com/";

        public string GetHostLink() => "http://www.catrol.cn/";

        public BitmapImage GetIcon() => Resources["Icon"] as BitmapImage;

        public Languages GetLang() => Languages.general;

        public string GetName() => "BindingDemo";

        public string GetPublisher() => "常青园晚";

        QuickView quickview = new QuickView();

        public UserControl GetQuickView() => quickview;

        public Tags GetTag() => Tags.Program;

        public string GetVersion() => "v1.2.5";

        public Window GetWindow() => new MainWindow();

        public void SetTheme(Theme theme)
        {
            string t = "null";
            switch (theme)
            {
                case Theme.Light:
                    t = "亮";
                    break;
                case Theme.Dark:
                    t = "暗";
                    break;
            }
            MessageBox.Show(t);
        }

        string workbase;

        public void SetWorkBase(string path)
        {
            workbase = path;
            MessageBox.Show(workbase);
        }

        MainWindow win;
        bool started = true;

        public void Start()
        {
            if (!started)
            {
                win = new MainWindow();
                win.Show();
                started = true;
            }
            else
            {
                if (win.Visibility == Visibility.Hidden)
                {
                    win.Visibility = Visibility.Visible;
                }
                else
                {
                    win.Visibility = Visibility.Hidden;
                }
            }
        } 
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "Name";
        }
    }

    class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
}
