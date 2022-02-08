using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 车辆识别框架
{
    public partial class Form1 : Form
    {
        //需要自行从这里申请创建API_KEY与SECRET_KEY
        //http://ai.baidu.com/tech/ocr/plate
        public string API_KEY = "从百度申请apikey";
        public string SECRET_KEY = "从百度申请secrectkey";
        public string FILE_PATH = "";

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            //初始化路径为我的图片目录
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    FILE_PATH = dialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("您没有选择图片");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FILE_PATH)) {
                MessageBox.Show("您没有选择图片");
                return;
            }
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            var image = File.ReadAllBytes(FILE_PATH);
            // 调用车牌识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.LicensePlate(image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"multi_detect", "true"}
    };
            // 带参数调用车牌识别
            result = client.LicensePlate(image, options);
            Console.WriteLine(result);
            this.txtResult.Text = result["words_result"][0]["number"].ToString();
            
        }

    }


}
