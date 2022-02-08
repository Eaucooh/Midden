using Bll;
using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Brainscape_WPF
{
    /// <summary>
    /// EditContent.xaml 的交互逻辑
    /// </summary>
    public partial class EditContent : Window
    {
        public EditContent()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            SubjectContent m = new SubjectContent();
            EditContentGrid.DataContext = m;
            string activeDir = @"D:\Brainscape";
            string newPath = System.IO.Path.Combine(activeDir, "CardImages");
            System.IO.Directory.CreateDirectory(newPath);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubjectContent edit = (SubjectContent)EditContentGrid.DataContext;
            image.Source = new BitmapImage(new Uri(edit.QuestionPicture, UriKind.RelativeOrAbsolute));
            image1.Source = new BitmapImage(new Uri(edit.Answerpicture, UriKind.RelativeOrAbsolute));

            if (EditModel == true)
            {


                this.EditText.Content = "增加管理员：";
                OKbtn.Content = "添加";



            }
            else
            {
                this.EditText.Content = "修改管理员：";
                OKbtn.Content = "修改";
            }
        }
        private string fileQuestionPath;
        private string fileAnswerPath;
        private string serverQuestionPath;
        private string serverAnswerPath;
        public string SectionID;
        /// 上传文件方法
        /// </summary>
        /// <param name="filePath">本地文件所在路径（包括文件）</param>
        /// <param name="serverPath">文件存储服务器路径（包括文件）</param>
        public void UploadFile(string filePath, string serverPath)
        {
            //创建WebClient实例
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            //要上传的文件 
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] postArray = br.ReadBytes((int)fs.Length);
            Stream postStream = webClient.OpenWrite(serverPath, "PUT");
            try
            {
                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                    fs.Dispose();
                }
                else
                {
                    postStream.Close();
                    fs.Dispose();
                }

            }
            catch (Exception ex)
            {
                postStream.Close();
                fs.Dispose();
                throw ex;
            }
            finally
            {
                postStream.Close();
                fs.Dispose();
            }
        }
        public bool EditModel { get; set; }
        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            SubjectContent edit = (SubjectContent)EditContentGrid.DataContext;


            if (EditModel == true)   //增加
            {
                if (Yanzheng())
                {
                    if (serverQuestionPath == null && serverAnswerPath != null)
                    {
                        edit.QuestionPicture = "";
                        UploadFile(fileAnswerPath, serverAnswerPath);
                        edit.Answerpicture = serverAnswerPath;
                    }
                   if (serverQuestionPath != null && serverAnswerPath == null)
                    {
                        UploadFile(fileQuestionPath, serverQuestionPath);
                        edit.Answerpicture = "";
                        edit.QuestionPicture = serverQuestionPath;
                                         
                    }
                   if (serverAnswerPath == null&& serverQuestionPath == null)
                    {
                        
                        edit.Answerpicture = "";
                        edit.QuestionPicture = "";
                        
                    }
                    if (serverAnswerPath != null&& serverQuestionPath != null)
                    {
                        UploadFile(fileAnswerPath, serverAnswerPath);
                        UploadFile(fileQuestionPath, serverQuestionPath);                      
                        edit.QuestionPicture = serverQuestionPath;
                        edit.Answerpicture = serverAnswerPath;     
                    }

                    edit.SectionID = SectionID;
                    SubjectContentBll.AddContent(edit);
                    this.Close();
                }
            }
            else              //编辑
            {
                if (Yanzheng())
                {
                    if (serverQuestionPath == null && serverAnswerPath != null)
                    {
                       // edit.QuestionPicture = "";
                        UploadFile(fileAnswerPath, serverAnswerPath);
                        edit.Answerpicture = serverAnswerPath;
                    }
                    if (serverQuestionPath != null && serverAnswerPath == null)
                    {
                        UploadFile(fileQuestionPath, serverQuestionPath);
                       // edit.Answerpicture = "";
                        edit.QuestionPicture = serverQuestionPath;

                    }
                 
                    if (serverAnswerPath != null && serverQuestionPath != null)
                    {
                        UploadFile(fileAnswerPath, serverAnswerPath);
                        UploadFile(fileQuestionPath, serverQuestionPath);
                        edit.QuestionPicture = serverQuestionPath;
                        edit.Answerpicture = serverAnswerPath;
                    }

                    edit.SectionID = SectionID;
                    SubjectContentBll.UpdateContent(edit);
                    this.Close();
                   



                }
            }
        }

        public bool Yanzheng()
        {
            if (textBox.Text == "" || textBox1.Text == "")
            {

                label.Content = "*问题或答案不能为空！";
                return false;
            }
            else
            {
                label.Content = "";
                return true;
            }

        }
        private void btnQuestionPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"图片|*.jpg;*.png;*.jpeg;*.bmp;*.ico";

            if (ofd.ShowDialog() == true)
            {
                fileQuestionPath = ofd.FileName;



                //根据图片路径获取文件名  
                char[] separator = { '\\' };
                string[] partPath = fileQuestionPath.Split(separator);
                string imageName = partPath[partPath.Length - 1];

                serverQuestionPath = @"D:/Brainscape/CardImages/"+ System.Guid.NewGuid().ToString("N") + imageName;


                image.Source = new BitmapImage(new Uri(fileQuestionPath));

            }
        }

        private void btnAnswerPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"图片|*.jpg;*.png;*.jpeg;*.bmp;*.ico";

            if (ofd.ShowDialog() == true)
            {
                fileAnswerPath = ofd.FileName;



                //根据图片路径获取文件名  
                char[] separator = { '\\' };
                string[] partPath = fileAnswerPath.Split(separator);
                string imageName = partPath[partPath.Length - 1];

                serverAnswerPath = @"D:/Brainscape/CardImages/" + System.Guid.NewGuid().ToString("N") + imageName;


                image1.Source = new BitmapImage(new Uri(fileAnswerPath));

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
