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
    public partial class HomeForm : Form
    {
        User actualClient = new User();

        public HomeForm(User client)
        {
            client.UserName = "Chalalalala";
            client.Avatar = "homer";
            actualClient = client;
            InitializeComponent();

            labelUserName.Text = client.UserName;
            
            if (client.IsConnected)
            {
                labelConnected.Text = "CONNECTÉ";
                labelConnected.ForeColor = Color.Lime;
            }
            else
            {
                labelConnected.Text = "DÉCONNECTÉ";
                labelConnected.ForeColor = Color.Red;
            }

            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(!String.IsNullOrEmpty(client.Avatar) ? client.Avatar : "default");

            //On va chercher la liste des Client
            List<User> clientList = new List<User>();
            User client1 = new User();
            client1.UserName = "SteveJobsXXX";
            User client2 = new User();
            client2.UserName = "BillGates3";
            User client3 = new User();
            client3.UserName = "Mathilde";
            clientList.Add(client1);
            clientList.Add(client2);
            clientList.Add(client3);
            listBoxUsers.DataSource = clientList;
            listBoxUsers.DisplayMember = "UserName";

            //On va chercher la liste des salles de discussions
            List<DiscussionRoom> roomList = new List<DiscussionRoom>();
            DiscussionRoom room1 = new DiscussionRoom();
            room1.Name = "MyPrettyLittleRoom";
            DiscussionRoom room2 = new DiscussionRoom();
            room2.Name = "Come..WeHaveCandies";
            roomList.Add(room1);
            roomList.Add(room2);
            room1.ClientList.Add(client1);
            room1.ClientList.Add(client2);
            room2.ClientList.Add(client3);
            listBoxChatRooms.DataSource = roomList;
            listBoxChatRooms.DisplayMember = "Name";
        }

        /// <summary>
        /// Modification/affichage du profil et des stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProfil_Click(object sender, EventArgs e)
        {
            UserProfilForm profilForm = new UserProfilForm(actualClient, false);
            if (profilForm.ShowDialog() == DialogResult.OK)
            {
                labelUserName.Text = actualClient.UserName;
                labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(actualClient.Avatar);
            }
            else
                actualClient = profilForm.oldClient;
        }

        /// <summary>
        /// Double clique sur une salle de discussion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxChatRooms_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxChatRooms.SelectedItem != null)
            {
                if (listBoxChatRooms.SelectedItem.ToString().Length != 0)
                {
                    DiscussionRoom selectedRoom = listBoxChatRooms.SelectedItem as DiscussionRoom;
                    //Se connecter à la salle de discussion

                    RoomForm roomForm = new RoomForm(selectedRoom);
                    roomForm.Show();
                }
            }
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
    }
}
