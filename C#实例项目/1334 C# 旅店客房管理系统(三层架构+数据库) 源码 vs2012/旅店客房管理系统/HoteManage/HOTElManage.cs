using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoteManage
{
    public partial class HOTElManage : Form
    {
        public HOTElManage()
        {
            InitializeComponent();
        }

      
        private void tsmiCustomer_Click(object sender, EventArgs e)
        {
           
        }

        private void tsmiBookRoom_Click(object sender, EventArgs e)
        {
            BkRoom frmBookRoom = new BkRoom();
            frmBookRoom.MdiParent = this;
            frmBookRoom.Show();

        }

        private void tsmiCancelReservation_Click(object sender, EventArgs e)
        {
            CancelReservation frmCancelReservation = new CancelReservation();
            frmCancelReservation.MdiParent = this;
            frmCancelReservation.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiCheckOut_Click(object sender, EventArgs e)
        {
            CheckOUT frmCheckOut = new CheckOUT();
            frmCheckOut.MdiParent = this;
            frmCheckOut.Show();
        }

        private void tsmiPayDeposit_Click(object sender, EventArgs e)
        {
            PayDeposit frmPayDeposit = new PayDeposit();
            frmPayDeposit.MdiParent = this;
            frmPayDeposit.Show();
        }

        private void tsmiRoomSearch_Click(object sender, EventArgs e)
        {
            ROOMSearch frmRoomSrarch = new ROOMSearch();
            frmRoomSrarch.MdiParent = this;
            frmRoomSrarch.Show();                                                                                
        }

        private void tsmiCustomerSearch_Click(object sender, EventArgs e)
        {
            CustomerSEARCH frmCustomerSearch = new CustomerSEARCH();
            frmCustomerSearch.MdiParent = this;
            frmCustomerSearch.Show();
        }

        private void tsmiBookSearch_Click(object sender, EventArgs e)
        {
            BkSearch frmBookSearch = new BkSearch();
            frmBookSearch.MdiParent = this;
            frmBookSearch.Show();
        }

        private void tsmiAddRoom_Click(object sender, EventArgs e)
        {
            ADDRoom frmAddRoom = new ADDRoom();
            frmAddRoom.MdiParent = this;
            frmAddRoom.Show();
        }

        private void tsmiRoomManage_Click(object sender, EventArgs e)
        {
            ROOMManage frmRoomManage = new ROOMManage();
            frmRoomManage.MdiParent = this;
            frmRoomManage.Show();
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            ADDUser frmAddUser = new ADDUser();
            frmAddUser.MdiParent = this;
            frmAddUser.Show();
        }

        private void tsmiUserManage_Click(object sender, EventArgs e)
        {
            USERManage frmUserManage = new USERManage();
            frmUserManage.MdiParent = this;
            frmUserManage.Show();
        }

        private void tsbtnCheckIn_Click(object sender, EventArgs e)
        {
            CheckIN frmCheckIn = new CheckIN();
            frmCheckIn.MdiParent = this;
            frmCheckIn.Show();
        }

        private void tsbtnCheckOut_Click(object sender, EventArgs e)
        {
            CheckOUT frmCheckOut = new CheckOUT();
            frmCheckOut.MdiParent = this;
            frmCheckOut.Show();
        }

        private void tsbtnBookRoom_Click(object sender, EventArgs e)
        {
            BkRoom frmBookRoom = new BkRoom();
            frmBookRoom.MdiParent = this;
            frmBookRoom.Show();

        }

        private void tsbtnRoomSearch_Click(object sender, EventArgs e)
        {
            ROOMSearch frmRoomSearch = new ROOMSearch();
            frmRoomSearch.MdiParent = this;
            frmRoomSearch.Show();
        }

        private void tsbtnUser_Click(object sender, EventArgs e)
        {
            USERManage frmUserManage = new USERManage();
            frmUserManage.MdiParent = this;
            frmUserManage.Show();
        }

        private void tsmiCheckIn_Click(object sender, EventArgs e)
        {
            
            CheckIN frmCheckIn = new CheckIN();
            frmCheckIn.MdiParent = this;
            frmCheckIn.Show();
      

        }

        private void tsmiCheckIn_Click_1(object sender, EventArgs e)
        {
            CheckIN frmCheckIn = new CheckIN();
            frmCheckIn.MdiParent = this;
            frmCheckIn.Show();
        }
    }
}
