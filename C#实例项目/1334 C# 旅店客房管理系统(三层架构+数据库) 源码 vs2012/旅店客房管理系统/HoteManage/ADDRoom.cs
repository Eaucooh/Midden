using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace HoteManage
{
    public partial class ADDRoom : Form
    {
        public ADDRoom()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (txtRoomNumber.Text != "" && txtRoomPrice.Text != "" && cboRoomType.Text != "")
            {
                RoomInfoInfo info = new RoomInfoInfo();
                info.RoomNumber = txtRoomNumber.Text;
                info.RoomPrice = double.Parse(txtRoomPrice.Text);
                info.RoomType = cboRoomType.Text;
                info.Remarks = txtRemarks.Text;
                info.RoomStatus = "可供";

                RoomInfoBLL bll = new RoomInfoBLL();
                bool result = bll.AddRoomInfo(info);
                if (result)
                {
                    MessageBox.Show("客房添加成功", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("客房添加失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("请检查数据输入的正确性！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
         this.Close();
        }

        }
    }

