using DAL;
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

namespace HoteManage
{
    public partial class ROOMSearch : Form
    {
        public ROOMSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            string where;
            if (txtRoomNumber.Text != "")
            {
                where = " RoomNumber='" + txtRoomNumber.Text + "'";
                dgvRoomInfo.DataSource = bll.GetRoomInfoInfoList(where);
            }
            if (cboRoomType.Text != "")
            {
                where = " RoomType='" + cboRoomType.Text + "'";
                dgvRoomInfo.DataSource = bll.GetRoomInfoInfoList(where);
            }
            if (cboRoomStatus.Text != "")
            {
                where = " RoomStatus='" + cboRoomStatus.Text + "'";
                dgvRoomInfo.DataSource = bll.GetRoomInfoInfoList(where);
            }

        }
    }
}
