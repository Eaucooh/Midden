using System;
using System.IO;
using System.Net;
using System.Windows;                       //STANDARD for WPF App
using System.Windows.Controls;              //STANDARD for WPF App
using System.Windows.Data;                  //STANDARD for WPF App
using System.Windows.Media.Animation;       //STANDARD for WPF App
using System.Windows.Navigation;            //STANDARD for WPF App
using System.Windows.Controls.Primitives;   //STANDARD for WPF App
using System.Windows.Media;                 //For : DrawingGroup
using System.Windows.Shapes;                //For : Geometric shapes like Line
using System.Windows.Input;                 //For : ExecutedRoutedEventArgs
using Microsoft.Win32;                      //For : OpenFileDialog / SaveFileDialog
using System.Windows.Ink;                   //For : InkCanvas
using System.Windows.Markup;                //For : XamlWriter
using System.Windows.Media.Imaging;         //For : BitmapImage etc etc
using System.Windows.Input.StylusPlugIns;   //For : DrawingAttributes

namespace BitsOfStuff
{



	public partial class InkPadWindow
	{

        // Make the pad 4 inches by 5 inches.
        public static readonly double widthCanvas=8*96;
        public static readonly double heightCanvas=5*96;
        
        public InkPadWindow()
		{
            

			this.InitializeComponent();

            this.radInk.IsChecked = true;
            this.fishButtons.Magnification = 3.5;

            // Draw blue horizontal lines 1/4 inch apart.
            double y = 24;

            while (y < heightCanvas)
            {
                Line line = new Line();
                line.X1 = 0;
                line.Y1 = y;
                line.X2 = widthCanvas;
                line.Y2 = y;
                line.Stroke = Brushes.LightBlue;
                this.inkCanv.Children.Add(line);

                y += 24;
            }

		}

        // New command: just clear all the strokes.
        private void btnNew_Click(object sender, RoutedEventArgs args)
        {
            this.inkCanv.Strokes.Clear();
            
        }

        // Open command: display OpenFileDialog and load ISF file.
        private void btnOpen_Click(object sender, RoutedEventArgs args)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "All files (*.*)|*.*";

            if ((bool)dlg.ShowDialog(this))
            {
                this.inkCanv.Strokes.Clear();

                try
                {
                    using(FileStream file = new FileStream(dlg.FileName,
                                                FileMode.Open, FileAccess.Read))
                    {
                        if (!dlg.FileName.ToLower().EndsWith(".isf"))
                        {
                            MessageBox.Show("The requested file is not a Ink Serialized Format file\r\n\r\nplease retry", Title);
                        }
                        else
                        {
                            this.inkCanv.Strokes = new StrokeCollection(file);
                            file.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }
        }
        // File Save : display SaveFileDialog.
        private void btnSave_Click(object sender, RoutedEventArgs args)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "Bitmap files (*.bmp)|*.bmp";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    using (FileStream file = new FileStream(dlg.FileName,
                                            FileMode.Create, FileAccess.Write))
                    {
                        //Ink Serialized Format
                        if (dlg.FilterIndex == 1)
                        {
                            this.inkCanv.Strokes.Save(file);
                            file.Close();
                        }
                        //bitmap object
                        else
                        {
                            int marg = int.Parse(this.inkCanv.Margin.Left.ToString());
                            RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.inkCanv.ActualWidth - marg,
                                            (int)this.inkCanv.ActualHeight - marg, 0, 0, PixelFormats.Default);
                            rtb.Render(this.inkCanv);
                            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(rtb));
                            encoder.Save(file);
                            file.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }

            }
        }

        // Cut command: cut all selected strokes
        private void btnCut_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CutSelection();
        }

        // Copy command: copy all selected strokes
        private void btnCopy_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
                this.inkCanv.CopySelection();
        }

        // Paste command: paste all selected strokes
        private void btnPaste_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.CanPaste())
                this.inkCanv.Paste();
        }

        // Delete command: delete all selected strokes
        private void btnDelete_Click(object sender, RoutedEventArgs args)
        {
            if (this.inkCanv.GetSelectedStrokes().Count > 0)
            {
                foreach (Stroke strk in this.inkCanv.GetSelectedStrokes())
                    this.inkCanv.Strokes.Remove(strk); 
            }
        }

        // SelectAll command: select all strokes
        private void btnSelectAll_Click(object sender, RoutedEventArgs args)
        {
            this.inkCanv.Select(this.inkCanv.Strokes);
        }

        private void rad_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            this.inkCanv.EditingMode = (InkCanvasEditingMode)rad.Tag;
        }

        private void txtExit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.popAbout.IsOpen = false;
            this.popExit.IsOpen = true;
        }

        private void txtAbout_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.popExit.IsOpen = false;
            this.popAbout.IsOpen = true;
        }

        private void txtPopClose_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.popAbout.IsOpen = false;
        }



        private void txtPopExitClose_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.popExit.IsOpen = false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.popExit.IsOpen = false;
        }

        private void penSize_Click(object sender, RoutedEventArgs e)
        {

            RadioButton rad = sender as RadioButton;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Width = rad.FontSize;
            inkDA.Height = rad.FontSize;
            inkDA.Color = this.inkCanv.DefaultDrawingAttributes.Color;
            inkDA.IsHighlighter = this.inkCanv.DefaultDrawingAttributes.IsHighlighter;
            this.inkCanv.DefaultDrawingAttributes = inkDA;
            this.expB.IsExpanded = false;
        }

        private void btnStylusSettings_Click(object sender, RoutedEventArgs e)
        {

            StylusSettings dlg = new StylusSettings();
            dlg.Owner = this;
            dlg.DrawingAttributes = this.inkCanv.DefaultDrawingAttributes;
            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                this.inkCanv.DefaultDrawingAttributes = dlg.DrawingAttributes;
            }
        }

        private void btnFormat_Click(object sender, RoutedEventArgs e)
        {

            StylusSettings dlg = new StylusSettings();
            dlg.Owner = this;

            // Try getting the DrawingAttributes of the first selected stroke.
            StrokeCollection strokes = this.inkCanv.GetSelectedStrokes();

            if (strokes.Count > 0)
                dlg.DrawingAttributes = strokes[0].DrawingAttributes;
            else
                dlg.DrawingAttributes = this.inkCanv.DefaultDrawingAttributes;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                // Set the DrawingAttributes of all the selected strokes.
                foreach (Stroke strk in strokes)
                    strk.DrawingAttributes = dlg.DrawingAttributes;
            }


        }

        




 

    }
}