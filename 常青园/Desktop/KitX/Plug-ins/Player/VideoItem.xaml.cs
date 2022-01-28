using System.Windows.Controls;

namespace Player
{
    /// <summary>
    /// VideoItem.xaml 的交互逻辑
    /// </summary>
    public partial class VideoItem : UserControl
    {
        public string fileName { get; set; }

        public string filePath { get; set; }

        public double width { get; set; }

        public VideoItem()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                tbl.Text = fileName;
                rgd.Width = width;
            };
        }
    }
}
