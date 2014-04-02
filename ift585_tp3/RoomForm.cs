﻿using ift585_tp3.Properties;
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

        public RoomForm(DiscussionRoom room, User user)
        {
            InitializeComponent();

            actualUser = user;

            Data data1 = new Data();
            Data data2 = new Data();
            Data data3 = new Data();

            if (!room.ClientList.Contains(user))
            {
                room.ClientList.Add(user);
            }
            data1.Client = room.ClientList[0];
            data1.Date = DateTime.Now;
            data2.Client = room.ClientList[0];
            data2.Date = DateTime.Now;
            data3.Client = room.ClientList[0];
            data3.Date = DateTime.Now;

            data1.Text = "J'aime les tomates";
            data2.Text = "I ain't gonna act politically correct. I only wanna have a good time. The best thing about being a woman. Is the prerogative to have a little fun";
            data3.Text = "Oh, oh, oh, go totally crazy-forget I'm a lady. Men's shirts-short skirts. Oh, oh, oh, really go wild-yeah, doin' it in style. " +
                         "Oh, oh, oh, get in the action-feel the attraction. Color my hair-do what I dare. Oh, oh, oh, I wanna be free-yeah, to feel the way I feel" +
                         "Man! I feel like a woman!";

            room.MessageList.Add(data1);
            room.MessageList.Add(data2);
            room.MessageList.Add(data3);

            this.discussionRoomBindingSource.DataSource = room;
            this.clientListBindingSource.DataSource = room.ClientList;

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
                    User selectedClient = listBoxUsers.SelectedItem as User;
                    UserProfilForm profilForm = new UserProfilForm(selectedClient, true);
                    profilForm.Show();
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
                    data.LikeNum++;
                    data.Client.LikeNum++;
                }
                else if (dataGridViewMessage.CurrentCell.ColumnIndex == 4)
                {
                    data.DislikeNum++;
                    data.Client.DislikeNum++;
                }
                else if (dataGridViewMessage.CurrentCell.ColumnIndex == 5 && (actualUser.UserName == data.Client.UserName))
                {
                    dataGridViewMessage.Rows.RemoveAt(e.RowIndex);
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
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 && (actualUser.UserName == data.Client.UserName))
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Arrow;
        }


        private void dataGridViewMessage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewMessage.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.ColumnIndex == 5)
            {
                try
                {
                    Data data = (dataGridViewMessage.Rows[e.RowIndex].DataBoundItem as Data);

                    if (!(actualUser.UserName == data.Client.UserName))
                    {
                        e.Value = new Bitmap(1, 1);
                    }
                }
                catch
                {
                }
            }

        }


    }
}
