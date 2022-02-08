using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using HalconDotNet;



namespace InteractiveROI
{	
    
    /// <summary>
    /// This project shows how to implement interactive ROIs using
    /// HALCON. It uses the classes HWndCtrl, ROI and ROIController will take
    /// care of the graphical output and the event handling of the mouse. You
    /// must assure that your HALCON window as well as your 
    /// ROIController instance are registered to the HWndCtrl instance.  
    /// You can use any kind of implementation for your graphical user
    /// interface. To create ROIs you must pass the GUI events to the
    /// ROIController. To add a new ROI shape, for example a circular
    /// interactive ROI, you must create a new class ROICircular, which
    /// inherits from ROI. The button for circular objects must then forward
    /// the request to the ROIController, similar to the way it is done for
    /// Rectangle1 and Rectangle2. 
    /// </summary>
    public class InteractiveForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button Rect2Button;
        public System.Windows.Forms.Button Rect1Button;
		
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.RadioButton radioButtonZoom;
		private System.Windows.Forms.RadioButton radioButtonMove;
        public System.Windows.Forms.Button ResetButton;
        public System.Windows.Forms.Button DelActROIButton;
		private System.Windows.Forms.Button ExitApplButton;
        private System.ComponentModel.Container components = null;

        
        /// <summary>HALCON window</summary>
        public HWindowControl   viewPort;
        /// <summary>Instance of HWndCtrl, which handles relevant view tasks</summary>
        public HWndCtrl     viewController;
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button CircArcButton;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        /// <summary>
        /// Instance of ROIController, which manages the ROI interactions
        /// </summary>
        public ROIController    roiController;
       

        
        /// <summary>Constructor</summary>
        public InteractiveForm()
		{
			InitializeComponent();
			
		}

        /*******************************************************************/
        protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		
		
		/********************************************************************/
		/*  Required method for Designer support - do not modify
			the contents of this method with the code editor.            
		/********************************************************************/
		private void InitializeComponent()
		{
            this.viewPort = new HalconDotNet.HWindowControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CircArcButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.CircleButton = new System.Windows.Forms.Button();
            this.DelActROIButton = new System.Windows.Forms.Button();
            this.Rect2Button = new System.Windows.Forms.Button();
            this.Rect1Button = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.radioButtonMove = new System.Windows.Forms.RadioButton();
            this.ExitApplButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewPort
            // 
            this.viewPort.BackColor = System.Drawing.Color.Black;
            this.viewPort.BorderColor = System.Drawing.Color.Black;
            this.viewPort.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.viewPort.Location = new System.Drawing.Point(53, 41);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(768, 517);
            this.viewPort.TabIndex = 0;
            this.viewPort.WindowSize = new System.Drawing.Size(768, 517);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.CircArcButton);
            this.groupBox1.Controls.Add(this.LineButton);
            this.groupBox1.Controls.Add(this.CircleButton);
            this.groupBox1.Controls.Add(this.DelActROIButton);
            this.groupBox1.Controls.Add(this.Rect2Button);
            this.groupBox1.Controls.Add(this.Rect1Button);
            this.groupBox1.Location = new System.Drawing.Point(864, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 259);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create ROI";
            // 
            // CircArcButton
            // 
            this.CircArcButton.Location = new System.Drawing.Point(29, 129);
            this.CircArcButton.Name = "CircArcButton";
            this.CircArcButton.Size = new System.Drawing.Size(96, 35);
            this.CircArcButton.TabIndex = 10;
            this.CircArcButton.Text = "Circular Arc";
            this.CircArcButton.Click += new System.EventHandler(this.CircArcButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(29, 164);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(96, 34);
            this.LineButton.TabIndex = 9;
            this.LineButton.Text = "Line";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.Location = new System.Drawing.Point(29, 95);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(96, 34);
            this.CircleButton.TabIndex = 8;
            this.CircleButton.Text = "Circle";
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // DelActROIButton
            // 
            this.DelActROIButton.Location = new System.Drawing.Point(29, 215);
            this.DelActROIButton.Name = "DelActROIButton";
            this.DelActROIButton.Size = new System.Drawing.Size(96, 35);
            this.DelActROIButton.TabIndex = 7;
            this.DelActROIButton.Text = "Delete Active ROI";
            this.DelActROIButton.Click += new System.EventHandler(this.DelActROIButton_Click);
            // 
            // Rect2Button
            // 
            this.Rect2Button.Location = new System.Drawing.Point(29, 60);
            this.Rect2Button.Name = "Rect2Button";
            this.Rect2Button.Size = new System.Drawing.Size(96, 35);
            this.Rect2Button.TabIndex = 1;
            this.Rect2Button.Text = "Rectangle2";
            this.Rect2Button.Click += new System.EventHandler(this.Rect2Button_Click);
            // 
            // Rect1Button
            // 
            this.Rect1Button.Location = new System.Drawing.Point(29, 26);
            this.Rect1Button.Name = "Rect1Button";
            this.Rect1Button.Size = new System.Drawing.Size(96, 34);
            this.Rect1Button.TabIndex = 0;
            this.Rect1Button.Text = "Rectangle1";
            this.Rect1Button.Click += new System.EventHandler(this.Rect1Button_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(893, 474);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(96, 43);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset All";
            this.ResetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.radioButtonNone);
            this.groupBox2.Controls.Add(this.radioButtonZoom);
            this.groupBox2.Controls.Add(this.radioButtonMove);
            this.groupBox2.Location = new System.Drawing.Point(864, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 109);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Interaction";
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.Checked = true;
            this.radioButtonNone.Location = new System.Drawing.Point(29, 84);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(96, 17);
            this.radioButtonNone.TabIndex = 2;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "none";
            this.radioButtonNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonNone.CheckedChanged += new System.EventHandler(this.noneButton_Click);
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.Location = new System.Drawing.Point(29, 52);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(96, 26);
            this.radioButtonZoom.TabIndex = 1;
            this.radioButtonZoom.Text = "zoom";
            this.radioButtonZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonZoom.CheckedChanged += new System.EventHandler(this.zoomButton_Click);
            // 
            // radioButtonMove
            // 
            this.radioButtonMove.Location = new System.Drawing.Point(29, 20);
            this.radioButtonMove.Name = "radioButtonMove";
            this.radioButtonMove.Size = new System.Drawing.Size(96, 26);
            this.radioButtonMove.TabIndex = 0;
            this.radioButtonMove.Text = "move";
            this.radioButtonMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonMove.CheckedChanged += new System.EventHandler(this.moveButton_Click);
            // 
            // ExitApplButton
            // 
            this.ExitApplButton.Location = new System.Drawing.Point(893, 517);
            this.ExitApplButton.Name = "ExitApplButton";
            this.ExitApplButton.Size = new System.Drawing.Size(96, 43);
            this.ExitApplButton.TabIndex = 6;
            this.ExitApplButton.Text = "Exit Application";
            this.ExitApplButton.Click += new System.EventHandler(this.ExitApplButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "OPEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // InteractiveForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1048, 570);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExitApplButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.ResetButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InteractiveForm";
            this.Text = "Interactive ROI";
            this.Load += new System.EventHandler(this.InteractiveForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion


        /*******************************************************************/
       	[STAThread]
		static void Main() 
		{
			Application.Run(new InteractiveForm());
		}
               
        
        /// <summary>Creates a ROI of the shape Rectangle1; invoked by the corresponding button.</summary>
        private void Rect1Button_Click(object sender, System.EventArgs e)
		{
			roiController.setROIShape(new ROIRectangle1());            
		}
		
        /// <summary>Creates a ROI of the shape Rectangle2; invoked by the corresponding button.</summary>
        private void Rect2Button_Click(object sender, System.EventArgs e)
		{
			roiController.setROIShape(new ROIRectangle2());            
		}

        /// <summary>Creates a ROI of a circle shape; invoked by the corresponding button.</summary>
        private void CircleButton_Click(object sender, System.EventArgs e)
        {
            roiController.setROIShape(new ROICircle());
        }

        /// <summary>Creates a ROI of a circular arc shape; invoked by the corresponding button.</summary>
        private void CircArcButton_Click(object sender, System.EventArgs e)
        {
            roiController.setROIShape(new ROICircularArc());
        }

        /// <summary>Creates a ROI of a linear shape; invoked by the corresponding button.</summary>
        private void LineButton_Click(object sender, System.EventArgs e)
        {
            roiController.setROIShape(new ROILine());
        }
		      

        /// <summary>Resets the application; invoked by the corresponding button.</summary>
        private void resetButton_Click(object sender, System.EventArgs e)
		{		
			viewController.resetAll();
			viewController.repaint();
		}
		
        /// <summary>When the corresponding radio button is checked, mouse events trigger more actions.</summary>
       	private void moveButton_Click(object sender, System.EventArgs e)
		{
            viewController.setViewState(HWndCtrl.MODE_VIEW_MOVE);
		}
		
        /// <summary>When the corresponding radio button is checked, mouse events trigger zoom actions.</summary>
       	private void zoomButton_Click(object sender, System.EventArgs e)
		{
            viewController.setViewState(HWndCtrl.MODE_VIEW_ZOOM);
		}
		
        /// <summary>When the corresponding radio button is checked, mouse events don't trigger any action.</summary>
        private void noneButton_Click(object sender, System.EventArgs e)
        {
            viewController.setViewState(HWndCtrl.MODE_VIEW_NONE);
		}
		
        /// <summary>Deletes the active ROI; invoked by the corresponding button.</summary>
       	private void DelActROIButton_Click(object sender, System.EventArgs e)
		{
			roiController.removeActive();
		}

	    /// <summary>Executes the program; invoked by the corresponding button.</summary>
        private void ExitApplButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        /// <summary> 
        /// Defines the initial settings for the window 
        /// control. In the very beginning, the window control needs 
        /// to know the view mode of the application form to perform 
        /// the right behavior for incoming mouse events on the 
        /// HALCON window.
        /// </summary>
        private void InteractiveForm_Load(object sender, System.EventArgs e)
		{   
          
		}

        private void button1_Click(object sender, EventArgs e)
        {
            String fileName = "patras";
            HImage image;

            viewController = new HWndCtrl(viewPort);
            roiController = new ROIController();
            viewController.useROIController(roiController);
            viewController.setViewState(HWndCtrl.MODE_VIEW_NONE);
            #region 打开文件
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "JPEG文件|*.jpg*|BMP文件|*.bmp*|TIFF文件|*.tiff*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                
                image = new HImage(fileName);

                viewController.addIconicVar(image);
                viewController.repaint();
            }   
            #endregion
            

        }

        

          
	}//end of class
}//end of namespace
