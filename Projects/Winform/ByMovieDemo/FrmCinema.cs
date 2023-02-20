using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 青鸟影院
{
    public partial class FrmCinema : Form
    {
        public FrmCinema()
        {
            InitializeComponent();
        }

        Cinema cinema = new Cinema();
        Label lbl = new Label();

        //获取新放映列表：
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            BingTreeView();
        }

        //选择内容发生改变：
        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvMovies.SelectedNode.Level == 1)
            {
                string time = this.tvMovies.SelectedNode.Text;
                ScheduleItem item = cinema.Schedule.Items[time];
                this.lblActor.Text = item.Movie.Actor;
                this.lblDirector.Text = item.Movie.Director;
                this.lblMovieName.Text = item.Movie.MovieName;
                this.lblPrice.Text = item.Movie.Price.ToString();
                this.lblTime.Text = item.Time;
                this.lblType.Text = item.Movie.MovieType.ToString();
                this.picMovie.Image = Image.FromFile(@"Image\" + item.Movie.Poster);
                this.lblCalcPrice.Text = item.Movie.Price.ToString();


                //将所有座位设置为黄色
                foreach (Seat var in cinema.Seats.Values)
                {
                    var.Color = Color.Yellow;
                }
                //在已售出的票中循环判断
                foreach (Ticket ticket in cinema.SoldTickets)
                {
                    foreach (Seat seat in this.cinema.Seats.Values)
                    {
                        //场次相同且座位号相同
                        if (ticket.ScheduleItem.Time == time && ticket.Seat.SeatNum == seat.SeatNum)
                        {
                            //更新座位颜色
                            seat.Color = Color.Red; 
                        }
                    }
                }
                // 将座位颜色更新到Label上显示
                foreach (Seat seat in cinema.Seats.Values)
                {
                    foreach (Label lbl in tpCinema.Controls)
                    {
                        // 座位号相同证明是对应Label
                        if (lbl.Text == seat.SeatNum)
                        {
                            lbl.BackColor = seat.Color;
                        }
                    }
                }
            }
        }

        //点击普通票
        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDisCount.Enabled = false;
            this.txtCustomer.Enabled = false;
            this.lblCalcPrice.Text = lblPrice.Text;
        }

        //点击赠票
        private void rdoFree_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = true;
            this.cmbDisCount.Enabled = false;
            this.lblCalcPrice.Text = lblPrice.Text;
        }

        //点击学生票
        private void rdoStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lblPrice.Text != "")
            {
                this.cmbDisCount.Enabled = true;
                this.txtCustomer.Enabled = false;
                this.lblCalcPrice.Text = (Convert.ToDouble(this.lblPrice.Text) * Convert.ToDouble(this.cmbDisCount.Text) / 10).ToString();
            }

        }

        //加载
        private void FrmCinema_Load(object sender, EventArgs e)
        {
            this.rdoNormal.Checked = true;
            this.cmbDisCount.SelectedIndex = 0;
            InitSeats(5, 7);
        }

        //选择折扣变化：
        private void cmbDisCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lblPrice.Text != "")
            {
                this.lblCalcPrice.Text = (Convert.ToDouble(this.lblPrice.Text) * Convert.ToDouble(this.cmbDisCount.Text) / 10).ToString();
            }

        }

        /// <summary>
        /// 获取放映列表绑定到TreeView
        /// </summary>
        private void BingTreeView()
        {
            this.tvMovies.Nodes.Clear();
            //加载XML
            cinema.Schedule.LoadItems();
            //绑定到TreeView
            TreeNode root = null;
            foreach (ScheduleItem var in cinema.Schedule.Items.Values)
            {
                if (root == null || root.Text != var.Movie.MovieName)
                {
                    //根节点
                    root = new TreeNode(var.Movie.MovieName);
                    this.tvMovies.Nodes.Add(root);
                }
                //子节点
                root.Nodes.Add(var.Time);
            }
        }

        /// <summary>
        /// 初始化座位
        /// </summary>
        private void InitSeats(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Label lb = new Label();
                    lb.BackColor = Color.Yellow;
                    lb.Location = new Point(20 + j * 100, 50 + i * 70);
                    lb.Font = new Font("Courier New", 11);
                    lb.Name = (i + 1) + "-" + (j + 1);
                    lb.Size = new Size(80, 30);
                    lb.TabIndex = 0;
                    lb.Text = (i + 1) + "-" + (j + 1);
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Click += lb_Click;
                    tpCinema.Controls.Add(lb);
                    //添加座位对象到CInema的Seats集合中
                    Seat seat = new Seat(lb.Text, Color.Yellow);
                    cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        private void lb_Click(object sender, EventArgs e)
        {
            if (this.tvMovies.Nodes.Count == 0 || this.tvMovies.SelectedNode.Level ==0)
            {
                return;
            }

            lbl = sender as Label;
            if (lbl.BackColor == Color.Red)
            {
                MessageBox.Show("已售出");
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("是否购买", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    //取得放映时间
                    string time = this.tvMovies.SelectedNode.Text;
                    //使用时间作为键找到放映场次对象
                    ScheduleItem item = cinema.Schedule.Items[time];

                    string type = string.Empty;
                    type = rdoNormal.Checked ? "normal" : rdoFree.Checked ? "free" : "student";
                    Ticket ticket = TicketUtil.CreateTicket(item, cinema.Seats[lbl.Text], txtCustomer.Text, Convert.ToDouble(cmbDisCount.Text), type);

                    //添加到已销售的集合中
                    cinema.SoldTickets.Add(ticket);
                    //出票
                    ticket.Print();
                    //更新颜色
                    lbl.BackColor = Color.Red;
                    cinema.Seats[lbl.Text].Color = Color.Red;
                }
            }

        }

        //保存
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            cinema.Save();
        }

        //继续销售
        private void tsmiMovies_Click(object sender, EventArgs e)
        {
            cinema.Load();
            // 将座位颜色更新到Label上显示
            foreach (Seat seat in cinema.Seats.Values)
            {
                foreach (Label lbl in tpCinema.Controls)
                {
                    // 座位号相同证明是对应Label
                    if (lbl.Text == seat.SeatNum)
                    {
                        lbl.BackColor = seat.Color;
                    }
                }
            }
        }


    }
}
