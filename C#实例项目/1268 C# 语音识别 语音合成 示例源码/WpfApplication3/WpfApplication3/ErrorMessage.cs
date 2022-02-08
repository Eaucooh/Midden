using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class ErrorMessage
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        public string Strategy { get; set; }
        public string Reason { get; set; }
        public string Data { get; set; }

        public ErrorMessage(ErrorCode e)
        {
            Code = e.Code;
            Description = e.Desc;
            switch (e.Code)
            {
                case 0:
                    Data = e.Data;
                    break;
                case 10105:
                    Explanation = "没有权限";
                    Strategy = "检查apiKey，ip，checkSum等授权参数是否正确";
                    Reason = @"
· APIKey混用（不同能力的Key是不同的，开放平台控制台和AIUI控制台的Key也是不同的）
· IP白名单未配置或未生效
· checkSum计算错误";
                    break;
                case 10106:
                    Explanation = "无效参数";
                    Strategy = "上传必要的参数， 检查参数格式以及编码";
                    Reason = @"
· 参数与文档不符 
· 参数值不在范围内 
· 编码引起的参数问题
· 对body的参数没有进行urlencode处理";
                    break;
                case 10107:
                    Explanation = "非法参数值";
                    Strategy = "检查参数值是否超过范围或不符合要求";
                    Reason = @"";
                    break;
                case 10109:
                    Explanation = "文本/音频长度非法";
                    Strategy = "检查上传文本/音频长度是否超过限制";
                    Reason = @"";
                    break;
                case 10110:
                    Explanation = "无授权许可";
                    Strategy = "提供请求的 appid、 auth_id 向服务商反馈";
                    Reason = @"";
                    break;
                case 10114:
                    Explanation = "超时";
                    Strategy = "检测网络连接或联系服务商";
                    Reason = @"
·curTime与标准时间有时差
·curTime单位应为秒(10位数字)，而非毫秒(13位数字)";
                    break;
                case 10700:
                    Explanation = "引擎错误";
                    Strategy = "提供接口返回值，向服务商反馈";
                    Reason = @"
·音频格式不符合要求
·试题格式错误";
                    break;
                case 11200:
                    Explanation = "无授权";
                    Strategy = "确认是否使用了未授权的功能点，例如部分识别语种、合成发音人、高阶评测等等，如果需要申请购买相关授权请提交工单";
                    Reason = @"
· 使用了未开通权限的发音人
· 使用了未授权的识别方言或者语种
· 使用了未授权的高阶评测功能";
                    break;
                case 11201:
                    Explanation = "服务单日调用次数超过限制";
                    Strategy = "确认服务单日调用次数是否超过限制";
                    Reason = @"";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 将错误信息转为等效的字符串形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Code == 0)
            {
                sb.Append(Data);
            }
            else
            {
                sb.AppendFormat("错误码：");
                sb.AppendLine(Code.ToString());
                sb.Append("描述：");
                sb.AppendLine(Description);
                sb.Append("说明：");
                sb.AppendLine(Explanation);
                sb.Append("处理方式：");
                sb.AppendLine(Strategy);
                sb.Append("常见原因：");
                sb.AppendLine(Reason);
                sb.Append("详细请查看：");
                sb.AppendLine("https://doc.xfyun.cn/rest_api/错误码.html");
            }

            return sb.ToString();
        }
    }
}
