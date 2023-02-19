using Library.FileHelper;
using Library.TextHelper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace KitX.Helper
{
    public class MySQLConnection
    {
        protected string dbpwd = null;
        protected string connetStr = null;
        protected string miwen = null;
        protected string decryptpwd = null;
        protected string pwd = null;
        protected string decryptdecryptpwd = null;

        public MySQLConnection()
        {
            dbpwd = null;
            connetStr = "Data Source=nj-cynosdbmysql-grp-78iaftaz.sql.tencentcdb.com;port=21988;Database=accounts;pooling=false;CharSet=utf8;";
            Initialize();
        }

        public void Dispose()
        {
            cont.Close();
            cont.Dispose();
        }

        protected void Initialize()
        {
            LoadConfig();
            LoadPassword();
            LoadCS();
            cont = new MySqlConnection(connetStr);
            cont.Open();
        }

        MySqlConnection cont;

        protected MySqlDataReader GetReturn(string sql)
        {
            cont = new MySqlConnection(connetStr);
            cont.Open();
            MySqlCommand cmd = new MySqlCommand(sql, cont)
            {
                CommandType = CommandType.Text
            };
            MySqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();
            return reader;
        }

        public enum toolType
        {
            process, program, normal, design, system
        }

        private bool isReceiving = false;

        public List<string> GetIDs(toolType tt)
        {
            if (!isReceiving)
            {

                MySqlDataReader pwdItem = null;
                List<string> ids = new List<string>();
                isReceiving = true;
                switch (tt)
                {
                    case toolType.process:
                        pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgtag = 'Process';");
                        break;
                    case toolType.program:
                        pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgtag = 'Program';");
                        break;
                    case toolType.normal:
                        pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgtag = 'Normal';");
                        break;
                    case toolType.design:
                        pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgtag = 'Design';");
                        break;
                    case toolType.system:
                        pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgtag = 'System';");
                        break;
                }
                while (pwdItem.Read())
                {
                    ids.Add(pwdItem.GetString("pgid"));
                }
                pwdItem.Close();
                isReceiving = false;
                return ids;
            }
            else
            {
                return new List<string>();
            }
        }

        public string GetPWD(string id)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
            pwdItem.Read();
            string returning;
            try
            {
                returning = Coder.Decrypt(pwdItem.GetString("userpwd"), null, GetWID(GetID(id)), Coder.ALG.DES);
            }
            catch (Exception)
            {
                return "NULL";
            }
            pwdItem.Close();
            return returning;
        }

        public string GetName(string id)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
            pwdItem.Read();
            string returning;
            try
            {
                returning = pwdItem.GetString("username");
            }
            catch (Exception)
            {
                return "NULL";
            }
            pwdItem.Close();
            return returning;
        }

        public string GetID(string id)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
            pwdItem.Read();
            string returning;
            try
            {
                returning = pwdItem.GetString("userphone");
            }
            catch (Exception)
            {
                return "NULL";
            }
            return returning;
        }

        public int GetSex(string id)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
            pwdItem.Read();
            int returning;
            try
            {
                returning = pwdItem.GetInt16("usersex");
            }
            catch (Exception)
            {
                return -1;
            }
            return returning;
        }

        private string[] userInfosList = new string[7]
        {
            "username", "usermail", "usersign", "userlocation", "userjob", "userdescribe", "usereducationbackground"
        };

        public string[] GetUserInfo(string id)
        {
            try
            {
                var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
                pwdItem.Read();
                string[] returning = new string[7];
                for (int i = 0; i < userInfosList.Length; i++)
                {
                    try
                    {
                        returning[i] = pwdItem.GetString(userInfosList[i]);
                    }
                    catch (Exception)
                    {
                        returning[i] = "NULL";
                    }
                }
                pwdItem.Close();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetLatestVersion()
        {
            var pwdItem = GetReturn($"USE KitX;SELECT * FROM info WHERE build = 'latest';");
            pwdItem.Read();
            string returning;
            try
            {
                returning = pwdItem.GetString("version");
            }
            catch (Exception)
            {
                return "NULL";
            }
            return returning;
        }

        public DateTime GetBirth(string id)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';");
            pwdItem.Read();
            DateTime returning;
            try
            {
                returning = pwdItem.GetDateTime("userbirthday");
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
            return returning;
        }

        public byte[] GetIcon(string id)
        {
            try
            {
                cont = new MySqlConnection(connetStr);
                cont.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter($"USE accounts;SELECT * FROM users WHERE usermail = '{id}' OR userphone = '{id}';", cont);
                DataSet myds = new DataSet();
                sda.Fill(myds);
                byte[] returning = (byte[])myds.Tables[0].Rows[0]["usericon"];
                sda.Dispose();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UploadIcon(byte[] content, string id)
        {
            try
            {
                cont = new MySqlConnection(connetStr);
                cont.Open();
                string sendFileSql = $"USE accounts;UPDATE users SET usericon = ?file WHERE usermail = {id} OR userphone = {id};";
                MySqlCommand sendCmd = new MySqlCommand(sendFileSql, cont);
                sendCmd.Parameters.Add("?file", MySqlDbType.MediumBlob).Value = content;
                sendCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int AddUser(string id, string name, string pwd)
        {
            try
            {
                string sql = $"INSERT INTO `users` (`userphone`, `username`, `userpwd`, `usercreatedate`) VALUES ('{id}', '{name}', '{Coder.Encrypt(pwd, null, GetWID(id), Coder.ALG.DES).value}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
                cont = new MySqlConnection(connetStr);
                cont.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cont)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                string addConfSql = $"INSERT INTO `kitx` (`userphone`) VALUES ('{id}')";
                MySqlCommand addConf = new MySqlCommand(addConfSql, cont)
                {
                    CommandType = CommandType.Text
                };
                addConf.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool UploadInfo(string id, string[] keys, string[] values)
        {
            try
            {
                string sql = $"USE accounts;UPDATE `users` SET ";
                for (int i = 0; i < 8; i++)
                {
                    if (i == 7)
                    {
                        sql += $"`{keys[i]}`='{values[i]}' ";
                    }
                    else
                    {
                        sql += $"`{keys[i]}`='{values[i]}', ";
                    }
                }
                sql += $"WHERE `userphone`='{id}' OR `usermail`='{id}'";
                cont = new MySqlConnection(connetStr);
                cont.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cont)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] GetConfig(string id)
        {
            try
            {
                MySqlConnection msqc = new MySqlConnection(connetStr);
                msqc.Open();
                MySqlDataAdapter msda = new MySqlDataAdapter($"USE accounts;SELECT * FROM kitx WHERE userphone = {GetID(id)};", msqc);
                DataSet myds = new DataSet();
                msda.Fill(myds);
                byte[] returning = (byte[])myds.Tables[0].Rows[0]["userconfig"];
                msda.Dispose();
                msqc.Close();
                msqc.Dispose();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public byte[] GetKitXInstaller()
        {
            try
            {
                MySqlConnection msqc = new MySqlConnection(connetStr);
                msqc.Open();
                MySqlDataAdapter msda = new MySqlDataAdapter($"USE KitX;SELECT * FROM info WHERE build = 'latest';", msqc);
                DataSet myds = new DataSet();
                msda.Fill(myds);
                byte[] returning = (byte[])myds.Tables[0].Rows[0]["installer"];
                msda.Dispose();
                msqc.Close();
                msqc.Dispose();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UploadConfig(byte[] content, string id)
        {
            try
            {
                MySqlConnection msqc = new MySqlConnection(connetStr);
                msqc.Open();
                string sendFileSql = $"USE accounts;UPDATE kitx SET userconfig = ?file WHERE userphone = {GetID(id)};";
                MySqlCommand sendCmd = new MySqlCommand(sendFileSql, msqc);
                sendCmd.Parameters.Add("?file", MySqlDbType.MediumBlob).Value = content;
                sendCmd.ExecuteNonQuery();
                msqc.Close();
                msqc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] GetInstaller(string pgid)
        {
            try
            {
                MySqlConnection msqc = new MySqlConnection(connetStr);
                msqc.Open();
                MySqlDataAdapter msda = new MySqlDataAdapter($"USE accounts;SELECT * FROM kitxpgs WHERE pgid = {pgid};", msqc);
                DataSet myds = new DataSet();
                msda.Fill(myds);
                byte[] returning = (byte[])myds.Tables[0].Rows[0]["pginstaller"];
                msda.Dispose();
                msqc.Close();
                msqc.Dispose();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetInstallerType(string pgid)
        {
            var pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgid = '{pgid}';");
            pwdItem.Read();
            string returning;
            try
            {
                returning = pwdItem.GetString("pginstallertype");
            }
            catch (Exception)
            {
                return "NULL";
            }
            return returning;
        }

        protected void LoadCS() => connetStr += $"User Id=root;Password={dbpwd};";

        protected void LoadPassword() => dbpwd = Coder.Decrypt(miwen, null, Coder.Decrypt(decryptpwd, null, decryptdecryptpwd, Coder.ALG.DES), Coder.ALG.DES);

        protected void LoadConfig()
        {
            miwen = LoadMiwen();
            decryptpwd = LoadDCPWD();
            pwd = LoadPassWord();
            decryptdecryptpwd = LoadDCDCPWD();
        }

        public string[] GetToolItem(string pgid)
        {
            try
            {
                string[] item = new string[11];

                var pwdItem = GetReturn($"USE accounts;SELECT * FROM kitxpgs WHERE pgid = '{pgid}';");
                pwdItem.Read();
                item[0] = pgid;
                item[1] = pwdItem.GetString("pgname");
                item[2] = pwdItem.GetString("pgpublisher");
                item[3] = pwdItem.GetString("pgsimbledescribe");
                item[4] = pwdItem.GetString("pgcomplexdescribe");
                item[5] = pwdItem.GetString("pghelplink");
                item[6] = pwdItem.GetString("pghostlink");
                item[7] = pwdItem.GetString("pgtag");
                item[8] = pwdItem.GetString("pglang");
                item[9] = pwdItem.GetString("pgversion");
                item[10] = pwdItem.GetDateTime("pglastpostdate").ToString("yyyy-MM-dd");
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public byte[] GetToolIcon(string pgid)
        {
            try
            {
                cont = new MySqlConnection(connetStr);
                cont.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter($"USE accounts;SELECT * FROM kitxpgs WHERE pgid = '{pgid}';", cont);
                DataSet myds = new DataSet();
                sda.Fill(myds);
                byte[] returning = (byte[])myds.Tables[0].Rows[0]["pgicon"];
                sda.Dispose();
                return returning;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected string LoadPassWord() => FileHelper.ReadAll($"{Environment.CurrentDirectory}\\KitX.Helper.Shutdown.bat");

        protected string LoadMiwen() => FileHelper.ReadAll($"{Environment.CurrentDirectory}\\PopEye.WPF.64bit.dll").Replace("\r\n", null).Trim();

        protected string LoadDCPWD() => FileHelper.ReadAll($"{Environment.CurrentDirectory}\\PopEye.WPF.32bit.dll").Replace("\r\n", null).Trim();

        protected string LoadDCDCPWD() => FileHelper.ReadAll($"{Environment.CurrentDirectory}\\PopEye.WPF.AnyCPU.dll").Replace("\r\n", null).Trim();

        protected string GetWID(string id) => id.Substring(0, 8);
    }
}
