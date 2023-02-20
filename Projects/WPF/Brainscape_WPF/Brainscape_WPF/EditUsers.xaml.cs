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
//using System.Web.UI.WebControls;
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
    /// EditUsers.xaml 的交互逻辑
    /// </summary>
    public partial class EditUsers : Window
    {
        private string filePath;
        private string serverPath;     
      
        public EditUsers()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            UserMessage um = new UserMessage();
            EditUserGrid.DataContext = um;
            string activeDir = @"D:\Brainscape";
            string newPath = System.IO.Path.Combine(activeDir, "UserImages");
            System.IO.Directory.CreateDirectory(newPath);



           
        }
        // public string Label;
        public bool EditModel { get; set; }
        public string Label { get; set; }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            UserMessage edit = (UserMessage)EditUserGrid.DataContext;
            if (Label == "添加")
            {

                if (Yanzheng())
                {
                    if (serverPath == null)
                    {
                        serverPath = @"../../Images/d3.png";
                        edit.UserPicture = serverPath;
                       
                    }
                    else
                    {
                        UploadFile(filePath, serverPath);
                        edit.UserPicture = serverPath;
                      
                    }
                    if (textBox3.Text == "False")
                    {
                        edit.VIPStartTime = "";
                        edit.VIPEndTime = "";
                    }
                    UserMessageBll.AddUser(edit);
                    this.Close();
                }
               

            }
           if (Label == "修改")
          
            {

                if (Yanzheng())
                {

                    if (serverPath != null)
                    {
                        UploadFile(filePath, serverPath);
                        edit.UserPicture = serverPath;                     
                    }

                    if (textBox3.Text == "False")
                    {
                        edit.VIPStartTime = "";
                        edit.VIPEndTime = "";
                    }

                    UserMessageBll.UpdateUser(edit);
                        this.Close();

                }
               
              
            }
           if(Label == "详情")
            this.Close();


        }

        //  验证手机号码的主要代码如下：
        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"[0-9]{11,11}");
        }
   
      //  验证输入为数字的主要代码如下：
   public bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");
        }
        //  验证邮箱的主要代码如下：
        public bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+");
        }

        public bool Yanzheng()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox7.Text == "" ||textBox9.Text == "" || textBox10.Text == "" ||  textBox12.Text == "" || textBox13.Text == "")
            {
                label15.Content = "*请填写完整资料！";
                return false;
            }
          

            else if (IsEmail(textBox1.Text) != true)
            {
                label15.Content = "*请输入正常的邮箱地址！";
                return false;
            }

            else if (IsHandset(textBox2.Text) != true)
            {
                label15.Content = "*请输入正常的手机地址！";
                return false;
            }
         
            else if (textBox3.Text != "False" && textBox3.Text != "True")
            {
                label15.Content = "*会员状态必须要为False或者True！";
                return false;
            }
            else if (textBox3.Text == "True" )
            {
                if (textBox4.Text == "" || textBox5.Text == "")
                {
                    label15.Content = "*请填写完整资料！";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            else if (UserMessageBll.UserQueryID(textBox6.Text) > 0)
            {
                if (EditModel == true)
                {
                    label15.Content = "*该账号已被注册，请重新输入！";
                    return false;
                }
                else 
                        { return true; }
            }
                 
            else
                return true;
           
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"图片|*.jpg;*.png;*.jpeg;*.bmp;*.ico";

            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
               


                //根据图片路径获取文件名  
                char[] separator = { '\\' };
                string[] partPath = filePath.Split(separator);
                string imageName = partPath[partPath.Length - 1];

                serverPath = @"D:/Brainscape/UserImages/"+ System.Guid.NewGuid().ToString("N") + imageName;

               
                image.Source = new BitmapImage(new Uri(filePath));
              
            }
        }

     
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserMessage edit = (UserMessage)EditUserGrid.DataContext;
            image.Source = new BitmapImage(new Uri(edit.UserPicture, UriKind.RelativeOrAbsolute));


            if (Label == "添加")
            {
                this.EditText.Content = "增加用户：";
                btnOK.Content = "添加";

            }

          else  if (Label == "修改")
            {

                this.EditText.Content = "修改用户：";
                btnOK.Content = "修改";

            }
          else  if (Label == "详情")
            {
          
                this.button2.Visibility = Visibility.Hidden;
            this.EditText.Content = "用户详情：";
            btnOK.Content = "确定";
            }

           


        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox3.Text == "False")
            {
                textBox4.IsReadOnly = true;
                textBox4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB9D1EA"));
                textBox5.IsReadOnly = true;
                textBox4.Text = "";
                textBox5.Text = "";
              
                textBox5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB9D1EA"));
            }
            else if (textBox3.Text == "True")
            {
              
                textBox4.IsReadOnly = false;
                textBox4.Background = new SolidColorBrush(Colors.White);
                textBox5.Background= new SolidColorBrush(Colors.White);
                textBox5.IsReadOnly = false;
            }
        }
    }
}
