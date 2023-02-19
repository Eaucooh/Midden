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
    public partial class BorrowRecord : Form
    {
        Form form;
        public BorrowRecord(Form form)
        {
            InitializeComponent();
            this.form = form;
            showRecord();
        }

        DataBaseConection DataBaseConection = new DataBaseConection();

        private void btnBack_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            showRecord();
        }

        public void showRecord()
        {
            libraryRecordDGV.DataSource=DataBaseConection.loanRecord();
        }

        private void returnBookButtom_Click(object sender, EventArgs e)
        {
            if (libraryRecordDGV.Rows.Count!=0)
            {
                string returnTime = DateTime.Today.ToString();
                string bookNumber = libraryRecordDGV.CurrentRow.Cells[0].Value.ToString();
                if (DataBaseConection.returnBook(returnTime, bookNumber))
                    MessageBox.Show("本书已经归还不需要归还", "归还提示");
                else
                    MessageBox.Show("您已经成功归还本书，谢谢使用", "归还提示");
                showRecord();
            }
            else
                MessageBox.Show("当前没有选中要还的书或者没有借书记录");
            
        }
    }
}
