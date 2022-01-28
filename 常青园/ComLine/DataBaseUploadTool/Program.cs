using MySqlConnector;
using System;

namespace DataBaseUploadTool
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Data Base Upload Tool");
			Console.WriteLine("Powered by Catrol, visit the author at https://blog.catrol.cn/");
			Console.WriteLine("Version: v1.0.0 All Right Reserved.");
			Console.WriteLine();
            Console.Write("Would you like to take a look for the use help doc (Y/N):");
            string shouldLookForHelp = Console.ReadLine();
            if (shouldLookForHelp.Equals("Y"))
            {
				Help();
            }

            Console.Write("Data Source:");
            string serverLocate = Console.ReadLine();
            Console.Write("Port:");
            string port = Console.ReadLine();
            Console.Write("Data Base:");
            string database = Console.ReadLine();
            Console.Write("Pooling:");
            string pooling = Console.ReadLine();
            Console.Write("Char Set:");
            string charset = Console.ReadLine();
            Console.Write("User:");
            string user = Console.ReadLine();
            Console.Write("Password:");
            string pwd = Console.ReadLine();
            string connectStr = $"User Id={user};Password={pwd};Data Source={serverLocate};port={port};Database={database};pooling={pooling};CharSet={charset};";

            if (Library.NetHelper.NetHelper.IsWebConected("14.215.177.39", 3000))
			{
				MySqlConnection msc = new MySqlConnection(connectStr);
                try
				{
					msc.Open();
					Separate();
					Console.WriteLine("Connected succeed!\r\nPress Enter to continue.");
					Separate();
					Console.ReadLine();
					Console.Write("Source File Path:");
					string sfp = Console.ReadLine();
					Console.Write("Data Base:");
					string db = Console.ReadLine();
					Console.Write("Table:");
					string tab = Console.ReadLine();
					Console.Write("Column name:");
					string cn = Console.ReadLine();
					Console.Write("Condition:");
					string con = Console.ReadLine();
					Separate();
					string sendFileSql = $"USE {db};UPDATE {tab} SET {cn} = ?file {con};";
					Console.WriteLine(sendFileSql);
					Console.WriteLine("Please check the text, will you do it ? (Y/N)");
					bool stop = false;
                    while (!stop)
					{
						Separate();
						Console.Write("Your choice:");
						if (Console.ReadLine().Equals("Y"))
						{
							Separate();
							Console.WriteLine("Uploading is doing");
							MySqlCommand sendCmd = new MySqlCommand(sendFileSql, msc);
							byte[] content = Library.FileHelper.FileHelper.ReadByteAll(sfp);
							Console.WriteLine("Finished reading");
							Console.WriteLine("Start uploading");
							sendCmd.Parameters.Add("?file", MySqlDbType.LongBlob).Value = content;
							sendCmd.ExecuteNonQuery();
							stop = true;
							Console.WriteLine("All is Done");
						}
						else if (Console.ReadLine().Equals("N"))
						{
							stop = true;
							Console.WriteLine("Your choice was down.");
						}
                        else
						{
							stop = false;
							Console.WriteLine("Please select from Y and N (Y - Yes; N - No)");
						}
					}
					msc.Close();
					msc.Dispose();
					Console.ReadLine();
				}
                catch (Exception o)
				{
					Separate();
					Console.WriteLine($"Failed - {o.Message}");
					Separate();
					Console.WriteLine("The application will exit, press enter to close it.");
					Console.ReadLine();
                }
			}
            else
            {
				Console.WriteLine("Connected failed, please check your web connection");
            }
		}

        private static void Help()
        {
			Separate();
			Console.WriteLine("Data Source - 数据库服务器地址，例如：www.baidu.com 或是 直接使用 IP 地址" +
				"\r\nPort - 要连接的端口号" +
				"\r\nData Base - 初始连接时数据库名称" +
				"\r\nPooling - 填 false 即可" +
				"\r\nChar Set - 连接用字符集 推荐 utf8" +
				"\r\nUser - 要登录的用户名" +
				"\r\nPassword - 用户的登陆密码");
			Separate();
			Console.WriteLine("Source File Path - 要从本地上传的文件路径，必须是绝对路径" +
				"\r\nData Base - 要上传的数据库名称" +
				"\r\nTable - 要上传的表名称" +
				"\r\nColumn name - 上传到的列名称" +
				"\r\nCondition - 条件，例如：WHERE id = 123 不需要在末尾追加分号");
			Separate();
        }

        private static void Separate()
		{
			int length = Console.WindowWidth;
			for (int i = 0; i < length; i++)
			{
				Console.Write('-');
			}
		}
	}
}
