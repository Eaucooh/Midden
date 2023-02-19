using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Reflection;                    //For : Obtaining brushes through reflection
using System.Windows.Ink;                   //For : InkCanvas


namespace BitsOfStuff
{
	public partial class StylusSettings
	{
        Color currColor = Colors.Black;
        double penWidth = 2;
        double penHeight = 2;

		public StylusSettings()
		{
			this.InitializeComponent();
			// Insert code required on object creation below this point.
            createGridOfColor();
            
		}

        private void createGridOfColor()
        {

            
            PropertyInfo[] props = typeof(Brushes).GetProperties(BindingFlags.Public |
                                                  BindingFlags.Static);
            // Create individual items
            foreach (PropertyInfo p in props)
            {
                Button b = new Button();
                b.Background = (SolidColorBrush)p.GetValue(null, null);
                b.Foreground = Brushes.Transparent;
                b.BorderBrush=Brushes.Transparent;
                b.Click += new RoutedEventHandler(b_Click);
                this.ugColors.Children.Add(b);
            }
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush sb = (SolidColorBrush)(sender as Button).Background;
            currColor = sb.Color;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


        // Public property initializes controls and returns their values.
        public DrawingAttributes DrawingAttributes
        {
            set
            {
                chkPressure.IsChecked = value.IgnorePressure;
                chkHighlight.IsChecked = value.IsHighlighter;
                penWidth = value.Width;
                penHeight = value.Height;
                currColor = value.Color;
            }
            get
            {
                DrawingAttributes drawattr = new DrawingAttributes();
                drawattr.IgnorePressure = (bool)chkPressure.IsChecked;
                drawattr.Width=penWidth;
                drawattr.Height = penHeight;
                drawattr.IsHighlighter = (bool)chkHighlight.IsChecked;
                drawattr.Color = currColor;
                return drawattr;
            }
        }


	}
}