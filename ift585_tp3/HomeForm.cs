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
        Client actualClient = new Client();

        public HomeForm(Client client)
        {
            client.UserName = "Chalalalala";
            client.Avatar = "homer";
            actualClient = client;
            InitializeComponent();
            labelUserName.Text = client.UserName;
            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(!String.IsNullOrEmpty(client.Avatar) ? client.Avatar : "default");

            //On va chercher la liste des Client
            List<Client> clientList = new List<Client>();
            Client client1 = new Client();
            client1.UserName = "SteveJobsXXX";
            Client client2 = new Client();
            client2.UserName = "BillGates3";
            Client client3 = new Client();
            client3.UserName = "Mathilde";
            clientList.Add(client1);
            clientList.Add(client2);
            clientList.Add(client3);
            listBoxUsers.Items.AddRange(clientList.ToArray());
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
            listBoxChatRooms.Items.AddRange(roomList.ToArray());
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
            UserProfilForm profilForm = new UserProfilForm(actualClient);
            profilForm.ShowDialog();

            labelUserName.Text = actualClient.UserName;
            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(actualClient.Avatar);
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
                    Client selectedClient = listBoxUsers.SelectedItem as Client;
                    UserProfilForm profilForm = new UserProfilForm(selectedClient);
                    profilForm.ShowDialog();
                }
            }
        }
    }
}
