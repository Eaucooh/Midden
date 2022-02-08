using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class commonUI : Form
    {
        Form form;
        User User;
        DataBaseConection dataBaseConection = new DataBaseConection();
        

        public commonUI(Form form,string name)
        {
            InitializeComponent();
            this.form = form;
            bookClassComboBox.SelectedIndex = 0;
            showBook();
            User = new User(name);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BorrowRecord borrowRecord = new BorrowRecord(this);
            borrowRecord.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        private void searchBookButtom_Click(object sender, EventArgs e)
        {
            string bookName = bookNameTextBox.Text;
            if (bookNameTextBox.Text == String.Empty)
                MessageBox.Show("书名不能为空", "搜索终止");
            else
            {
                if (dataBaseConection.seekBookByName(bookName).Rows.Count == 0)
                    MessageBox.Show("查无此书", "查询结果");
                else
                    booksDVG.DataSource = dataBaseConection.seekBookByName(bookName);
            }
        }
              

        private void searchByKindButtom_Click(object sender, EventArgs e)
        {
            string bookClass = bookClassComboBox.SelectedItem.ToString();
            booksDVG.DataSource = dataBaseConection.seekBookByClass(bookClass);
        }

        private void booksDVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bookName = booksDVG.CurrentRow.Cells[0].Value.ToString();
            bookDigestTextBox.Text = dataBaseConection.bookinfos(bookName)[0];
        }

        private void borrowButtoom_Click(object sender, EventArgs e)
        {
            string bookName = booksDVG.CurrentRow.Cells[0].Value.ToString();
            string bookNumber = booksDVG.CurrentRow.Cells[4].Value.ToString();
            string name = User.Name;
            string borrowTime = DateTime.Today.ToString();
           dataBaseConection.borrowBook(bookName,name,borrowTime,bookNumber);
            showBook();
            MessageBox.Show("您已成功借到此书，请在半年内归还", "借书成功");
        }

        public void showBook()
        {
            booksDVG.DataSource = dataBaseConection.showBook();
        }
    }
}
