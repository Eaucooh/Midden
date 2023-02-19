using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Library.TextHelper
{
    /// <summary>
    /// 加密算法入口
    /// </summary>
    public class Coder
    {
        /// <summary>
        /// 标准加密返回器
        /// </summary>
        public struct Result
        {
            public string key;
            public string value;
        }

        /// <summary>
        /// RIET - Random Index of Every Text - 随机序列加密算法
        /// MSC - Mixed Scale Converter - 混合进制加密算法
        /// DES - Data Encryption Standard - 数据加密标准
        /// AES - Rijndael 加密法 - Advanced Encryption Standard - 高级加密标准
        /// </summary>
        public enum ALG { RIET = 0, MSC = 1, DES = 2, AES = 3, RC4 = 4 }

        /// <summary>
        /// 加密函数入口
        /// 返回加密之后的秘钥和加密文本
        /// </summary>
        /// <param name="source">被加密的源文本</param>
        /// <param name="pwd">密码</param>
        /// <returns>秘钥和加密文本</returns>
        public static Result Encrypt(string source, string pwd, string key, ALG alg)
        {
            switch (alg)
            {
                case ALG.RIET:
                    return RIET.Encrypt(source);
                case ALG.MSC:
                    return new Result { };
                case ALG.DES:
                    return new Result { key = key, value = DES.StrEncryEDS(source, key) };
                case ALG.AES:
                    return new Result { key = key, value = AES.AESEncrypt(source, pwd, key) };
                case ALG.RC4:
                    return new Result { };
                default:
                    return new Result
                    {
                        key = "1234567890123456789",
                        value = "You selected nothing(loneliness)."
                    };
            }
        }

        /// <summary>
        /// 解密文本
        /// </summary>
        /// <param name="target">解密目标</param>
        /// <param name="pwd">密码</param>
        /// <param name="key">秘钥</param>
        /// <param name="alg">算法</param>
        /// <returns></returns>
        public static string Decrypt(string target, string pwd, string key, ALG alg)
        {
            switch (alg)
            {
                case ALG.RIET:
                    return RIET.Decrypt(target, key).value;
                case ALG.MSC:
                    return null;
                case ALG.AES:
                    return AES.AESDecrypt(target, pwd, key);
                case ALG.DES:
                    return DES.DESDecrtpt(target, key);
                case ALG.RC4:
                    return null;
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// RIET加密解密
    /// </summary>
    internal static class RIET
    {
        /// <summary>
        /// 随机序列加密算法
        /// </summary>
        /// <param name="source">源</param>
        /// <returns>返回标准加密算法返回器</returns>
        public static Coder.Result Encrypt(string source)
        {
            char[] arr = source.ToCharArray();
            char[] result = new char[arr.Length];
            int[] index = MathHelper.Basic.RandomIndexList(arr.Length);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arr[index[i]];
            }
            return new Coder.Result()
            {
                key = Basic.ArrayPrint(index, '\0', '\0', '-', true),
                value = Basic.ArrayPrint(result, '\0', '\0', '\0', false)
            };
        }

        /// <summary>
        /// 依据秘钥解码
        /// </summary>
        /// <param name="target">解码目标</param>
        /// <param name="key">秘钥</param>
        /// <returns>源码</returns>
        public static Coder.Result Decrypt(string target, string key)
        {
            #region 还原秘钥
            string[] index_temp = key.Replace(" ", null).Split('-');
            int[] index = new int[index_temp.Length];
            for (int i = 0; i < index.Length; i++)
            {
                index[i] = Convert.ToInt32(index_temp[i]);
            }
            #endregion

            char[] arr = target.ToCharArray();
            char[] result = new char[arr.Length];
            if (index.Length == arr.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = arr[index[i]];
                }
                return new Coder.Result
                {
                    key = null,
                    value = Basic.ArrayPrint(result, '\0', '\0', '\0', false)
                };
            }
            else
            {
                throw new Exception("Key error.");
            }
        }
    }

    /// <summary>
    /// MSC加密解密
    /// </summary>
    internal static class MSC
    {

    }

    /// <summary>
    /// AES加密解密
    /// </summary>
    internal static class AES
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="password">加密的密码</param>
        /// <param name="iv">密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(string text, string password, string iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            _ = Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = new byte[16];
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string password, string iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            byte[] encryptedData = Convert.FromBase64String(text);
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = ivBytes;
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }
    }

    /// <summary>
    /// DES加密解密
    /// </summary>
    internal static class DES
    {
        /// <summary>
        /// 将字符串进行DES加密
        /// </summary>
        /// <param name="encryString">准备要加密的字符串</param>
        /// <param name="encryKey">加密字符串时的密钥</param>
        /// <returns>返回一个加密后的字符串，若失败则返回原字符串</returns>
        public static string StrEncryEDS(string encryString, string encryKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryKey.Substring(0, 8));
                byte[] inputByteArry = Encoding.UTF8.GetBytes(encryString);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(rgbKey, rgbIV)
                    , CryptoStreamMode.Write);
                cs.Write(inputByteArry, 0, inputByteArry.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception)
            {

                return encryString;
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="pToDecrypt">加密后的字符串</param>
        /// <param name="key">加密时的密钥</param>
        /// <returns>返回一个解密后的字符串，若失败则返回原字符串并给出错误信息</returns>
        public static string DESDecrtpt(string pToDecrypt, string key)
        {
            try
            {
                byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                desc.Key = Encoding.UTF8.GetBytes(key);
                desc.IV = Encoding.UTF8.GetBytes(key);
                CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {

                return pToDecrypt + ex.Message;
            }
        }
    }

    /// <summary>
    /// RC4加密解密
    /// </summary>
    internal class RC4
    {
        public static byte[] Encrypt(byte[] pwd, byte[] data)
        {
            int a, i, j, k, tmp;
            int[] key, box;
            byte[] cipher;

            key = new int[256];
            box = new int[256];
            //打乱密码,密码,密码箱长度
            cipher = new byte[data.Length];
            for (i = 0; i < 256; i++)
            {
                key[i] = pwd[i % pwd.Length];
                box[i] = i;
            }
            for (j = i = 0; i < 256; i++)
            {

                j = (j + box[i] + key[i]) % 256;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < data.Length; i++)
            {
                a++;
                a %= 256;
                j += box[a];
                j %= 256;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(data[i] ^ k);
            }
            return cipher;
        }

        public static byte[] Decrypt(byte[] pwd, byte[] data)
        {
            return Encrypt(pwd, data);
        }

        internal static string Encrypt(string pwd, string data)
        {
            byte[] key = Encoding.ASCII.GetBytes(pwd);
            //byte[] key = strToToHexByte(pwd);
            byte[] buff = StrToToHexByte(data);
            byte[] rlt = Encrypt(key, buff);

            return ByteToHexStr(rlt);
        }

        internal static string Decrypt(string pwd, string data)
        {
            byte[] key = Encoding.ASCII.GetBytes(pwd);
            byte[] buff = StrToToHexByte(data);
            byte[] rlt = Decrypt(key, buff);
            return ByteToHexStr(rlt);
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] StrToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
    }

    /// <summary>
    /// Rc4加密 解密工具类
    /// </summary>
    internal class RC4Crypto
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public RC4Crypto()
        {
            Key = "123456";
            Encoding = Encoding.Default;
            EncodeMode = EncoderMode.Base64Encoder;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 编码模式
        /// </summary>
        public EncoderMode EncodeMode { get; set; }

        /// <summary>
        /// 实例方法
        /// </summary>
        public static RC4Crypto RC4 { get { return new RC4Crypto(); } }
        #endregion

        #region 方法
        /// <summary>
        /// 编码模式
        /// </summary>
        public enum EncoderMode
        {
            /// <summary>
            /// Base64模式
            /// </summary>
            Base64Encoder,
            /// <summary>
            /// 16进制模式
            /// </summary>
            HexEncoder
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public String Encrypt(String data)
        {
            return this.Encrypt(data, this.Key, this.EncodeMode);
        }

        /// <summary>
        /// 带编码模式的字符串加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="key">密码</param>
        /// <param name="em">编码模式</param>
        /// <returns>加密后经过编码的字符串</returns>
        public String Encrypt(String data, String key, EncoderMode em = EncoderMode.Base64Encoder)
        {
            if (string.IsNullOrEmpty(data)) return "";
            if (string.IsNullOrEmpty(key)) key = Key;
            if (em == EncoderMode.Base64Encoder)
                return Convert.ToBase64String(this.Encrypt(data.GetBytes(this.Encoding), key));
            else
                return this.ByteToHex(this.Encrypt(data.GetBytes(this.Encoding), key));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">密文</param>
        /// <returns></returns>
        public String Decrypt(String data)
        {
            return this.Decrypt(data, this.Key, this.EncodeMode);
        }

        /// <summary>
        /// 带编码模式的字符串解密
        /// </summary>
        /// <param name="data">要解密的数据</param>
        /// <param name="key">密码</param>
        /// <param name="em">编码模式</param>
        /// <returns>明文</returns>
        public String Decrypt(String data, String key, EncoderMode em)
        {
            if (string.IsNullOrEmpty(data)) return "";
            if (string.IsNullOrEmpty(key)) key = this.Key;
            if (em == EncoderMode.Base64Encoder)
                return this.Encoding.GetString(this.Decrypt(Convert.FromBase64String(data), key));
            else
                return this.Encoding.GetString(this.Decrypt(this.HexToByte(data), key));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="key">密码</param>
        /// <returns>加密后经过默认编码的字符串</returns>
        public String Encrypt(String data, String key)
        {
            return this.Encrypt(data, key, this.EncodeMode);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">要解密的经过编码的数据</param>
        /// <param name="key">密码</param>
        /// <returns>明文</returns>
        public String Decrypt(String data, String key)
        {
            return this.Decrypt(data, key, this.EncodeMode);
        }

        /// <summary>
        /// 16进制转换字节
        /// </summary>
        /// <param name="hex">字符串</param>
        /// <returns></returns>
        private Byte[] HexToByte(String hex)
        {
            Int32 iLen = hex.Length;
            if (iLen <= 0 || 0 != iLen % 2)
            {
                return null;
            }
            Int32 dwCount = iLen / 2;
            UInt32 tmp1, tmp2;
            Byte[] pbBuffer = new Byte[dwCount];
            for (Int32 i = 0; i < dwCount; i++)
            {
                tmp1 = (UInt32)hex[i * 2] - (((UInt32)hex[i * 2] >= (UInt32)'A') ? (UInt32)'A' - 10 : (UInt32)'0');
                if (tmp1 >= 16) return null;
                tmp2 = (UInt32)hex[i * 2 + 1] - (((UInt32)hex[i * 2 + 1] >= (UInt32)'A') ? (UInt32)'A' - 10 : (UInt32)'0');
                if (tmp2 >= 16) return null;
                pbBuffer[i] = (Byte)(tmp1 * 16 + tmp2);
            }
            return pbBuffer;
        }

        /// <summary>
        /// 字节转换16进制
        /// </summary>
        /// <param name="bytes">字节</param>
        /// <returns></returns>
        private String ByteToHex(Byte[] bytes)
        {
            if (bytes == null || bytes.Length < 1) return null;
            StringBuilder sbr = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                if ((UInt32)bytes[i] < 0) return null;
                UInt32 k = (UInt32)bytes[i] / 16;
                sbr.Append((Char)(k + ((k > 9) ? 'A' - 10 : '0')));
                k = (UInt32)bytes[i] % 16;
                sbr.Append((Char)(k + ((k > 9) ? 'A' - 10 : '0')));
            }
            return sbr.ToString();
        }

        /// <summary>
        /// 加密字节
        /// </summary>
        /// <param name="data">节字</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        private Byte[] Encrypt(Byte[] data, string key)
        {
            if (data == null || key == null) return null;
            Byte[] output = new Byte[data.Length];
            Int64 i = 0;
            Int64 j = 0;
            Byte[] mBox = GetKey(key.GetBytes(this.Encoding), 256);
            for (Int64 offset = 0; offset < data.Length; offset++)
            {
                i = (i + 1) % mBox.Length;
                j = (j + mBox[i]) % mBox.Length;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
                Byte a = data[offset];
                Byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                output[offset] = (Byte)((Int32)a ^ (Int32)b);
            }
            return output;
        }

        /// <summary>
        /// 解密字节
        /// </summary>
        /// <param name="data">字节</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        private Byte[] Decrypt(Byte[] data, String key)
        {
            return Encrypt(data, key);
        }

        /// <summary>
        /// 打乱密码
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="kLen">密码箱长度</param>
        /// <returns>打乱后的密码</returns>
        private Byte[] GetKey(Byte[] pass, Int32 kLen)
        {
            Byte[] mBox = new Byte[kLen];

            for (Int64 i = 0; i < kLen; i++)
            {
                mBox[i] = (Byte)i;
            }
            Int64 j = 0;
            for (Int64 i = 0; i < kLen; i++)
            {
                j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
            }
            return mBox;
        }
        #endregion
    }

    /// <summary>
    /// Rc4  扩展方法
    /// </summary>
    internal static class Rc4Extend
    {
        /// <summary>
        /// 字符串转数据流
        /// </summary>
        /// <param name="str"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string str, Encoding en)
        {
            return en.GetBytes(str);
        }
    }
}
