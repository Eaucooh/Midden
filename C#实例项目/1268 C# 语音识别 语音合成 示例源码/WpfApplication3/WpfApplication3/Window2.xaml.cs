using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Net;

namespace WpfApplication3
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofp = new OpenFileDialog();//是调用文件浏览器控件；
            if (ofp.ShowDialog() == System.Windows.Forms.DialogResult.OK)//是判断文件浏览器控件是否返回ok，即用户是否确定选择。
            {
                //  textbox1.Text = ofp.FileName.Replace(ofp.SafeFileName, "");
                textbox1.Text = ofp.FileName;//如果确定选择，则弹出用户在文件浏览器中选择的路径：
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //先选择一个音频文件,准备好要Post发送的数据
            string audio = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择一个音频文件进行语音转文字";
                ofd.Filter = "未压缩的声音|*.wav;*.pcm";
                ofd.ShowDialog();
                textbox1.Text = ofd.FileName;//如果确定选择，则弹出用户在文件浏览器中选择的路径：
                if (ofd.FileName == "")
                {
                    return;
                }
                //读取文件进行base64编码
                using (System.IO.FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    string base64Audio = Convert.ToBase64String(array);
                    string text = System.Web.HttpUtility.HtmlEncode(base64Audio);
                    audio = System.Web.HttpUtility.UrlEncode(text);
                    //编码后长度不超过2兆
                    if (Encoding.UTF8.GetByteCount(audio) > 2 * 1024 * 1024)
                    {
                        System.Windows.Forms.MessageBox.Show("文件超过了2兆，无法提交！", "文件太大", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }

            //获取appid、apikey、curTime
            String appId = ConfigurationManager.AppSettings["appId"];
            String apiKey = ConfigurationManager.AppSettings["apiKeySTT"];
            String realIp = ConfigurationManager.AppSettings["realIp"];
            String curTime = Utils.ConvertDateTimeLong(DateTime.Now).ToString();
            //计算校验和
            Dictionary<string, string> xParams = new Dictionary<string, string>();
            xParams.Add("engine_type", ConfigurationManager.AppSettings["engine_typeSTT"]);
            xParams.Add("aue", ConfigurationManager.AppSettings["aueSTT"]);
            string json = JsonConvert.SerializeObject(xParams);
            string param = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            String checkSum = Utils.GetMD5(apiKey + curTime + param);

            HttpWebRequest req = WebRequest.CreateHttp("http://api.xfyun.cn/v1/service/v1/iat");
            req.Method = "POST";
            //设置请求头
            req.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            req.Headers.Add("X-Appid", appId);
            req.Headers.Add("X-CurTime", curTime);
            req.Headers.Add("X-Param", param);
            req.Headers.Add("X-Real-Ip", realIp);
            req.Headers.Add("X-CheckSum", checkSum);

            //将base64编码的音频文件写入到post数据
            using (Stream stream = req.GetRequestStream())
            {
                byte[] buffer = Encoding.UTF8.GetBytes("audio=" + audio);
                stream.Write(buffer, 0, buffer.Length);
            }

            //获取响应流
            using (Stream stream = req.GetResponse().GetResponseStream())
            {
                //将响应json反序列化为对象
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                string retString = streamReader.ReadToEnd();
                ErrorCode errCode = JsonConvert.DeserializeObject<ErrorCode>(retString);
                ErrorMessage errMsg = new ErrorMessage(errCode);

                if (errCode.Code == 0)
                {
                    //如果成功，显示转换后的字符串
                    txt.Text = errMsg.ToString();
                }
                else
                {
                    //如果获取失败，输出错误信息
                    txt.Text = errMsg.ToString() + Environment.NewLine + errCode.ToString();//retString;
                }

            }

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {


        }
    }
}
