using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace 图书管理系统
{
    class DataBaseConection
    {
        string connectionString = "server=127.0.0.1;port=3306;user=MyLibary;password=123; database=libary;";
       
        public bool Login(string userName,string password,bool IsAdmin)
        {
           
            bool LoginResult=true;
            string CommandText = "select * from users where UserName='" + userName + "'";
            string AdminCommandText = "select * from admin where AdminName='" + userName + "'";
            string FinallyCommand;

            if (IsAdmin)
                FinallyCommand = AdminCommandText;
            else
                FinallyCommand = CommandText;

            using (MySqlConnection libaryConnection = new MySqlConnection(connectionString))
            {
                libaryConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(FinallyCommand, libaryConnection);
                MySqlDataReader nameReader = mySqlCommand.ExecuteReader();
                if (nameReader.Read())
                {
                    string passwordRead = nameReader.GetString(nameReader.GetOrdinal("Password"));
                    if (password == passwordRead)
                        LoginResult = true;
                    else
                        LoginResult = false;
                }
                else
                    LoginResult = false;
            }

            return LoginResult;
        }

        public void LoginRecord(string name,string LoginTime)
        {
            string LoginRecordCommandText="insert into loginrecord(UserName,LoginTime)" +
                "values" +
                "('"+name+ "','" + LoginTime + "')";

            using (MySqlConnection loginRecords = new MySqlConnection(connectionString))
            {
                loginRecords.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(LoginRecordCommandText, loginRecords);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public DataTable loanRecord()
        {
            DataTable loanRecord;

            string CommandText = "select 图书编号,书名,借阅人,借阅时间,应归还时间,是否归还,归还时间 from loaninfo";

            using (MySqlConnection loanRecordConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(CommandText,connectionString);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                loanRecord = dataTable;
            }

            return loanRecord;
        }

        public DataTable showBook()
        {
            DataTable books;
            string showBookCommandText = "select 书名,类别,语种,原名,编号,索书号,作者,ISBN号,译者,出版时间,出版社,内容摘写 " +
                "from booksinfo";

            using (MySqlConnection showBookConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(showBookCommandText,showBookConnection);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                books = dataTable;
            }
            return books;
        }

        public DataTable commonUser()
        {
            DataTable commonUser;

            string CommonUserCommandText = "select UserName,Sex,IDCardNumber,WorkUnit,PhoneNumber,UserID,SigninTime from users";

            using (MySqlConnection commonUserConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(CommonUserCommandText,commonUserConnection);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                commonUser = dataTable;
            }
            return commonUser;

        }

        public bool passwordChange(string name,string password,string newPassword)
        {
            bool IsPasswordChange;

            string passwordChangeCommand = "update users set Password='" + newPassword + "'";
            string IsPasswordCommand = "select * from users where UserName='" + name + "'";

            using (MySqlConnection passwordChangeConnection = new MySqlConnection(connectionString))
            {
                passwordChangeConnection.Open();
                MySqlCommand isPassword = new MySqlCommand(IsPasswordCommand, passwordChangeConnection);
                MySqlCommand passwordChange = new MySqlCommand(passwordChangeCommand, passwordChangeConnection);
                using (MySqlDataReader mySqlDataReader = isPassword.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        string passwordRead = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("Password"));
                        if (password == passwordRead)
                        {
                            IsPasswordChange = true;
                        }
                        else
                            IsPasswordChange = false;
                    }
                    else
                        IsPasswordChange = false;
                }
                if (IsPasswordChange)
                    passwordChange.ExecuteNonQuery();
                    
            }
            return IsPasswordChange;
        }

        public DataTable seekBookByName(string bookName)
        {
            string seekBookByNameCommand = "select 书名,类别,语种,原名,编号,索书号," +
                "作者,ISBN号,译者,出版时间,出版社 from booksinfo where 书名='"+bookName+"'";

            DataTable bookData;

            using (MySqlConnection seekBookByNameConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(seekBookByNameCommand, seekBookByNameConnection);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                bookData = dataTable;
            }
            return bookData;
        }

        public DataTable seekBookByClass(string bookClass)
        {
            string seekBookByNameCommand = "select 书名,类别,语种,原名,编号,索书号," +
                 "作者,ISBN号,译者,出版时间,出版社 from booksinfo where 类别='" + bookClass + "'";

            DataTable bookData;

            using (MySqlConnection seekBookByNameConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(seekBookByNameCommand, seekBookByNameConnection);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                bookData = dataTable;
            }
            return bookData;
        }

        

        public string[]  bookinfos(string bookName)
        {

            string bookDigestCommand = "select * from booksinfo where 书名='" + bookName + "'";
            string[] bookinfos= new string[7];

            using (MySqlConnection bookDigestConnection = new MySqlConnection(connectionString))
            {
                bookDigestConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(bookDigestCommand, bookDigestConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    bookinfos[0]=mySqlDataReader["内容摘写"].ToString();
                    bookinfos[1] = mySqlDataReader["书名"].ToString();
                    bookinfos[2] = mySqlDataReader["类别"].ToString();
                    bookinfos[3] = mySqlDataReader["出版社"].ToString();
                    bookinfos[4] = mySqlDataReader["作者"].ToString();
                    bookinfos[5] = mySqlDataReader["出版时间"].ToString();
                    bookinfos[6] = mySqlDataReader["编号"].ToString();
                }
            }
            return bookinfos;
        }

        public void borrowBook(string bookName,string name,string borrowTime,string bookNumber)
        {
            string borrowBookCommand = "insert into loaninfo(图书编号,书名,借阅人,借阅时间,应归还时间,是否归还)" +
                "values('" + bookNumber + "','" + bookName + "','" + name + "','" + borrowTime + "','半年','否')";

            using (MySqlConnection borrowBookConnection = new MySqlConnection(connectionString))
            {
                borrowBookConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(borrowBookCommand, borrowBookConnection);
                mySqlCommand.ExecuteNonQuery();

            }
        }

        public bool returnBook(string returnTime,string bookNumber )
        {
            string returnCommandText = "update loaninfo set 是否归还='是',归还时间='" + 
                returnTime + "' where 图书编号='" + bookNumber + "'";
            string IsReturnCommandText = "select * from loaninfo where 图书编号='" + bookNumber + "'";
            bool IsReturn=false;

            using (MySqlConnection returnBookConnection = new MySqlConnection(connectionString))
            {
                returnBookConnection.Open();
                MySqlCommand returnCommand = new MySqlCommand(returnCommandText, returnBookConnection);
                MySqlCommand IsReturnCommand = new MySqlCommand(IsReturnCommandText, returnBookConnection);
                using (MySqlDataReader IsReturnRead = IsReturnCommand.ExecuteReader())
                {
                    IsReturnRead.Read();
                    if (IsReturnRead["是否归还"].ToString() == "是")
                        IsReturn = true;
                    else
                        IsReturn = false;
                }
                if(!IsReturn)
                   returnCommand.ExecuteNonQuery();
            }
            return IsReturn;
        }

        

        public DataTable seekUser(string userClass,string value)
        {
            string seekUserByClassCommandText = "select UserName,Sex,IDCardNumber,WorkUnit,PhoneNumber,UserID,SigninTime from users " +
                "where "+userClass+"='"+value+"'" ;
            

            DataTable seekUsers;

            using (MySqlConnection seekUserConnection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(seekUserByClassCommandText,seekUserConnection);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                seekUsers = dataTable;
            }
            return seekUsers;
        }

        public void deleteUser(string name)
        {
            string deleteUserCommand="delete from users where UserName='"+name+"'";
            using (MySqlConnection deletUserConnection = new MySqlConnection(connectionString))
            {
                deletUserConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(deleteUserCommand, deletUserConnection);
                mySqlCommand.ExecuteNonQuery();

            }
        }


        public void bookInfoChange(string bookNumber,string bookName,string bookClass,
            string press,string author,string publishTime)
        {
            string bookInfoChangeCommandText="update booksinfo set 书名='"+ bookName + "',类别='"+ bookClass + "',出版社='"+ press + "'," +
                "作者='"+ author + "',出版时间='"+ publishTime + "' where 编号='"+ bookNumber + "'";

            using (MySqlConnection bookInfoChangeConnection = new MySqlConnection(connectionString))
            {
                bookInfoChangeConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(bookInfoChangeCommandText, bookInfoChangeConnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public void bookDelete(string name)
        {
            string bookDeleteCommand = "delete from booksinfo where 书名='" + name + "'";
            using (MySqlConnection bookDeleteConnection = new MySqlConnection(connectionString))
            {
                bookDeleteConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(bookDeleteCommand,bookDeleteConnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public bool addNewBook(string bookName,string bookClass,string language, string oldName,
            string bookNumber, string callNumber, string author, string iSBN, string translator,
           string publish, string press, string content )
        {
            bool IsBookAdd;
            string addNewBookCommandText = "insert into booksinfo (书名,类别,语种,原名,编号,索书号," +
                "作者,ISBN号,译者,出版时间,出版社,内容摘写)" +
                "value('"+ bookName + "','"+ bookClass + "','"+ language + "','"+ oldName + "'," +
                "'"+ bookNumber + "','"+ callNumber + "','"+ author + "','"+ iSBN + "','"+ translator + "','"+publish+"'," +
                "'"+ press + "','"+ content+ "')";
            string IsBookEixstedCommandText = "select * from booksinfo where 书名='" +bookName + "'";
            using (MySqlConnection addNewBookConnection = new MySqlConnection(connectionString))
            {
                addNewBookConnection.Open();
                MySqlCommand AddCommand = new MySqlCommand(addNewBookCommandText,addNewBookConnection);
                MySqlCommand IsExistedCommand = new MySqlCommand(IsBookEixstedCommandText, addNewBookConnection);
                using (MySqlDataReader IsExistedReader = IsExistedCommand.ExecuteReader())
                {
                    if (IsExistedReader.Read())
                        IsBookAdd = false;
                    else
                        IsBookAdd = true;
                }
                if (IsBookAdd)
                    AddCommand.ExecuteNonQuery();
            }
            return IsBookAdd;
        }


        public bool userLogout(string name,string password)
        {
            bool IsDelete;
            
            string userLogoutCommand = "delete from users where UserName='" + name + "'";
            string seekUserCommand = "select * from users where UserName='" + name + "'";
            using (MySqlConnection userLogoutConnection = new MySqlConnection(connectionString))
            {
                userLogoutConnection.Open();
                MySqlCommand logoutCommand = new MySqlCommand(userLogoutCommand,userLogoutConnection);
                MySqlCommand seekCommad = new MySqlCommand(seekUserCommand, userLogoutConnection);
                using (MySqlDataReader mySqlDataReader = seekCommad.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        string passwordRead = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("Password"));
                        if (password == passwordRead)
                        {
                            IsDelete = true;  
                        }
                        else
                            IsDelete = false;
                    }
                    else
                        IsDelete = false;
                }
                if(IsDelete)
                    logoutCommand.ExecuteNonQuery();
            }
            return IsDelete;
        }

        public bool userAdd(string userName,string password,string sex,string 
            idCardNumber,string workUnit,string phoneNumber,string userID,string signinTime)
        {
            bool IsUserAdd;
            string userAddCommand = "insert into users(UserName,Password,Sex," +
                "IDCardNumber,WorkUnit,PhoneNumber,UserID,SigninTime)" +
                "value('" + userName + "','" + password + "','" + sex + "','" + idCardNumber + "'," +
                "'" + workUnit + "','" + phoneNumber + "','" + userID + "','" + signinTime + "')";
            string seekUserCommand = "select * from users where UserName='" + userName + "'";

            using (MySqlConnection userAddConnection = new MySqlConnection(connectionString))
            {
                userAddConnection.Open();
                MySqlCommand AddCommand = new MySqlCommand(userAddCommand,userAddConnection);
                MySqlCommand SeekCommand = new MySqlCommand(seekUserCommand, userAddConnection);
                using (MySqlDataReader mySqlDataReader = SeekCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        IsUserAdd = false;
                    }
                    else
                    {
                        IsUserAdd = true;                       
                    }
                }
                if (IsUserAdd)
                    AddCommand.ExecuteNonQuery();
            }
            
            return IsUserAdd;
        }

    }
}
