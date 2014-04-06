using ift585_tp3.Properties;
using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ift585_tp3
{
    public partial class RoomForm : Form
    {
        User actualUser = null;
        DiscussionRoom actualRoom;
        DateTime lastRefresh;

        public RoomForm(DiscussionRoom room, User user)
        {
            lastRefresh = DateTime.Now;
            actualUser = user;
            actualRoom = room;

            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.discussionRoomBindingSource.DataSource = actualRoom;
            this.clientListBindingSource.DataSource = actualRoom.ClientList;
            refreshTimer.Start();
        }

        /// <summary>
        /// Double clique sur un utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                if (listBoxUsers.SelectedItem.ToString().Length != 0)
                {
                    User selectedUser = listBoxUsers.SelectedItem as User;
                    Data viewProfileRequest = new Data();
                    viewProfileRequest.Command = Data.DataType.ViewProfile;
                    viewProfileRequest.Text = selectedUser.UserName;
                    Program.callBackOnReceive.Enqueue(CallBackViewProfile);
                    Program.client.Send(viewProfileRequest);
                }
            }
        }

        /// <summary>
        /// Envoyer un message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string text = textBoxMessage.Text.Trim();
            
            //Envoi au serveur
            Data messageSendRequest = new Data();
            messageSendRequest.Command = Data.DataType.SendMessage;
            messageSendRequest.User = actualUser;
            messageSendRequest.Text = text;
    
            actualRoom.MessageList.Add(messageSendRequest);
            Program.client.Send(messageSendRequest);

            textBoxMessage.Clear();
        }

        /// <summary>
        /// Lorsqu'on clic sur like ou dislike
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMessage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Data data = (dataGridViewMessage.CurrentRow.DataBoundItem as Data);

                if (dataGridViewMessage.CurrentCell.ColumnIndex == 3)
                {
                    Data likeRequest = new Data();
                    likeRequest.Command = Data.DataType.Like;
                    likeRequest.User = data.User;
                    Program.client.Send(likeRequest);
                }
                else if (dataGridViewMessage.CurrentCell.ColumnIndex == 4)
                {
                    Data dislikeRequest = new Data();
                    dislikeRequest.Command = Data.DataType.Dislike;
                    dislikeRequest.User = data.User;
                    Program.client.Send(dislikeRequest);
                }
                else if (dataGridViewMessage.CurrentCell.ColumnIndex == 5 && (actualUser.UserName == data.User.UserName))
                {
                    dataGridViewMessage.Rows.RemoveAt(e.RowIndex);
                    dataGridViewMessage.Cursor = Cursors.Arrow;
                }
            }
        }

        /// <summary>
        /// Lorsqu'on entre avec la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMessage_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            var dataGridView = (sender as DataGridView);
            Data data = (dataGridViewMessage.Rows[e.RowIndex].DataBoundItem as Data);

            //Check the condition as per the requirement casting the cell value to the appropriate type
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 && (actualUser.UserName == data.User.UserName))
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Arrow;
        }


        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            Data refreshRequest = new Data();
            refreshRequest.Command = Data.DataType.GetDiscussionRoom;
            refreshRequest.Text = actualUser.UserName;
            refreshRequest.Date = lastRefresh;

            Program.callBackOnReceive.Enqueue(CallBackRoomRefresh);
            Program.client.Send(refreshRequest);
        }

        
        private void dataGridViewMessage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewMessage.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.ColumnIndex == 5)
            {
                try
                {
                    Data data = (dataGridViewMessage.Rows[e.RowIndex].DataBoundItem as Data);

                    if (!(actualUser.UserName == data.User.UserName))
                    {
                        e.Value = new Bitmap(1, 1);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Lorsque la fenêtre se ferme on enlève l'usager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data leaveRoomRequest = new Data();
            leaveRoomRequest.Command = Data.DataType.LeaveRoom;
            leaveRoomRequest.Text = actualUser.UserName;

            Program.client.Send(leaveRoomRequest);
        }

        private int CallBackRoomRefresh(Data receive)
        {
            if (receive.Command == Data.DataType.GetDiscussionRoom)
            {
                DiscussionRoom room = (DiscussionRoom)receive.Other;
                if (room != null)
                {
                    lastRefresh = DateTime.Now;
                    actualRoom = room;
                    this.Invoke((MethodInvoker)delegate() 
                    {
                        this.discussionRoomBindingSource.DataSource = actualRoom;
                        this.clientListBindingSource.DataSource = actualRoom.ClientList;
                    });
                }
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }

        private int CallBackViewProfile(Data received)
        {
            if (received.Command == Data.DataType.ViewProfile)
            {
                User user = (User)received.Other;
                UserProfilForm profilForm = new UserProfilForm(user, true);
                this.Invoke((MethodInvoker)delegate() { profilForm.ShowDialog(); });
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }
    }
}
